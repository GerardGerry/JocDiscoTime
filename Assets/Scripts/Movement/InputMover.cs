using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class InputMover : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    private GameObject player;

    Vector2 _input;
    bool _isSprinting = false;

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
    float _force;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float walking;

    // Start is called before the first frame update
    void Start()
    {
        player= GetComponent<GameObject>();
        _rigidBody= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    private void FixedUpdate()
    {
        DoOnSprint();
        if (controlType == ControlType.Force)
        {
            MoveByFoce();           
        }
        if (controlType == ControlType.Speed)
        {
            Move();         
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) { Temblar(); }
    }
    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }
    private void DoOnSprint()
    {
        //OnSprint();
        Sprint();
    }
    //private void OnSprint(InputValue sprint)
    //{
    //    if(sprint.isPressed == false)
    //    {
    //        _isSprinting = false;
    //        Debug.Log("Nosprint");
    //    }
    //    else
    //    {
    //        _isSprinting = true;
    //        Debug.Log("sprint");
    //    }
    //}
    private void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _isSprinting= true;
        }
        else { _isSprinting = false; }
    }

    private void Move()
    {
        if (_isSprinting)
        {
            var targetVelocity = _input * speed;
            _rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, targetVelocity, _smoothing); //opcionalment a transform.translate?
        }                                                                                 //Bona idea amb el Lerp fa una trancisió entre la velocitat desitjada    
        else
        {
            var targetVelocity = _input * (speed - walking);
            _rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, targetVelocity, _smoothing);
        }
    }
    private void MoveByFoce()
    {
        if (_isSprinting)
        {
            _rigidBody.AddForce(_input * _force, ForceMode2D.Force);
            var force = _input * _force * Time.deltaTime;
        }
        else
        {
            _rigidBody.AddForce(_input * (_force - walking), ForceMode2D.Force);
            var force = _input * _force * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IncreaseSpeed();
        if (collision.gameObject.tag == "PowerUp")
        {
            Destroy(collision.gameObject);
        }
        //SpeedIncrease??
    }
    public void IncreaseSpeed()
    {      
        speed += 30f;
        _force += 30f;
        Debug.Log("Increased");
        Invoke("DecreaseSpeed", 5f);       
    }
    private void DecreaseSpeed()
    {
        Debug.Log("Decreased");
        speed-= 30f;
        _force-= 30f;
    }

    private void Temblar()
    {
        //StartCoroutine(MyObject.GetComponent<ShakeScript>().Shake(1f, 5f));
        //CameraShake.Shake
        Debug.Log("Shaked");     
    }

}
