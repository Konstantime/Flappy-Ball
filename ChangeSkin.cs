using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField] private EducationSkins ScriptEducationSkins;
    [SerializeField] private EducationHand ScriptEducationHand;
    public GameObject buttonSelectSkins;
    Image spritebuttonSelectSkins;
    public Sprite spriteRed;
    public Sprite spriteBlue;
    public Sprite spriteOrange;
    public Sprite spritePurple;
    public Sprite spriteGreen;
    public Sprite spriteLightGreen;
    public Sprite spriteWhite;
    public Sprite spriteTurquoise;
    public Sprite spritePink;
    public bool isButtonUpSkins;
    private int numberSkinsUp;
    private int numberSkinsLower;
    private int numberSkins;
    private int maxLevel;

    List<string> availableSkins = new List<string>(); // создание списка

    void Start()
    {
        if (ScriptEducationHand != null)
        {
            ScriptEducationHand.ChangePosition(transform.position);
        }
        maxLevel = PlayerPrefs.GetInt("maxLevel");
        spritebuttonSelectSkins = buttonSelectSkins.GetComponent<Image>();
        numberSkinsUp = PlayerPrefs.GetInt("numberSkinsUp");
        numberSkinsLower = PlayerPrefs.GetInt("numberSkinsLower");

        availableSkins.Add("Red");
        availableSkins.Add("Blue");

        if (maxLevel > 2)
        {
            availableSkins.Add("Orange");
            availableSkins.Add("Purple");
        }
        if (maxLevel > 3)
        {
            availableSkins.Add("Green");
            availableSkins.Add("Light green");
        }
        if (maxLevel > 4)
        {
            availableSkins.Add("White");
            availableSkins.Add("Turquoise");
        }
        if (maxLevel > 5)
        {
            availableSkins.Add("Pink");
        }

        if (isButtonUpSkins) { numberSkins = numberSkinsUp; }
        else { numberSkins = numberSkinsLower; }

        switch (numberSkins)
        {
            case (0):
                spritebuttonSelectSkins.sprite = spriteRed;
                break;
            case (1):
                spritebuttonSelectSkins.sprite = spriteBlue;
                break;
            case (2):
                spritebuttonSelectSkins.sprite = spriteOrange;
                break;
            case (3):
                spritebuttonSelectSkins.sprite = spritePurple;
                break;
            case (4):
                spritebuttonSelectSkins.sprite = spriteGreen;
                break;
            case (5):
                spritebuttonSelectSkins.sprite = spriteLightGreen;
                break;
            case (6):
                spritebuttonSelectSkins.sprite = spriteWhite;
                break;
            case (7):
                spritebuttonSelectSkins.sprite = spriteTurquoise;
                break;
            case (8):
                spritebuttonSelectSkins.sprite = spritePink;
                break;
        }
        if (isButtonUpSkins) { PlayerPrefs.SetInt("numberSkinsUp", numberSkinsUp); }
        else { PlayerPrefs.SetInt("numberSkinsLower", numberSkinsLower); }
        PlayerPrefs.Save();
    }

    public void ChangeSkinAndSprite()
    {
        numberSkinsUp = PlayerPrefs.GetInt("numberSkinsUp");
        numberSkinsLower = PlayerPrefs.GetInt("numberSkinsLower");

        if (isButtonUpSkins)
        {
            if (numberSkinsUp >= (availableSkins.Count - 1)) { numberSkinsUp = 0; }
            else { numberSkinsUp++; }
        }
        else
        {
            if (numberSkinsLower >= (availableSkins.Count - 1)) { numberSkinsLower = 0; }
            else { numberSkinsLower++; }
        }

        if (isButtonUpSkins) { numberSkins = numberSkinsUp; }
        else { numberSkins = numberSkinsLower; }

        if (ScriptEducationSkins.m_trainingInProgress)
        {
            numberSkins = availableSkins.Count - 1;
        }

        switch (numberSkins)
        {
            case (0):
                spritebuttonSelectSkins.sprite = spriteRed;
                break;
            case (1):
                spritebuttonSelectSkins.sprite = spriteBlue;
                break;
            case (2):
                spritebuttonSelectSkins.sprite = spriteOrange;
                break;
            case (3):
                spritebuttonSelectSkins.sprite = spritePurple;
                break;
            case (4):
                spritebuttonSelectSkins.sprite = spriteGreen;
                break;
            case (5):
                spritebuttonSelectSkins.sprite = spriteLightGreen;
                break;
            case (6):
                spritebuttonSelectSkins.sprite = spriteWhite;
                break;
            case (7):
                spritebuttonSelectSkins.sprite = spriteTurquoise;
                break;
            case (8):
                spritebuttonSelectSkins.sprite = spritePink;
                break;
        }
        if (isButtonUpSkins) { PlayerPrefs.SetInt("numberSkinsUp", numberSkinsUp); }
        else { PlayerPrefs.SetInt("numberSkinsLower", numberSkinsLower); }
        PlayerPrefs.Save();
    }

}