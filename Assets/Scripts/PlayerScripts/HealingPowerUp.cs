using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPowerUp : MonoBehaviour
{
    public float healing = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var healingAmount = other.GetComponent<ItHeals>();
        if (healingAmount!= null)
        {
            Debug.Log("GetHEarto");
            healingAmount.Heal(healing);
        }


    }
}
