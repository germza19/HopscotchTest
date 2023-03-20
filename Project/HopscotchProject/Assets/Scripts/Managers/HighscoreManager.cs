using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public List<HighscoreElement> highscoreList = new List<HighscoreElement>();
    [SerializeField] int maxCount = 5;
    [SerializeField] string filename;

    private void Awake()
    {
        LoadHighscores();
    }

    private void LoadHighscores()
    {
        highscoreList = FileHandler.ReadListFromJSON<HighscoreElement>(filename);

        while(highscoreList.Count > maxCount)
        {
            highscoreList.RemoveAt(maxCount);
        }
    }

    public void SaveHighscores()
    {
        FileHandler.SaveToJSON<HighscoreElement> (highscoreList, filename);
    }

    public void AddHighscoreIfPossible(HighscoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if(i >= highscoreList.Count || element.points > highscoreList[i].points)
            {
                highscoreList.Insert(i,element);

                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }

                SaveHighscores();

                break;
            }
        }
    }
}
