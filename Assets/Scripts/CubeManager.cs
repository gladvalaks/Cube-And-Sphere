
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    public int cubesCount = 0;
    public LevelsScript LevelsScript;
    [SerializeField] GameObject WinPanel;

    void Awake()
    {
        WinPanel.SetActive(false);
    }
    void Start()
    {
        
        LevelsScript = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelsScript>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CubeCollored()
    {
        cubesCount -= 1;
        if (cubesCount == 0)
        {
            WinPanel.SetActive(true);
           // LevelsScript.GoToNextLevel();
        }
    }

    public void Nextlevel()
    {
        LevelsScript.GoToNextLevel();
    }
        

}
