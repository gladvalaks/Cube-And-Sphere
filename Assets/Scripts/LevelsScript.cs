using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsScript : MonoBehaviour
{
    public TextAsset dataJson;
    public LevelsList levelList;
    public int curentLevel;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
        }
        curentLevel = PlayerPrefs.GetInt("Level");
        Debug.Log(curentLevel);
        levelList = JsonUtility.FromJson<LevelsList>(dataJson.text);
        DontDestroyOnLoad(this.gameObject);
        GoToGame();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void GoToNextLevel()
    {
        int level = PlayerPrefs.GetInt("Level");
        level += 1;
        curentLevel = level;
        PlayerPrefs.SetInt("Level", level);
        GoToGame();
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public string GetLevel()
    {
        return levelList.levels[curentLevel].levelString;
    }
    [ContextMenu("DeletePlayerPrefs")]
    public void deletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}

[Serializable]
public class Level
{
    public int levelId;
    public string levelString;
}
[Serializable]
public class LevelsList
{
    public Level[] levels;
}
