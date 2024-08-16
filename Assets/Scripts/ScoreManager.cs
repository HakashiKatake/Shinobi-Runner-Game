using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    public Text scoreText;
    public float scoreIncreaseInterval = 1.0f; // Interval in seconds

    void Start()
    {
        UpdateScoreText();
        StartCoroutine(IncreaseScoreOverTime());
    }

    IEnumerator IncreaseScoreOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(scoreIncreaseInterval);
            IncreaseScore();
        }
    }

    public void IncreaseScore()
    {
        GameManager.instance.IncreaseScore(1);
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.score;
    }
}
