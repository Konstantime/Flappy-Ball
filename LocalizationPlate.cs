using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationPlate : MonoBehaviour
{
    public GameObject plateConnection;
    public Sprite Germany;
    public Sprite Spain;
    public Sprite India;
    public Sprite Italy;
    public Sprite Russia;
    public Sprite USA;
    public Sprite France;
    private SpriteRenderer spritePlateConnection;
    private string selectedLanguage;
    
    public void Start()
    {
        selectedLanguage = PlayerPrefs.GetString("selectedLanguage");
        spritePlateConnection = GetComponent<SpriteRenderer>();
        switch (selectedLanguage)
        {
            case "Germany":
                spritePlateConnection.sprite = Germany;
                break;
            case "Spain":
                spritePlateConnection.sprite = Spain;
                break;
            case "India":
                spritePlateConnection.sprite = India;
                break;
            case "Italy":
                spritePlateConnection.sprite = Italy;
                break;
            case "Russia":
                spritePlateConnection.sprite = Russia;
                break;
            case "English":
                spritePlateConnection.sprite = USA;
                break;
            case "France":
                spritePlateConnection.sprite = France;
                break;
            default:
                spritePlateConnection.sprite = USA;
                break;
        }
    }
}