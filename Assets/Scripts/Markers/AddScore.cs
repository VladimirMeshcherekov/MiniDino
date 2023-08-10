using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int scoreToAdd;

    private void OnValidate()
    {
        if (scoreToAdd < 0)
        {
            scoreToAdd = 0;
        }
    }
}