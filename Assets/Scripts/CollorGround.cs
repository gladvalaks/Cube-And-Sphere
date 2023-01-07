using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorGround : MonoBehaviour
{
    public Color groundColor;
    Ray ray;
    RaycastHit hit;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(this.transform.position, new Vector3(0,-10,0));
        if(Physics.Raycast(ray,out hit,0.7f))
        hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_Color", groundColor);
        Debug.DrawRay(transform.position, new Vector3(0, -10, 0), Color.green);
    }
}
