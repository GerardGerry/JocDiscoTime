using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    public void ShootBullet()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
    }

}
