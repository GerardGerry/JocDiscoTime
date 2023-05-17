using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverByForce : MonoBehaviour
{

    Rigidbody2D _rigidbody;

    [SerializeField]
    Transform _target;

    [SerializeField]
    float _force;

    [SerializeField]
    float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector2 dir = (_target.position - transform.position).normalized;
        float distance = dir.magnitude;
        dir = dir.normalized;
        dir *= (_force * (distance));
        // _rigidbody.AddForce(dir, ForceMode2D.Force);

        _rigidbody.velocity = dir * _speed;

    }
}
