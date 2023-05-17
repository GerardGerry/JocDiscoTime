using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de la bala
    public float tiempoDeVida = 2f; // Cu�nto tiempo (en segundos) debe vivir la bala antes de destruirse
    public int da�o = 1; // Cantidad de da�o que hace la bala

    private void Start()
    {
        // Destruir la bala despu�s de 'tiempoDeVida' segundos
        Destroy(gameObject, tiempoDeVida);
    }

    private void Update()
    {
        // Mover la bala hacia adelante
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Obtener una referencia al objeto que se ha colisionado
        GameObject objetoColisionado = other.gameObject;

        // Si el objeto colisionado tiene un componente 'Enemigo', infligir da�o
        /*Enemigo enemigo = objetoColisionado.GetComponent<Enemigo>();
        if (enemigo != null)
        {
            enemigo.RecibirDanio(da�o);
        }*/

        // Destruir la bala
        Destroy(gameObject);
    }
}
