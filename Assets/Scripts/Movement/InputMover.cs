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
    DestroyedCollider _destroyedCollider;
    private GameObject player;
    [SerializeField] private ParticleSystem moveParticles;

    Vector2 _input;
    Vector2 lastPosition;

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

    bool goSlower = true;
    private bool _alreadyPlaying;

    // Start is called before the first frame update
    void Awake()
    {       
        _rigidBody = GetComponent<Rigidbody2D>();
        _dash = GetComponent<Dash>();
    }

    private void Update()
    {
        if(_dash.IsDashing())
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
        
    }

    public void SetInput(InputValue value)
    {
        _input = value.Get<Vector2>();
        if (_input.magnitude >= 0.1f || _input.magnitude <= 0 && !_alreadyPlaying)
        {
            _alreadyPlaying = true;
            moveParticles.Play();

            Debug.Log("aaaa" +_input.magnitude);

        }
        else
        {
            moveParticles.Stop();
            _alreadyPlaying = false;
            Debug.Log("stop" + _input.magnitude);
        }

    }

    public void Move()
    {
        var targetVelocity = _input * speed;
        _rigidBody.velocity = Vector2.Lerp(_rigidBody.velocity, targetVelocity, _smoothing);
       
    }
    private void MoveByFoce()
    {
        _rigidBody.AddForce(_input * _force, ForceMode2D.Force);
        var force = _input * _force * Time.deltaTime;
    }

    public void SpeedBoot(float speedUp)
    {
        
        speed += speedUp;
        _force += speedUp;
    }
    private void SendData()
    {
        _destroyedCollider.PlayerData(_force, _input);
    }

    public void LowHealth( int a)
    {
        
        

        if(a == 1 && goSlower == true)
        {
            goSlower = false;
            _force = _force / 2;
            speed = speed / 2;
        }
        else if(a > 1 && goSlower == false) 
        {
            goSlower = true;
            _force = _force * 2;
            speed = speed * 2;
        }
        
    }

}
