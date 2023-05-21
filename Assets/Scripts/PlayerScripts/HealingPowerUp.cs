using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPowerUp : MonoBehaviour
{  
    private void OnTriggerEnter2D(Collider2D other)
    {
        var healingAmount = other.GetComponent<ItHeals>();

        if (healingAmount!= null)
        {
            healingAmount.Heal();
        }
    }
}
