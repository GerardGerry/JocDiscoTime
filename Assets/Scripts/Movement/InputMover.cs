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
        if (controlType == ControlType.Force)
        {
            MoveByFoce();           
        }
        if (controlType == ControlType.Speed)
        {
            Move();         
        }
    }
    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }
    private void Move()
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpeedPowerUp speedUp = collision.GetComponent<SpeedPowerUp>();
        if (speedUp != null)
        {
            IncreaseSpeed();
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
