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

    private bool canDash = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }
    private void OnPlayerDash()
    {
        if(canDash) { StartCoroutine(PlayerDash()); }    
    }
    private IEnumerator PlayerDash()
    {
        canDash = false;
        Vector2 playerDash = new Vector2(_input.x * _dashingPower, _input.y * _dashingPower);
        _rigidBody.velocity = playerDash;
        yield return new WaitForSeconds(_dashingCooldown);
        canDash = true;
    }
}
