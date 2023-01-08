
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public int cubesCount = 0;
    public LevelsScript LevelsScript;

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
            LevelsScript.GoToNextLevel();
        }
    }
}
