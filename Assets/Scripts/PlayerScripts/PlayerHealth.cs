using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ItTakesDamage, ItHeals
{
    private float _currentHealth = 100;
    private float _maxHealth = 100;
    public float CurrentHealth => _currentHealth;

    public float CurrentHealth1 { get => _currentHealth; set => _currentHealth = value; }

    public static Action<float> OnTakeDamage;


    void Start()
    {
        OnTakeDamage?.Invoke(_currentHealth / _maxHealth);
    }


    //public float GetHealth()
    //{
    //    return _currentHealth;
    //}
    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        OnTakeDamage?.Invoke(_currentHealth / _maxHealth);
        Debug.Log("Auch, current health: " + _currentHealth);
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
    }
}
