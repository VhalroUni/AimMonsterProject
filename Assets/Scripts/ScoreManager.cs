using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score;
    public TMP_Text highScoreText;
    public TMP_Text currentScoreText;

    void Start()
    {
        UpdateScoreDisplay();
    }

    void Update()
    {
        UpdateScoreDisplay();
    }

    public void SetScore(float newScore)
    {
        score = newScore;
        if (score > GetHighScore())
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
        PlayerPrefs.Save();
    }

    public float GetHighScore()
    {
        return PlayerPrefs.GetFloat("HighScore", 0f);
    }

    public float GetCurrentScore()
    {
        return score;
    }

    void UpdateScoreDisplay()
    {
        highScoreText.text = "High Score: " + TimeSpan.FromSeconds(GetHighScore()).ToString("mm':'ss':'ff");
        currentScoreText.text = "Score: " + TimeSpan.FromSeconds(GetCurrentScore()).ToString("mm':'ss':'ff");
    }
}
