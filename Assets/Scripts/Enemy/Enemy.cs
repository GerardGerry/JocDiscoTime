using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    EState _currentState;

    Dictionary<EState, State> AllStates;

    FSM<EState> brain;

    float _currentTime;

    Vector3 _direction;

    float speed;

    Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        InitFSM();

        _player = GameObject.FindGameObjectWithTag("Player").transform;

        AllStates = new Dictionary<EState, State>();
        foreach (EState e in System.Enum.GetValues(typeof(EState)))
        {
            AllStates.Add(e, new State());
        }
        AllStates[EState.Idle].OnEnter = () => _currentState = 0;
        AllStates[EState.Wadner].OnEnter = () =>
        {
            _currentTime = 0;
            float rdmAngle = UnityEngine.Random.Range(0, 360);
            _direction = new Vector3(Mathf.Sin(rdmAngle), Mathf.Cos(rdmAngle), 0);
        };
        AllStates[EState.Idle].OnStay = IdleUpadte;
        AllStates[EState.Wadner].OnStay = WanderUpdate;
        AllStates[EState.Attack].OnStay = AttackUpdate;

        _currentState = EState.Idle;
        _currentTime = 0;
        

    }

    private void InitFSM()
    {
        brain = new FSM<EState>(EState.Idle);
        brain.SetOnEnter(EState.Idle, () => _currentTime = 0);
        brain.SetOnEnter(EState.Wadner, () => {
            _currentTime = 0;
            float rdmAngle = UnityEngine.Random.Range(0, 360);
            _direction = new Vector3(Mathf.Sin(rdmAngle), Mathf.Cos(rdmAngle), 0);
        });


    }

    // Update is called once per frame
    void Update()
    {
        AllStates[_currentState].OnStay?.Invoke();
    }

    void ChangeState(EState newState)
    {
        AllStates[_currentState].OnExit?.Invoke();
        AllStates[newState].OnEnter?.Invoke();

        _currentState = newState;
    }

    private void IdleUpadte()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > 2.0f)
        {
            ChangeState(EState.Wadner);
        }
        if (Vector2.Distance(transform.position, _player.position) < 4)
        {
            ChangeState(EState.Attack);
        }
    }

    private void AttackUpdate()
    {
        _direction = (_player.position - transform.position).normalized;
        transform.position += _direction * speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, _player.position) > 4)
        {
            ChangeState(EState.Idle);
        }
    }

    private void WanderUpdate()
    {
        transform.position += _direction * speed * Time.deltaTime;
        _currentTime += Time.deltaTime;

        if(_currentTime > 4.0f)
        {
            ChangeState(EState.Idle);
        }
        if(Vector2.Distance(transform.position, _player.position) < 4)
        {
            ChangeState(EState.Attack);
        }
    }
}
