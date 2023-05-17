using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float maxX = 0.1f;
    [SerializeField]
    float maxY = 10;
    [SerializeField]
    float minX = 0.1f;
    [SerializeField]
    float minY = 10;
    [SerializeField]
    float Speed = 1;
    Vector2 dir = new Vector2(0, 1);



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpAndDown();
    }
        
    private void MoveUpAndDown()
    {
        if (transform.position.y >= maxY)
        {
            dir = new Vector2(0, -1);
            //Speed = -Mathf.Abs(Speed);
        }

        if (transform.position.y <= minY)
        {
            dir = new Vector2(0, 1);
            //Speed = -Mathf.Abs(Speed);
        }
        transform.Translate(dir * Speed * Time.deltaTime, Space.World);

    }
}
