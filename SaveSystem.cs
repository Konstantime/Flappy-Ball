using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveSystem : MonoBehaviour
{
    public GameObject languagePanel;
    [SerializeField] private GameObject settingsPanel;
    public SlectedLanguage scriptMenuFlag;
    public SlectedLanguage scriptButtonPlay;
    public SlectedLanguage scriptButtonSettings;
    public SlectedLanguage scriptButtonLevels;
    public SlectedLanguage scriptButtonExit;
    public SlectedLanguage scriptButtonSkins;
    public SlectedLanguage scriptButtonComplexity;
    public SlectedLanguage scriptButtonEasy;
    public SlectedLanguage scriptButtonAverage;
    public SlectedLanguage scriptButtonDifficult;
    private int numberOutputs;
    private int maxLevel;
    private Save sv = new Save();

    public void Start()
    {
        maxLevel = PlayerPrefs.GetInt("maxLevel");
        if (!PlayerPrefs.HasKey("Save") && languagePanel != null) 
        {
            languagePanel.SetActive( true );
            settingsPanel.SetActive( true );
        }
        else
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));
            scriptMenuFlag.selectedLanguage = sv.Language;
            scriptButtonPlay.selectedLanguage = sv.Language;
            scriptButtonSettings.selectedLanguage = sv.Language;
            scriptButtonLevels.selectedLanguage = sv.Language;
            scriptButtonExit.selectedLanguage = sv.Language;
            scriptButtonSkins.selectedLanguage = sv.Language;
            scriptButtonComplexity.selectedLanguage = sv.Language;
            scriptButtonEasy.selectedLanguage = sv.Language;
            scriptButtonAverage.selectedLanguage = sv.Language;
            scriptButtonDifficult.selectedLanguage = sv.Language;
        }
        if (maxLevel < 1)
        {
            maxLevel = 1;
        }
    }

    public void CheckLanguage(string Language)
    {
        PlayerPrefs.DeleteKey(sv.Language);
        sv.Language = scriptMenuFlag.selectedLanguage;
    }

    public void OnApplicationQuit()
    {
        if (PlayerPrefs.HasKey("numberOutputs"))
        {
            numberOutputs = PlayerPrefs.GetInt("numberOutputs");
        }
        else
        {
            PlayerPrefs.SetInt("numberOutputs", 0);
        }
        if (numberOutputs >= 5)  {PlayerPrefs.SetInt("numberOutputs", 0);}
        else  {PlayerPrefs.SetInt("numberOutputs", numberOutputs ++);}/// Set устанавливает а Get возвращает
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
    }

    public void SaveData()
    {
        // PlayerPrefs.SetInt("maxLevel", maxLevel);
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
    }

[Serializable]
public class Save
{
    public string Language;
}
}