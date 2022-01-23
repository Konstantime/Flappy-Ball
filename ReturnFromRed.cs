using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnFromRed : MonoBehaviour
{
    private int maxLevel;

    public void ServiceButtonReturn(int SceneNumber)
    {
        SceneManager.LoadScene( SceneNumber );
    }
    
    public void SelectMaxLevel()
    {
        maxLevel = PlayerPrefs.GetInt("maxLevel");
        if (maxLevel < 1)
        {
            maxLevel = 1;
        }
        SceneManager.LoadScene( maxLevel );
    }
}