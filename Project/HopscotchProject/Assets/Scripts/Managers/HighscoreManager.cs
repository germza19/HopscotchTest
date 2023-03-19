using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public int highscore { get; private set; }

    private void Awake()
    {
        SetLatestHighscore();
    }

    private void SetLatestHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    private void SaveHighscore(int score)
    {
        PlayerPrefs.SetInt("Highscore", score);
    }
    public void SetHighscoreIfGreater(int newScore)
    {
        if(newScore > highscore)
        {
            highscore = newScore;
            SaveHighscore(newScore);
        }
    }
}
