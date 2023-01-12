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
<<<<<<< HEAD
        
=======
>>>>>>> 57710bb2b159bcfc9526e54de4d258ff82b490e8
        if (!PlayerPrefs.HasKey("MaxLevel"))
        {
            PlayerPrefs.SetInt("MaxLevel", 0);
        }
        curentLevel = PlayerPrefs.GetInt("Level");
        levelList = JsonUtility.FromJson<LevelsList>(dataJson.text);
        DontDestroyOnLoad(this.gameObject);
        
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
    public void GoToCurrentLevel(int lvl)
    {
        curentLevel = lvl;
        GoToGame();
    }
    public void GoToGame()
    {
        if (PlayerPrefs.GetInt("MaxLevel") < curentLevel)
        {
            PlayerPrefs.SetInt("MaxLevel", curentLevel);
        }
        SceneManager.LoadScene("GameScene");
    }
    public string GetLevel()
    {
        return levelList.levels[curentLevel].levelString;
    }
    public Color GetColor()
    {
        var col = levelList.levels[curentLevel].color;
<<<<<<< HEAD
        return new Color(col[0], col[1], col[2]);
=======
        return new Color(col[0],col[1],col[2]);
>>>>>>> 57710bb2b159bcfc9526e54de4d258ff82b490e8
    }
    [ContextMenu("DeletePlayerPrefs")]
    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}

[Serializable]
public class Level
{
    public int levelId;
    public string levelString;
    public int[] color;
}
[Serializable]
public class LevelsList
{
    public Level[] levels;
}
