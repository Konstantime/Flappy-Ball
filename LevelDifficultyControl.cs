using UnityEngine;

public class LevelDifficultyControl : MonoBehaviour
{
    private string m_difficultyLevel;

    void Start()
    {
        m_difficultyLevel = PlayerPrefs.GetString( "DifficultyLevel" );
        switch ( m_difficultyLevel )
        {
            case "Easy":
                GameObject.Find( "Average" ).SetActive( false );
                GameObject.Find( "Difficult" ).SetActive( false );
                break;
            case "Average":
                GameObject.Find( "Average" ).SetActive( true );
                GameObject.Find( "Difficult" ).SetActive( false );
                break;
            case "Difficult":
                GameObject.Find( "Average" ).SetActive( true );
                GameObject.Find( "Difficult" ).SetActive( true );
                break;
        }
    }
}