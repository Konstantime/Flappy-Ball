using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PromtOfSkins : MonoBehaviour
{
    public GameObject promptOfSkins;
    private int numberPromt;
    private int playerCompletedTraining;
    private bool isShowHint;
    public bool isPromt2;
    private int maxLevel;

    public void Start()
    {
        maxLevel = PlayerPrefs.GetInt("maxLevel");
        numberPromt = PlayerPrefs.GetInt("numberPromt");

        switch (maxLevel)
        {
            case (2):
                if (numberPromt == 1)
                {
                    if (isPromt2){numberPromt = 2;}
                    promptOfSkins.SetActive(true);
                }
                break;
            case (3):
                if (numberPromt == 2)
                {
                    if (isPromt2){numberPromt = 3;}
                    promptOfSkins.SetActive(true);
                }
                break;
            case (4):
                if (numberPromt == 3)
                {
                    if (isPromt2){numberPromt = 4;}
                    promptOfSkins.SetActive(true);
                }
                break;
            case (5):
                if (numberPromt == 4)
                {
                    if (isPromt2){numberPromt = 5;}
                    promptOfSkins.SetActive(true);
                }
                break;
        }
        PlayerPrefs.SetInt("numberPromt", numberPromt);
        PlayerPrefs.Save();
    }
}