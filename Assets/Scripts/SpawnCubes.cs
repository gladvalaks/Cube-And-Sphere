using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnCubes : MonoBehaviour
{
    [TextArea]
    public string TextCubesLocation;
    public GameObject cubePrefab;
    public GameObject playerPrefab;

    void Start()
    {
       
        SpawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("Spawn Objects")]
    void SpawnObjects()
    {
        List<string> cubes = new List<string>(TextCubesLocation.Split());
        float basePosX = cubes[0].Length / 2f;
        float basePosY = cubes.Count / 2f;
        for (int i = 0; i < cubes.Count; i++)
        {
            for (int j = 0; j < cubes[0].Length; j++)
            {
                GameObject cube = Instantiate(cubePrefab);
                Undo.RegisterCreatedObjectUndo(cube, "Object");
                cube.transform.position = new Vector3(-basePosX + j, 0, basePosY - i);
            }
        }
        for (int i = 0; i < cubes.Count; i++)
        {
            for (int j = 0; j < cubes[0].Length; j++)
            {
                int indexOfGameObject = int.Parse(cubes[i][j].ToString());
                GameObject obj = null;
                if (indexOfGameObject == 1)
                {
                    obj = Instantiate(cubePrefab);
                    
                }
                else if(indexOfGameObject == 2)
                {
                    obj = Instantiate(playerPrefab);
                }
                if (indexOfGameObject != 0)
                {
                    Undo.RegisterCreatedObjectUndo(obj,"Object");
                    obj.transform.position = new Vector3(-basePosX + j, 1, basePosY - i);
                }
            }
        }
        
    }
}
