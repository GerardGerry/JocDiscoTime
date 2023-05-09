using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float speed = 20;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        SetVelocity();
    }

    private void SetVelocity()
    {
        _rigidbody.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
