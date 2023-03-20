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

    //[SerializeField] CanvasGroup highscoresListPanelCG;
    [SerializeField] Transform highscoresParent;
    [SerializeField] GameObject highscoreUIPrefab;

    List<GameObject> highscoresUIElements = new List<GameObject>();

    [SerializeField] TextMeshProUGUI countDownTimerText;
    [SerializeField] GameObject pauseTextGO;
    [field: SerializeField] public GameObject countDownTimerTextGO { get; private set; }

    private GameManager gameManager;

    private void Awake()
    {
        SetGameOverCanvasGroup(false);
        SetGamePausedCanvasGroup(false);
        gameManager = FindObjectOfType<GameManager>();

        pauseTextGO.SetActive(true);
        countDownTimerTextGO.SetActive(false);
    }

    private void Start()
    {
        UpdateHighscores(gameManager.highscoreManager.highscoreList);
        ShowHighscoresList(false);
    }

    public void UpdateScoreUGUI(int score)
    {
        scoreTMP.text = score.ToString();
    }

    public void ShowHighscoresList(bool value)
    {
        for (int i = 0; i < highscoresUIElements.Count; i++)
        {
            if (i == 0)
            {
                highscoresUIElements[i].GetComponent<CanvasGroup>().alpha = 1f;
            }
            else
            {
                if(value)
                {
                    highscoresUIElements[i].GetComponent<CanvasGroup>().alpha = 0.6f;
                }
                else
                {
                    highscoresUIElements[i].GetComponent<CanvasGroup>().alpha = 0f;
                }                
            }
        }
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
        if(!gameManager.isGameOver)
        {
            ShowHighscoresList(false);
            SetCanvasGroupVisible(pauseMenuButtonsCG, true);
            pauseTextGO.SetActive(true);
            countDownTimerTextGO.SetActive(false);
            gameManager.PauseGame();
        }

    }
    public void OnHighScoreButton()
    {
        UpdateHighscores(gameManager.highscoreManager.highscoreList);
        ShowHighscoresList(true);
        if (!gameManager.isGameOver)
        {
            pauseTextGO.SetActive(true);
            countDownTimerTextGO.SetActive(false);
            gameManager.PauseGame();
        }
    }

    public void UpdateHighscores(List<HighscoreElement> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            HighscoreElement element = list[i];

            if(element.points > 0)
            {
                if(i >= highscoresUIElements.Count)
                {
                    var inst = Instantiate(highscoreUIPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(highscoresParent.transform,false);

                    highscoresUIElements.Add(inst);
                }

                var text = highscoresUIElements[i].GetComponentInChildren<TextMeshProUGUI>();
                text.text = element.points.ToString();
            }
        }
    }

    public void OnResumeButton()
    {
        pauseTextGO.SetActive(false);
        SetCanvasGroupVisible(pauseMenuButtonsCG, false);
        ShowHighscoresList(false);
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
