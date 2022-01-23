using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlectedLanguage : MonoBehaviour
{
    public GameObject flagMenu;
    public string selectedLanguage;
    public Sprite Germany;
    public Sprite Spain;
    public Sprite India;
    public Sprite Italy;
    public Sprite Russia;
    public Sprite USA;
    public Sprite France;
    Image spriteFlagMenu;
    RectTransform size;
    public float widthGermany;
    public float heightGermany;
    public float widthSpain;
    public float heightSpain;
    public float widthIndia;
    public float heightIndia;
    public float widthItaly;
    public float heightItaly;
    public float widthRussia;
    public float heightRussia;
    public float widthUSA;
    public float heightUSA;
    public float widthFrance;
    public float heightFrance;
    
    public void Start()
    {
        spriteFlagMenu = flagMenu.GetComponent<Image> ();
        size = flagMenu.GetComponent<RectTransform>();
        selectedLanguage = PlayerPrefs.GetString("selectedLanguage");
    }
    public void Update()
    {
        selectedLanguage = PlayerPrefs.GetString("selectedLanguage");
        switch (selectedLanguage)
        {
            case "Germany":
                spriteFlagMenu.sprite = Germany;
                size.sizeDelta = new Vector2(widthGermany, heightGermany);
                break;
            case "Spain":
                spriteFlagMenu.sprite = Spain;
                size.sizeDelta = new Vector2(widthSpain, heightSpain);
                break;
            case "India":
                spriteFlagMenu.sprite = India;
                size.sizeDelta = new Vector2(widthIndia, heightIndia);
                break;
            case "Italy":
                spriteFlagMenu.sprite = Italy;
                size.sizeDelta = new Vector2(widthItaly, heightItaly);
                break;
            case "Russia":
                spriteFlagMenu.sprite = Russia;
                size.sizeDelta = new Vector2(widthRussia, heightRussia);
                break;
            case "English":
                spriteFlagMenu.sprite = USA;
                size.sizeDelta = new Vector2(widthUSA, heightUSA);
                break;
            case "France":
                spriteFlagMenu.sprite = France;
                size.sizeDelta = new Vector2(widthFrance, heightFrance);
                break;
            default:
                spriteFlagMenu.sprite = USA;
                size.sizeDelta = new Vector2(widthUSA, heightUSA);
                break;
        }
    }
}
