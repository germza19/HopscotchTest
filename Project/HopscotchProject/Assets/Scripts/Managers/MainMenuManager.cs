using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnExitButton()
    {
        Application.Quit();
    }
    public void OnPlayButton()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void OnHighScoreButton()
    {
        //TODO : pause and show higscores
    }
}
