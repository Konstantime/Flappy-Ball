using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TextTryFinal : MonoBehaviour
{
    [SerializeField] private Text textAttempt;
    [SerializeField] private int level; 
    private int attemptForText = 0;
    private int trustAttempt;
    
    void Start()
    {
        switch (level)
            {
                case 1:
                    trustAttempt = PlayerPrefs.GetInt("attemptLevel1");
                    break;
                case 2:
                    trustAttempt = PlayerPrefs.GetInt("attemptLevel2");
                    break;
                case 3:
                    trustAttempt = PlayerPrefs.GetInt("attemptLevel3");
                    break;
                case 4:
                    trustAttempt = PlayerPrefs.GetInt("attemptLevel4");
                    break;
                case 5:
                    trustAttempt = PlayerPrefs.GetInt("attemptLevel5");
                    break;
            }
    }

    void Update()
    {
        if (attemptForText < trustAttempt)// это условие нужно для того чтобы текст красиво постепенно увеличивался, а не сразу был равен количеству попыток
        {
            attemptForText ++;
        }
        textAttempt.text = (attemptForText.ToString("N0"));
    }
}