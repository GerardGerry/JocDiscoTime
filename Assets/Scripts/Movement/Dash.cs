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
    bool canDash = true;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
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
        if(timer >= _dashingCooldown)
        {
            //Vector2 playerDash = new Vector2(_input.x * _dashingPower, _input.y * _dashingPower);
            Vector2 playerDash = input.normalized * _dashingPower;
            Debug.Log(playerDash);
            _rigidBody.velocity = playerDash;
            timer = 0;
            canDash = true;
        }

    }

    /*private void OnPlayerDash()
    {
        if(canDash) { StartCoroutine(PlayerDash()); }    
    }*/
}
