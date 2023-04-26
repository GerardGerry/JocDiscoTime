using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class InputMover : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    Dash _dash;
    private GameObject player;

    Vector2 _input;

    CameraShake _cameraShake;

    [SerializeField]
    ControlType controlType;
    enum ControlType
    {
        Force,
        Speed
    }

    [SerializeField]
    [Range(0, 1)]
    private float _smoothing;
   
    [SerializeField]
    private float _force;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Awake()
    {
        //player= GetComponent<GameObject>();
        _rigidBody= GetComponent<Rigidbody2D>();
        _dash = GetComponent<Dash>();
    }

    private void FixedUpdate()
    {
        if (controlType == ControlType.Force)
        {
            MoveByFoce();           
        }
        if (controlType == ControlType.Speed)
        {
            Move();         
        }
    }
    public void SetInput(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    public void Move()
    {
            var targetVelocity = _input * speed;
            _rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, targetVelocity, _smoothing); //opcionalment a transform.translate?
                                                                                                //Bona idea amb el Lerp fa una trancisió entre la velocitat desitjada    
    }
    private void MoveByFoce()
    {       
            _rigidBody.AddForce(_input * _force, ForceMode2D.Force);
            var force = _input * _force * Time.deltaTime;     
    }


}
