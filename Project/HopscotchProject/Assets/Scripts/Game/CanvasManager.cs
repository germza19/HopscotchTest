using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTMP;

    [SerializeField] CanvasGroup gameOverPanel;

    public void Awake()
    {
        SetGameOverCanvasGroup(false);
    }

    public void UpdateScoreUGUI(int score)
    {
        scoreTMP.text = score.ToString();
    }

    public void SetGameOverCanvasGroup(bool value)
    {
        SetCanvasGroupVisible(gameOverPanel, value);
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
}
