using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public bool isGameOver;
    [SerializeField] CanvasManager canvasManager;

    private void Start()
    {
        isGameOver = false;
    }
    public void GameOver()
    {
        Debug.Log("GameOver");
        isGameOver = true;
        canvasManager.SetGameOverCanvasGroup(true);
        Time.timeScale = 0;
    }

    public void IncreaseScore()
    {
        score++;
        canvasManager.UpdateScoreUGUI(score);
    }
}
