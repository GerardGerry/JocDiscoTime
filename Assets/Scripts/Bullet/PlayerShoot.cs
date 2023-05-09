using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    public void ShootBullet(Vector2 input)
    {
        bullet = Instantiate(bullet, transform.position, transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
