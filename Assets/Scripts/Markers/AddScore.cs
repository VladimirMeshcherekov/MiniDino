using UnityEngine;
using UnityEngine.Serialization;

public class AddScore : MonoBehaviour
{
    public int scoreValue;

    private void OnValidate()
    {
        if (scoreValue < 0)
        {
            scoreValue = 0;
        }
    }
}