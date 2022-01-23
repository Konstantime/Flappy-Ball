using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour
{ 
    public SlectedLanguage scriptMenuFlag;
    public SlectedLanguage scriptButtonPlay;
    public SlectedLanguage scriptButtonSettings;
    public SlectedLanguage scriptButtonLevels;
    public SlectedLanguage scriptButtonExit;
    public SlectedLanguage scriptButtonSkins;
    public string language;

    public void changeLanguage()
    {
        scriptMenuFlag.selectedLanguage = language;
        scriptButtonPlay.selectedLanguage = language;
        scriptButtonSettings.selectedLanguage = language;
        scriptButtonLevels.selectedLanguage = language;
        scriptButtonExit.selectedLanguage = language;
        scriptButtonSkins.selectedLanguage = language;
        PlayerPrefs.GetString("selectedLanguage");
        PlayerPrefs.SetString("selectedLanguage", language);
        PlayerPrefs.Save();
    }
}
