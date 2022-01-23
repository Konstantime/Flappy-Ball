using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public void ResetMaxlevel()
    {
        PlayerPrefs.DeleteKey ( "maxLevel" ); 
        PlayerPrefs.DeleteKey ( "CompletedEducationSkinLevel1" );
        PlayerPrefs.DeleteKey ( "CompletedEducationSkinLevel2" );
        PlayerPrefs.DeleteKey ( "CompletedEducationSkinLevel3" );
        PlayerPrefs.DeleteKey ( "CompletedEducationSkinLevel4" );
        PlayerPrefs.DeleteKey ( "CompletedEducationSkinLevel5" );
        PlayerPrefs.Save();
    }
}
