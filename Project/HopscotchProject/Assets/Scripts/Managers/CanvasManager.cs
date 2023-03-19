using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] TextMeshProUGUI highscoreTMP;

    [SerializeField] CanvasGroup gameOverPanelCG;
    [SerializeField] CanvasGroup gamePausedPanelCG;
    [SerializeField] CanvasGroup pauseMenuButtonsCG;

    [SerializeField] CanvasGroup HighscoresListPanelCG;

    [SerializeField] TextMeshProUGUI countDownTimerText;
    [SerializeField] GameObject pauseTextGO;
    [field: SerializeField] public GameObject countDownTimerTextGO { get; private set; }

    private GameManager gameManager;

    public void Awake()
    {
        SetGameOverCanvasGroup(false);
        SetGamePausedCanvasGroup(false);
        gameManager = FindObjectOfType<GameManager>();

        pauseTextGO.SetActive(true);
        countDownTimerTextGO.SetActive(false);
    }

    public void UpdateScoreUGUI(int score)
    {
        scoreTMP.text = score.ToString();
    }
    public void UpdateHighscoreUGUI(int score)
    {
        highscoreTMP.text = score.ToString();
    }
    public void UpdateResumeTimer(float timer, float totalTime)
    {

        int timerInt = (int)(totalTime - timer);
        countDownTimerText.text = timerInt.ToString();
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
        SetCanvasGroupVisible(pauseMenuButtonsCG, true);
        pauseTextGO.SetActive(true);
        countDownTimerTextGO.SetActive(false);
        gameManager.PauseGame();
    }
    public void OnHighScoreButton()
    {
        //TODO : pause and show higscores
        pauseTextGO.SetActive(true);
        countDownTimerTextGO.SetActive(false);
        gameManager.PauseGame();
    }

    public void OnResumeButton()
    {
        pauseTextGO.SetActive(false);
        SetCanvasGroupVisible(pauseMenuButtonsCG, false);
        countDownTimerTextGO.SetActive(true);
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
