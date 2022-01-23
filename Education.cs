using UnityEngine;

public class Education : MonoBehaviour
{
    [SerializeField] private PlayerController ScriptPlayer;
    [SerializeField] private EducationHand ScriptEducationHand;
    private bool m_renderEducationHand;
    private int m_showHand = -1;

    void Start()
    {
        if ( !PlayerPrefs.HasKey( "EducationGameplay" ) )
        {
            m_renderEducationHand = true;
            ScriptEducationHand.DisableEnableRender( m_renderEducationHand );
            m_showHand = 0;
        }
    }

    public void DisableHand()//касание экрана
    {
        if( m_showHand == 0 )
        {
            m_showHand = 1;
            m_renderEducationHand = false;
            ScriptEducationHand.DisableEnableRender( m_renderEducationHand );
        }
        else if( m_showHand == 2 )
        {
            m_showHand = 3;
            m_renderEducationHand = false;
            ScriptEducationHand.DisableEnableRender( m_renderEducationHand );
            PlayerPrefs.SetString( "EducationGameplay", "true" );
            PlayerPrefs.Save();
        }
    }

    public void Update()
    {
        if ( m_showHand == 1 && transform.position.y >= 2 )
        {
            m_showHand = 2;
            ScriptPlayer.StopMove();
            ScriptPlayer.Gravity *= -1;
            m_renderEducationHand = true;
            ScriptEducationHand.DisableEnableRender( m_renderEducationHand );
        }
    }
}