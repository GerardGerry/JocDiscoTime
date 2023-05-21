using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItTakesDamage;

public class EnemyDamage : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageReciever = other.GetComponent<ItTakesDamage>();
        if (damageReciever != null)
        {
            damageReciever.TakeDamage();
        }
    }   
}
