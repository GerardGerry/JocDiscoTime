using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    List<GameObject> bullets; // Lista de GameObjects de balas

    int currentBulletIndex;

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

    }

    public void ShootBullet()
    {
        GameObject newBullet = Instantiate(bullets[currentBulletIndex], transform.position, transform.rotation);
        // Resto del código para el comportamiento de la bala...
    }
}
