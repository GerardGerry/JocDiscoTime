using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSecond : MonoBehaviour
{
    private float timer = 2;
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        var spikesContact = collision.GetComponent<ItTakesDamage>();
        if(spikesContact != null && timer >= 2)
        {
            spikesContact.TakeDamage();
            timer = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        timer = 2;
    }

}
