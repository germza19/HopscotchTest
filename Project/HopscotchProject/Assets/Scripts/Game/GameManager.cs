using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score { get; private set; }
    public bool isGameOver { get; private set; }
    public bool isGamePaused { get; private set; }
    [SerializeField] CanvasManager canvasManager;
    private PlayerManager playerManager;

    [SerializeField] float resumeTime;
    private float waitCounter;

    public void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }
    public void Update()
    {
        if(canvasManager.countDownTimerTextGO.activeSelf)
        {
            canvasManager.UpdateResumeTimer(waitCounter, resumeTime);
        }
    }
    private void Start()
    {
        Time.timeScale = 1;
        isGameOver = false;
        isGamePaused = false;

        waitCounter = 0;
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
