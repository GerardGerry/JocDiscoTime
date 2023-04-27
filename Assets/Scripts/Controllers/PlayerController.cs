using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    InputMover _inputMover;
    Dash _dash;

    Vector2 _input;

    private void Awake()
    {
        
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


    }

    private void OnPlayerDash()
    {
        _dash.MakeDash(_input);

    }
}
