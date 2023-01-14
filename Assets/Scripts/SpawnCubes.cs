using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SpawnCubes : MonoBehaviour
{
    
    
    [TextArea]
    public string TextCubesLocation;
    public CubeManager cubeManager;
    public LevelsScript levelsScript;
    public CameraScript cameraScript;
    public GameObject cubePrefab;
    public GameObject playerPrefab;
    public Color color;

    private void Awake()
    {
        levelsScript = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelsScript>();
        cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
    }
    void Start()
    {
        
        TextCubesLocation = levelsScript.GetLevel();
        color = levelsScript.GetColor();
        cubeManager = GetComponent<CubeManager>();
        SpawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObjects()
    {
        List<string> cubes = new List<string>(TextCubesLocation.Split());
        float basePosX = cubes[0].Length / 2f;
        float basePosY = cubes.Count / 2f;
        cameraScript.SetCameraSize(basePosX * 2);
        for (int i = 0; i < cubes.Count; i++)
        {
            for (int j = 0; j < cubes[0].Length; j++)
            {
                int indexOfGameObject = int.Parse(cubes[i][j].ToString());
                GameObject obj = null;
                if (indexOfGameObject == 1)
                {
                    obj = Instantiate(cubePrefab, this.gameObject.transform);
                    obj.GetComponent<Renderer>().material.color = color;

                }
                else if(indexOfGameObject == 2)
                {
                    obj = Instantiate(playerPrefab, this.gameObject.transform);
                    cubeManager.cubesCount += 1;
                    GameObject cube = Instantiate(cubePrefab,this.gameObject.transform);
                    cube.transform.position = new Vector3(-basePosX + j, 0, basePosY - i);
                }
                if (indexOfGameObject != 0)
                {
                    obj.transform.position = new Vector3(-basePosX + j, 1, basePosY - i);
                }
                else
                {
                    GameObject cube = Instantiate(cubePrefab, this.gameObject.transform);
                    cube.transform.position = new Vector3(-basePosX + j, 0, basePosY - i);
                    cubeManager.cubesCount += 1;
                }
            }
            
        }
        this.transform.position = new Vector3 (0,1,-0.5f);

    }
}

