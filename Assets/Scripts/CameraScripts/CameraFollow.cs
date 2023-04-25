using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPosition;

    [SerializeField]
    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        tempPosition = transform.position;

        tempPosition.x = player.position.x;
        tempPosition.y = player.position.y;
        CheckMapBorders();
        
        transform.position = tempPosition;
    }

    private void CheckMapBorders()
    {
        if (tempPosition.x < minX)
        {
            tempPosition.x = minX;
        }
        else if (tempPosition.x > maxX)
        {
            tempPosition.x = maxX;
        }
        if (tempPosition.y < minY)
        {
            tempPosition.y = minY;
        }
        else if (tempPosition.y > maxY)
        {
            tempPosition.y = maxY;
        }
    }
}
