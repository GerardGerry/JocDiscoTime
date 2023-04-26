using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpeedPowerUp speedUp = collision.GetComponent<SpeedPowerUp>();
        if (speedUp != null)
        {
           IncreaseSpeed();
            Destroy(collision.gameObject);
        }
    }
    public void IncreaseSpeed()
    {
        speed += 30f;
        _force += 30f;
        Debug.Log("Increased");
        Invoke("DecreaseSpeed", 5f);
    }
    private void DecreaseSpeed()
    {
        Debug.Log("Decreased");
        speed -= 30f;
        _force -= 30f;
    }*/
}
