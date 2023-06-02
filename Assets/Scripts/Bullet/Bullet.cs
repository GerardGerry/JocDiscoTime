using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de la bala
    public float tiempoDeVida = 2f; // Cuánto tiempo (en segundos) debe vivir la bala antes de destruirse
    
    [SerializeField]
    int daño; // Cantidad de daño que hace la bala

    private void Start()
    {
        AudioManager.PlayerSFX(AudioName.Hit, GetComponent<AudioSource>());
        // Destruir la bala después de 'tiempoDeVida' segundos
        Destroy(gameObject, tiempoDeVida);
    }

    private void Update()
    {
        // Mover la bala hacia adelante
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyAi>();
        if (enemy)
        {
            enemy.TakeHit(daño);
        }

        Destroy(gameObject);
    }
}
