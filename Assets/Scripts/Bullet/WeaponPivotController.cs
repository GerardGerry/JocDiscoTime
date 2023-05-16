using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class WeaponPivotController : MonoBehaviour
{

    public Transform pivot;
    public float rotationSpeed = 0f;

    private Vector3 mousePos;

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = mousePos - pivot.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        pivot.rotation = Quaternion.Slerp(pivot.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
    }

}