using UnityEngine;

public class ButtonComplexity : MonoBehaviour
{
    public void SelectDifficulty( string DifficultyLevel )
    {
        PlayerPrefs.SetString( "DifficultyLevel", DifficultyLevel );
    }
}
