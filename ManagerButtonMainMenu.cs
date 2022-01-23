using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerButtonMainMenu : MonoBehaviour
{
    public GameObject buttoLevel;
    public Sprite Locked;
    public Sprite Unlocked;
    public int level;
    Image spritebuttoLevel;
    private int playerCompletedTraining;
    private int maxLevel;

    public void Start()
    {
        maxLevel = PlayerPrefs.GetInt("maxLevel");
        spritebuttoLevel = buttoLevel.GetComponent<Image>();
        if (maxLevel < 1)
        {
            maxLevel = 1;
        }
        PlayerPrefs.SetInt("maxLevel", maxLevel);
        PlayerPrefs.Save();
        if ( level <= maxLevel)
        {
            spritebuttoLevel.sprite = Unlocked;
        }
        else
        {
            spritebuttoLevel.sprite = Locked;
        }
    }

    public void SelectLevel(int SceneNumber)
    {
        maxLevel = PlayerPrefs.GetInt("maxLevel");
        if ( maxLevel >= level )
        {
            SceneManager.LoadScene( SceneNumber );
        }
        
    } 

    public void Exit()
    {
        Application.Quit();
    }
}