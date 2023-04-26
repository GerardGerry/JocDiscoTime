using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Dash : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    Vector2 _input;

    //[Header("Dash")]
    [SerializeField] private float _dashingTime = 0.2f;
    [SerializeField] private float _dashingPower = 20f;
    [SerializeField] private float _timeCanDash = 1f;
    [SerializeField] private float _dashingCooldown = 1f;

    float timer = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        timer = timer + Time.deltaTime;
        MakeDash();

    }

    public void SetInput(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    public void MakeDash()
    {
        if(timer >= _dashingCooldown)
        {
            Vector2 playerDash = new Vector2(_input.x * _dashingPower, _input.y * _dashingPower);
            _rigidBody.velocity = playerDash;
            timer = 0;
        }

    }

    /*private void OnPlayerDash()
    {
        if(canDash) { StartCoroutine(PlayerDash()); }    
    }*/
}
