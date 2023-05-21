using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class WeaponPivotControllerEnemy : MonoBehaviour
{
    private GameObject player;
    public Transform pivot;
    public float rotationSpeed = 0f;

    private Vector3 mousePos;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        Vector3 dir = player.transform.position - pivot.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        pivot.rotation = Quaternion.Slerp(pivot.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
    }

}