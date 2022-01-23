using Random = UnityEngine.Random;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    private SpriteRenderer spriteRenderer;
    private Sprite spriteSkinsUp;
    private Sprite spriteSkinsLower;
    [SerializeField] private GameObject CanvasTextAttemptFinal;
    [SerializeField] private GameObject plateFinal;
    public Sprite spriteRed;
    public Sprite spriteBlue;
    public Sprite spriteOrange;
    public Sprite spritePurple;
    public Sprite spriteGreen;
    public Sprite spriteLightGreen;
    public Sprite spriteWhite;
    public Sprite spriteTurquoise;
    public Sprite spritePink;
    public AudioSource deathSound;
    public int level;
    public float Speed;
    public float Gravity;
    public float offsetY;// До первого нажатия игрок постепенно то поднимается то опускается. и эта переменная задает то насколько сильным будет отклонение от начальной позиции
    public float Deceleration;
    private int lastY = 0;//эта переменная служит костылем для правильной работы поднимания и опускания шарика в начале игры. И является промежуточным значением между настоящей позицией игрока и позицией куда игрок должен переместиться. Работает вместе с offsetY
    private float DecelerationCrutch = 0;//Это настоящее замедление которое является числом которое мы отнимаем от скорости игрока. По началу оно равно 0 но если игрок касается зеленой платформы то тогда эта переменная(DecelerationCrutch) увеличивается до Deceleration, а потом мы каждый кадр мы уменьшаем DecelerationCrutch до 0. Все это время мы продолжаем отнимать от скорости игрока замедление(DecelerationCrutch) и так как оно(DecelerationCrutch) постепенно уменьшается до 0 то и настоящая скорость игрока соответственно растёт
    private int attempt;
    private int attemptLevel1;
    private int attemptLevel2;
    private int attemptLevel3;
    private int attemptLevel4;
    private int attemptLevel5;
    private int numberOutputs;
    private int numberSkinsUp;
    private int numberSkinsLower;
    private int maxLevel;
    private Save sv = new Save();

    void Start()
    {
        sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));
        Application.targetFrameRate = 90;
        Rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        numberSkinsUp = PlayerPrefs.GetInt("numberSkinsUp");
        numberSkinsLower = PlayerPrefs.GetInt("numberSkinsLower");

        switch (numberSkinsUp)
        {
            case (0):
                spriteSkinsUp = spriteRed;
                break;
            case (1):
                spriteSkinsUp = spriteBlue;
                break;
            case (2):
                spriteSkinsUp = spriteOrange;
                break;
            case (3):
                spriteSkinsUp = spritePurple;
                break;
            case (4):
                spriteSkinsUp = spriteGreen;
                break;
            case (5):
                spriteSkinsUp = spriteLightGreen;
                break;
            case (6):
                spriteSkinsUp = spriteWhite;
                break;
            case (7):
                spriteSkinsUp = spriteTurquoise;
                break;
            case (8):
                spriteSkinsUp = spritePink;
                break;
        }
        switch (numberSkinsLower)
        {
            case (0):
                spriteSkinsLower = spriteRed;
                break;
            case (1):
                spriteSkinsLower = spriteBlue;
                break;
            case (2):
                spriteSkinsLower = spriteOrange;
                break;
            case (3):
                spriteSkinsLower = spritePurple;
                break;
            case (4):
                spriteSkinsLower = spriteGreen;
                break;
            case (5):
                spriteSkinsLower = spriteLightGreen;
                break;
            case (6):
                spriteSkinsLower = spriteWhite;
                break;
            case (7):
                spriteSkinsLower = spriteTurquoise;
                break;
            case (8):
                spriteSkinsLower = spritePink;
                break;
        }
        spriteRenderer.sprite = spriteSkinsUp;
        if (spriteRenderer.sprite == null) { spriteRenderer.sprite = spriteSkinsUp; }
    }

    private void FixedUpdate()
    {
        if (lastY < offsetY)//Эти условия нужны чтобы игрок до старта красиво то поднимался то опускался
        {
            lastY += 1;
        }
        else if (lastY == offsetY)
        {
            offsetY = (-offsetY);
        }
        else
        {
            lastY -= 1;
        }
        float lastY2 = lastY / 1000f;// Это нужно для избежания мантиссы
        if (DecelerationCrutch > 0)
        {
            DecelerationCrutch = DecelerationCrutch - 0.05f;// Во время уменьшения возможно появление мантиссы, но она никак не мешает процессу уменьшению числа почти до 0
        }
        if (Rigidbody.gravityScale == 0)//Это условие нужно для того чтобы игрок ещё до первого нажатия никуда не улетал
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, Rigidbody.velocity.y + lastY2);
        }
    }

    private void Update()
    {
        if (Rigidbody.gravityScale != 0)
        {
            Rigidbody.velocity = new Vector2(Speed - DecelerationCrutch, Rigidbody.velocity.y);
        }
    }

    public void ChangeGravity()
    {
        if (Rigidbody.gravityScale == 0)
        {
            Rigidbody.gravityScale = Gravity;
        }
        Rigidbody.gravityScale = -Rigidbody.gravityScale;
        if (Rigidbody.gravityScale > 0)
        {
            spriteRenderer.sprite = spriteSkinsLower;
        }
        else
        {
            spriteRenderer.sprite = spriteSkinsUp;
        }
    }

    public void StopMove()
    {
        DecelerationCrutch = Speed;
        Rigidbody.gravityScale = 0;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GreenPlatform")
        {
            DecelerationCrutch = Deceleration;
        }
        else if (other.tag == "PlatformDeath")
        {
            if (Gravity < 0)
            {
                Gravity *= -1;
            }
            attempt++;
            maxLevel = PlayerPrefs.GetInt("maxLevel");
            switch (level)
            {
                case 1:
                    attemptLevel1 = PlayerPrefs.GetInt("attemptLevel1");
                    attemptLevel1++;
                    PlayerPrefs.SetInt("attemptLevel1", attemptLevel1);
                    break;
                case 2:
                    attemptLevel2 = PlayerPrefs.GetInt("attemptLevel2");
                    attemptLevel2++;
                    PlayerPrefs.SetInt("attemptLevel2", attemptLevel2);
                    break;
                case 3:
                    attemptLevel3 = PlayerPrefs.GetInt("attemptLevel3");
                    attemptLevel3++;
                    PlayerPrefs.SetInt("attemptLevel3", attemptLevel3);
                    break;
                case 4:
                    attemptLevel4 = PlayerPrefs.GetInt("attemptLevel4");
                    attemptLevel4++;
                    PlayerPrefs.SetInt("attemptLevel4", attemptLevel4);
                    break;
                case 5:
                    attemptLevel5 = PlayerPrefs.GetInt("attemptLevel5");
                    attemptLevel5++;
                    PlayerPrefs.SetInt("attemptLevel5", attemptLevel5);
                    break;
            }
            deathSound.pitch = Random.Range(0.6f, 1.1f);
            deathSound.Play();
            Rigidbody.gravityScale = 0;
            transform.position = new Vector3(0, 0, transform.position.z);
            PlayerPrefs.Save();
        }
        else if (other.tag == "Finish")
        {
            maxLevel = PlayerPrefs.GetInt("maxLevel");
            if (maxLevel < 1)
            {
                maxLevel = 1;
            }
            if (level == maxLevel)
            {
                maxLevel = (level + 1);
                PlayerPrefs.SetInt("maxLevel", maxLevel);
            }
            Speed = 0;
            Rigidbody.gravityScale = 0;
            CanvasTextAttemptFinal.SetActive(true);
            plateFinal.SetActive(true);
            maxLevel = PlayerPrefs.GetInt("maxLevel");
        }
    }

    [Serializable]
    public class Save
    {
        public string Language;
    }
}