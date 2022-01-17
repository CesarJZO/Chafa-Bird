using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{

    public int score = 0;
    public Text scoreText;

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void ResetScore()
    {
        score = 0;
        scoreText.text = "0";
    }
}
