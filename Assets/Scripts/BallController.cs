using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;

    private Vector2 _firstPos;
    private Vector2 _secondPos;
    public Vector2 _currentPos;
    public Vector3 movement;
    public GameObject moveToBlock = null;
    public bool isMoving = false;
    public float _speed;
    public Vector3 previousTransform;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Vector3 positionNow = this.transform.position;
        if (Mathf.Abs(positionNow.magnitude - previousTransform.magnitude) < 0.02f)
        {
            Swipe();
        }
        Move();
        previousTransform = positionNow;
    }


    private void Swipe()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }

        if (Input.GetMouseButtonUp(0))
        {
            _secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            _currentPos = new Vector2(
                _secondPos.x - _firstPos.x,
                _secondPos.y - _firstPos.y
            );
        }

        _currentPos.Normalize();

        if (_currentPos.y < 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f)
        {
            //  Back
            movement = Vector3.back;
        }
        else if (_currentPos.y > 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f)
        {
            // Forward
            movement = Vector3.forward;
        }
        else if (_currentPos.x < 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {
            // Left 
            movement = Vector3.left;
        }
        else if (_currentPos.x > 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {
            // Right
            movement = Vector3.right;
        }
    }
    void Move()
    {
        rb.velocity = movement * _speed;
    }

}