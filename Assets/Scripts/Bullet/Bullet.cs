using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de la bala
    public float tiempoDeVida = 2f; // Cuánto tiempo (en segundos) debe vivir la bala antes de destruirse
    public int daño = 1; // Cantidad de daño que hace la bala

    private void Start()
    {
        // Destruir la bala después de 'tiempoDeVida' segundos
        Destroy(gameObject, tiempoDeVida);
    }

    private void Update()
    {
        // Mover la bala hacia adelante
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject objetoColisionado = other.gameObject;
        Debug.Log("Colisión con: " + objetoColisionado.name);
        Destroy(objetoColisionado);
    }
}
