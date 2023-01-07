using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;

    private Vector2 _firstPos;
    private Vector2 _secondPos;
    public Vector2 _currentPos;

    public float _speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Swipe();
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
            rb.velocity = Vector3.back * _speed;
        }
        else if (_currentPos.y > 0 && _currentPos.x > -0.5f && _currentPos.x < 0.5f)
        {
            // Forward
            rb.velocity = Vector3.forward * _speed;
        }
        else if (_currentPos.x < 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {
            // Left 
            rb.velocity = Vector3.left * _speed;
        }
        else if (_currentPos.x > 0 && _currentPos.y > -0.5f && _currentPos.y < 0.5f)
        {
            // Right
            rb.velocity = Vector3.right * _speed;
        }

    }

}