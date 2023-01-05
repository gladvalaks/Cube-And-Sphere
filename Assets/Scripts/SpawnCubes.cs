using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [TextArea]
    public string TextCubesLocation;
    public GameObject cubePrefab;
    
    void Start()
    {
        List<string> cubes = new List<string>(TextCubesLocation.Split());
        SpawnObjects(cubes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObjects(List<string> cubes)
    {
        float basePosX = cubes[0].Length / 2f;
        float basePosY = cubes.Count / 2f;
        for (int i = 0; i < cubes.Count; i++)
        {
            for (int j = 0; j < cubes[0].Length; j++)
            {
                GameObject cube = Instantiate(cubePrefab);
                cube.transform.position = new Vector3(-basePosX + j, 0, basePosY - i);
            }
        }
        for (int i = 0; i < cubes.Count; i++)
        {
            for (int j = 0; j < cubes[0].Length; j++)
            {
                if(int.Parse(cubes[i][j].ToString()) == 1)
                {
                    GameObject cube = Instantiate(cubePrefab);
                    cube.transform.position = new Vector3(-basePosX + j, 1, basePosY - i);
                }
            }
        }
        
    }
}
