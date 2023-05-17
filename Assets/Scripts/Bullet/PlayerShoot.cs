using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject bullet2;
    [SerializeField]
    GameObject bullet3;

    public void ShootBullet()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
    }

    public void ShootMultiBullet()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        GameObject newBullet1 = Instantiate(bullet2, transform.position, transform.rotation);
        GameObject newBullet2 = Instantiate(bullet3, transform.position, transform.rotation);
    }

}
