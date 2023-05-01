using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    InputMover _inputMover;
    Dash _dash;
    Animator _animator;

    Vector2 _input;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _inputMover = GetComponent<InputMover>();
        _dash = GetComponent<Dash>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMove(InputValue value)
    {
        _inputMover.SetInput(value);
        _input = value.Get<Vector2>();
        _animator.SetBool("MovingLeft", _input.x < 0);
        _animator.SetBool("MovingRight", _input.x > 0);
        _animator.SetBool("MovingUp", _input.y > 0);
        _animator.SetBool("MovingDown", _input.y < 0);
        _animator.SetBool("MovingDownLeft", _input.y < 0 && _input.x < 0);


    }

    private void OnPlayerDash()
    {
       
        _dash.MakeDash(_input);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpeedPowerUp speedUp = collision.GetComponent<SpeedPowerUp>();
        if (speedUp != null)
        {
            speedUp.IncreaseSpeed(true, _inputMover);
            Debug.Log("Destroyed");
        }
    }
}
