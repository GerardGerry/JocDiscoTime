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

    //[Header("Dash")]
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

        timer = timer + Time.deltaTime;
        if (canDash == true)
        {
            MakeDash(_input);
            canDash = false;
        }
    }

    public void MakeDash(Vector2 input)
    {
        if (timer >= _dashingCooldown)
        {
            if(input.x > 0)
            {
                _animator.SetBool("RollRight", true);
            }

            UnityEngine.Debug.Log("Animation");

            Vector2 playerDash = input.normalized * _dashingPower;
            _rigidBody.velocity = playerDash;
            _animator.SetBool("RollRight", false);
            timer = 0;
            canDash = true;
        }


    }

    /*private void OnPlayerDash()
    {
        if(canDash) { StartCoroutine(PlayerDash()); }    
    }*/
}
