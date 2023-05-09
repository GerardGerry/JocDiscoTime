using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class WeaponPivotController : MonoBehaviour
{
    float _angle;
    Vector2 _input;

    /*private void Update()
    {
        PivotRotate();
    }*/

    public void SetInput(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    /*void PivotRotate()
    {
        _angle = Vector2.Angle(Vector2.right, _input);
        transform.rotation(_angle);
    }*/
}