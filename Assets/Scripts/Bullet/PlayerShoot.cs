using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    List<GameObject> bullets; // Lista de GameObjects de balas

    int currentBulletIndex;
    float timer = 0f;
    [SerializeField]
    bool shootWithCooldown;

    bool canShoot = true;

    [SerializeField] private float _shootCooldown;


    void Start()
    {
        currentBulletIndex = 0; // Establecer la bala inicial
    }

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f) // Desplazamiento hacia arriba
        {
            // Cambiar a la siguiente bala
            currentBulletIndex = (currentBulletIndex + 1) % bullets.Count;
        }
        else if (scrollInput < 0f) // Desplazamiento hacia abajo
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
            AudioManager.PlaySFX(AudioName.Shoot1, GetComponent<AudioSource>());
        }
        if (currentBulletIndex == 1)
        {
            AudioManager.PlaySFX(AudioName.Shoot2, GetComponent<AudioSource>());
        }
        if (currentBulletIndex == 2)
        {
            AudioManager.PlaySFX(AudioName.Shoot3, GetComponent<AudioSource>());
        }
        // Resto del código para el comportamiento de la bala...
    }
}
