using UnityEngine;

public class EducationSkins : MonoBehaviour
{
    public bool m_trainingInProgress = false;
    [SerializeField] private EducationHand ScriptEducationHand1;
    [SerializeField] private EducationHand ScriptEducationHand2;
    private bool m_renderEducationHand;
    private int m_maxLevel;
    void Start()
    {
        m_maxLevel = PlayerPrefs.GetInt("maxLevel");
        if( m_maxLevel < 1 ) m_maxLevel = 1;
        switch ( m_maxLevel )
        {
            case 1:
                if( !PlayerPrefs.HasKey( "CompletedEducationSkinLevel1" ) )
                {
                    m_renderEducationHand = true;
                    ScriptEducationHand1.DisableEnableRender( m_renderEducationHand );
                    m_trainingInProgress = true;
                    Debug.Log( "ASHFTYh1" );
                }
                break;
            case 2:
                if( !PlayerPrefs.HasKey( "CompletedEducationSkinLevel2" ) )
                {
                    m_renderEducationHand = true;
                    ScriptEducationHand1.DisableEnableRender( m_renderEducationHand );
                    m_trainingInProgress = true;
                    Debug.Log( "ASHFTYh2" );
                }
                break;
            case 3:
                if( !PlayerPrefs.HasKey( "CompletedEducationSkinLevel3" ) )
                {
                    m_renderEducationHand = true;
                    ScriptEducationHand1.DisableEnableRender( m_renderEducationHand );
                    m_trainingInProgress = true;
                    Debug.Log( "ASHFTYh3" );
                }
                break;
            case 4:
                if( !PlayerPrefs.HasKey( "CompletedEducationSkinLevel4" ) )
                {
                    m_renderEducationHand = true;
                    ScriptEducationHand1.DisableEnableRender( m_renderEducationHand );
                    m_trainingInProgress = true;
                    Debug.Log( "ASHFTYh4" );
                }
                break;
            case 5:
                if( !PlayerPrefs.HasKey( "CompletedEducationSkinLevel5" ) )
                {
                    m_renderEducationHand = true;
                    ScriptEducationHand1.DisableEnableRender( m_renderEducationHand );
                    m_trainingInProgress = true;
                    Debug.Log( "ASHFTYh5" );
                }
                break;
        }
    }

    public void PressedButtonPanelLevels()
    {
        m_renderEducationHand = false;
        ScriptEducationHand1.DisableEnableRender( m_renderEducationHand );
        // m_renderEducationHand = true;
        // ScriptEducationHand2.DisableEnableRender( m_renderEducationHand );
    }

    public void CompleteTheTraining()
    {
        if( m_trainingInProgress == true )
        {
            m_trainingInProgress = false;
            switch ( m_maxLevel )
            {
                case 1:
                    PlayerPrefs.SetString( "CompletedEducationSkinLevel1", "true" );
                    break;
                case 2:
                    PlayerPrefs.SetString( "CompletedEducationSkinLevel2", "true" );
                    break;
                case 3:
                    PlayerPrefs.SetString( "CompletedEducationSkinLevel3", "true" );
                    break;
                case 4:
                    PlayerPrefs.SetString( "CompletedEducationSkinLevel4", "true" );
                    break;
                case 5:
                    PlayerPrefs.SetString( "CompletedEducationSkinLevel5", "true" );
                    break;
            }
            PlayerPrefs.Save();
        }
    }

    public void DisableRenderEducationHand1()
    {
        m_renderEducationHand = false;
        ScriptEducationHand1.DisableEnableRender( m_renderEducationHand );
    }

    public void DisableRenderEducationHand2()
    {
        m_renderEducationHand = false;
        ScriptEducationHand2.DisableEnableRender( m_renderEducationHand );
    }

    public void TurnOnRenderEducationHand2()
    {
        Debug.Log( "TurnOn" );
        if( m_trainingInProgress == true )
        {
            m_renderEducationHand = true;
            ScriptEducationHand2.DisableEnableRender( m_renderEducationHand );
        }
    }
}
