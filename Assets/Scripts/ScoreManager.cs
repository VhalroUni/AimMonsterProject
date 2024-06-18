using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;
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

    public void AddScore(int points)
    {
        score += points;
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        PlayerPrefs.Save();
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public int GetCurrentScore()
    {
        return score;
    }

    void UpdateScoreDisplay()
    {
        highScoreText.text = "High Score: " + GetHighScore().ToString();
        currentScoreText.text = "Score: " + GetCurrentScore().ToString();
    }
}
