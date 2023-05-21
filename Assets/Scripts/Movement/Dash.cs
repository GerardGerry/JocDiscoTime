using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Dash : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    Animator _animator;
    Vector2 _input;

    [SerializeField] private float _dashingPower = 20f;
    [SerializeField] private float _dashingCooldown = 1f;

    float timer = 0f;
    bool canDash = true;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer < _dashingCooldown)
        {
            timer = timer + Time.deltaTime;
        }      
        if (timer >= _dashingCooldown)
        {
            timer = 0;
            canDash = true;
        }
    }

    public void MakeDash(Vector2 input)
    {
        if(canDash)
        {
            canDash = false;
            _animator.SetTrigger("Roll");

            
            Vector2 playerDash = input.normalized * _dashingPower;
            _rigidBody.velocity = playerDash;
        }      
        
    }
}
