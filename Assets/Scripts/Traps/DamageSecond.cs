using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSecond : MonoBehaviour
{
    private float timer = 2;
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        var spikesContact = collision.GetComponent<ItTakesDamage>();
        if(spikesContact != null && timer >= 2)
        {
            Debug.Log("spiked");
            spikesContact.TakeDamage();
            timer = 0;
        }

    }
    
}
