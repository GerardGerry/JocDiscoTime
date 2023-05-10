using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class WeaponPivotController : MonoBehaviour
{
    float _angle;
    Vector2 _input;
    Vector2 _lastInput;
    Transform _transform;


    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        PivotRotate();
    }

    public void SetInput(InputValue value)
    {
        _lastInput = _input;
        _input = value.Get<Vector2>();
    }

    void PivotRotate()
    {
        /*Transform transform = GetComponent<Transform>();
        _angle = Vector2.Angle(Vector2.right, _input);
        if (_input.y <= 0)
        {
            _angle = 360 - _angle;
        }
        transform.localEulerAngles = new Vector3(0, 0, _angle);*/
        Vector2 rotationInput = _lastInput != Vector2.zero ? _lastInput : _input;
        _angle = Vector2.Angle(Vector2.right, rotationInput);
        if (rotationInput.y <= 0)
        {
            _angle = 360 - _angle;
        }
        _transform.localEulerAngles = new Vector3(0, 0, _angle);
    }
}