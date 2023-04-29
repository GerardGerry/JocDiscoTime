using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class DestroyedCollider : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    float _force;
    Vector2 _input;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerData(float _force, Vector2 _input)
    {
        this._force = _force;
        this._input = _input;
        Debug.Log(_force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {              
        if(collision.collider.GetComponent<BoxReciever>())
        {            
                _rigidBody.AddForce(_input * _force, ForceMode2D.Force);
                var force = _input * _force * Time.deltaTime;         
        }
        else { Destroy(this.gameObject); }
    }
}
