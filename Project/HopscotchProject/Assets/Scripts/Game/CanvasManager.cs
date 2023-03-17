using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTMP;

    [SerializeField] CanvasGroup gameOverPanelCG;
    [SerializeField] CanvasGroup gamePausedPanelCG;

    private GameManager gameManager;

    public void Awake()
    {
        SetGameOverCanvasGroup(false);
        SetGamePausedCanvasGroup(false);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void UpdateScoreUGUI(int score)
    {
        scoreTMP.text = score.ToString();
    }

    public void SetGameOverCanvasGroup(bool value)
    {
        SetCanvasGroupVisible(gameOverPanelCG, value);
    }
    public void SetGamePausedCanvasGroup(bool value)
    {
        SetCanvasGroupVisible(gamePausedPanelCG, value);
    }
    private void SetCanvasGroupVisible(CanvasGroup canvas, bool value)
    {
        canvas.blocksRaycasts = value;
        canvas.interactable = value;
        if(value)
        {
            canvas.alpha = 1f;
        }
        else
        {
            canvas.alpha = 0f;
        }
    }

    public void OnPauseButton()
    {
        gameManager.PauseGame();
    }
    public void OnHighScoreButton()
    {
        //TODO : pause and show higscores
    }

    public void OnResumeButton()
    {
        gameManager.ResumeGame(); // resume after 3 seconds
    }

    public void OnReplayButton()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OnExitButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
