using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItTakesDamage;

public class EnemyDamage : MonoBehaviour
{
    public float Damage = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageReciever = other.GetComponent<ItTakesDamage>();
        if (damageReciever != null)
        {
            Debug.Log("hitu");
            damageReciever.TakeDamage(Damage);
        }


    }   
}
