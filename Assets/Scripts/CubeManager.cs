
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public int cubesCount = 0;

    void Start()
    {

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
            Debug.Log("Уровень пройден");
        }
    }
}
