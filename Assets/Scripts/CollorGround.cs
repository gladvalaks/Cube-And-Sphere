using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorGround : MonoBehaviour
{
    public CubeManager cubeManager;
    public Color groundColor;
    Ray ray;
    RaycastHit hit;
    
    void Start()
    {
        groundColor = RandomColor();
        cubeManager = GameObject.FindGameObjectWithTag("CubeManager").GetComponent<CubeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(this.transform.position, new Vector3(0,-10,0));
        if (Physics.Raycast(ray, out hit, 0.7f))
        {
            if (hit.transform.gameObject.GetComponent<Renderer>().material.color != groundColor)
            {
                hit.transform.gameObject.GetComponent<Renderer>().material.color = groundColor;
                cubeManager.CubeCollored();
            }
        }
       
    }
    Color RandomColor()
    {
        return new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 0f);
    }
}
