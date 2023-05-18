using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public int distanceCheck;

    SpriteRenderer spriteFlip;
    public enum EState
    {
        Idle,
        Wander,
        Attack,
    }

    FSM<EState> brain;


    float _currentTime;

    Vector3 _direction;

    [SerializeField]
    float Speed = 2;

    Transform _player;
    // Start is called before the first frame update
    void Start()
    {

        InitFSM();

        _currentTime = 0;
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        spriteFlip = GetComponent<SpriteRenderer>();


    }

    private void InitFSM()
    {
        brain = new FSM<EState>(EState.Idle);
        brain.SetOnEnter(EState.Idle, () => _currentTime = 0);
        brain.SetOnEnter(EState.Wander, () =>
        {
            _currentTime = 0;
            float rdmAngle = Random.Range(0, 360);
            _direction = new Vector3(Mathf.Sin(rdmAngle), Mathf.Cos(rdmAngle), 0);
        });

        brain.SetOnStay(EState.Idle, IdleUpdate);
        brain.SetOnStay(EState.Wander, WanderUpdate);
        brain.SetOnStay(EState.Attack, AttackUpdate);

    }



    // Update is called once per frame
    void Update()
    {
        

        var enemyPosition = new Vector2(transform.localPosition.x, transform.localPosition.y).normalized;
        Debug.Log(enemyPosition);
        if (enemyPosition.x < 0)
        {
            spriteFlip.flipX = true;
        }
        else if (enemyPosition.x > 0)
        {
            spriteFlip.flipX = false;
        }

        brain.Update();
    }


    private void IdleUpdate()
    {
        //Execute
        _currentTime += Time.deltaTime;

        //CheckTriggers
        if (_currentTime > 2.0f)
        {
            brain.ChangeState(EState.Wander);

        }

        if (Vector2.Distance(transform.position, _player.position) < distanceCheck)
        {
            brain.ChangeState(EState.Attack);
        }
    }

    private void WanderUpdate()
    {
        //Execute
        transform.position += _direction * Speed * Time.deltaTime;
        _currentTime += Time.deltaTime;

        //CheckTriggers
        if (_currentTime > distanceCheck)
        {
            brain.ChangeState(EState.Idle);

        }

        if (Vector2.Distance(transform.position, _player.position) < distanceCheck)
        {
            brain.ChangeState(EState.Attack);
        }
    }

    private void AttackUpdate()
    {
        //Execute
        _direction = (_player.position - transform.position).normalized;
        transform.position += _direction * Speed * Time.deltaTime;

        //Trigger
        if (Vector2.Distance(transform.position, _player.position) >= distanceCheck)
        {
            brain.ChangeState(EState.Idle);

        }
    }




}
