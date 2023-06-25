using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    List<GameObject> bullets;

    int currentBulletIndex;
    float timer = 0f;
    [SerializeField]
    bool shootWithCooldown;

    bool canShoot = true;

    [SerializeField] private float _shootCooldown;


    void Start()
    {
        currentBulletIndex = 0;
    }

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f)
        {
            // Cambiar a la siguiente bala
            currentBulletIndex = (currentBulletIndex + 1) % bullets.Count;
        }
        else if (scrollInput < 0f)
        {
            // Cambiar a la bala anterior
            currentBulletIndex = (currentBulletIndex - 1 + bullets.Count) % bullets.Count;
        }

        if (timer < _shootCooldown)
        {
            timer = timer + Time.deltaTime;
        }
        if (timer >= _shootCooldown)
        {
            timer = 0;
            canShoot = true;
        }

    }

    public void ShootBullet()
    {
        if (shootWithCooldown)
        {
            if (canShoot)
            {
                canShoot = false;
                GameObject newBullet = Instantiate(bullets[currentBulletIndex], transform.position, transform.rotation);
            }
        }
        else
        {
            GameObject newBullet = Instantiate(bullets[currentBulletIndex], transform.position, transform.rotation);
        }

        if (currentBulletIndex == 0)
        {
            NewAudioManager.NewPlaySFX(("newShoot"), GetComponent<AudioSource>());
        }
        if (currentBulletIndex == 1)
        {
            NewAudioManager.NewPlaySFX(("newShoot2"), GetComponent<AudioSource>());
        }
        if (currentBulletIndex == 2)
        {
            NewAudioManager.NewPlaySFX(("newShoot3"), GetComponent<AudioSource>());
        }
    }
}
