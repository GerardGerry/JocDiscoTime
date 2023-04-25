using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverByForce : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    [SerializeField]
    Transform _target;
    [SerializeField]
    float _force, _speed;

    // Start is called before the first frame update
    void Start()
    {
     _rigidBody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector2 dir = (_target.position - transform.position);
        float distance = dir.magnitude;
        dir = dir.normalized;
        dir *= (_force * (distance));
       //_rigidBody.AddForce(dir * _force, ForceMode2D.Force);

        _rigidBody.velocity = dir * _speed;
    }
}
