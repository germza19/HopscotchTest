using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject exitButton;
    public void OnExitButton()
    {
        Application.Quit();
    }
    public void OnPlayButton()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void HideOrShowButton(bool value)
    {
        exitButton.SetActive(value);
    }
    private void Awake()
    {
        HideOrShowButton(false);
    }

    private void Start()
    {
#if UNITY_STANDALONE_WIN
        HideOrShowButton(true);
#endif
    }
}
