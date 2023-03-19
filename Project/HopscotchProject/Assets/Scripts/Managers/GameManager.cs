using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasManager canvasManager;
    private PlayerManager playerManager;
    public bool isGameOver { get; private set; }
    public bool isGamePaused { get; private set; }

    [SerializeField] float resumeTime;
    private float waitCounter;

    public int score { get; private set; }
    private HighscoreManager highscoreManager;
    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        highscoreManager = GetComponent<HighscoreManager>();
    }
    private void Start()
    {
        Time.timeScale = 1;
        isGameOver = false;
        isGamePaused = false;

        waitCounter = 0;
        canvasManager.UpdateHighscoreUGUI(highscoreManager.highscore);
    }
    public void Update()
    {
        if(canvasManager.countDownTimerTextGO.activeSelf)
        {
            canvasManager.UpdateResumeTimer(waitCounter, resumeTime);
        }
    }
    public void GameOver()
    {
        Debug.Log("GameOver");
        isGameOver = true;
        highscoreManager.SetHighscoreIfGreater(score);
        canvasManager.UpdateHighscoreUGUI(highscoreManager.highscore);
        canvasManager.SetGameOverCanvasGroup(true);
        Time.timeScale = 0;
    }

    public void IncreaseScore()
    {
        score++;
        canvasManager.UpdateScoreUGUI(score);
    }

    public void PauseGame()
    {
        
        isGamePaused = true;
        playerManager.animator.SetBool("Paused", true);
        canvasManager.SetGamePausedCanvasGroup(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        StartCoroutine(WaitToResume());
    }

    IEnumerator WaitToResume()
    {
        waitCounter = 0;
        while (waitCounter < resumeTime)
        {
            waitCounter += Time.unscaledDeltaTime;
            
            yield return null;
        }

        isGamePaused = false;
        playerManager.animator.SetBool("Paused", false);
        canvasManager.SetGamePausedCanvasGroup(false);
        Time.timeScale = 1;
        waitCounter = 0;

    }
}
