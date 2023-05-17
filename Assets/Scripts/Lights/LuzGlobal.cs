using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzGlobal : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D luz2D;
    public float intensidadInicial = 1f;
    public float intensidadMaxima = 2f;
    public float intensidadMinima = 0.5f;
    public float tiempoCambio = 2f;

    private float tiempoActual;
    private bool cambiarIntensidad;

    private void Start()
    {
        // Asigna la intensidad inicial a la luz
        luz2D.intensity = intensidadInicial;

        // Inicializa el temporizador
        tiempoActual = 0f;
        cambiarIntensidad = false;
    }

    private void Update()
    {
        // Actualiza el temporizador
        tiempoActual += Time.deltaTime;

        // Comprueba si ha transcurrido el tiempo de cambio
        if (tiempoActual >= tiempoCambio && !cambiarIntensidad)
        {
            // Indica que se debe cambiar la intensidad
            cambiarIntensidad = true;
        }

        // Realiza el cambio de intensidad si es necesario
        if (cambiarIntensidad)
        {
            // Genera un valor de intensidad aleatorio dentro del rango establecido
            float intensidadAleatoria = Random.Range(intensidadMinima, intensidadMaxima);

            // Cambia la intensidad de la luz al valor aleatorio
            luz2D.intensity = intensidadAleatoria;

            // Reinicia el temporizador y la bandera de cambio de intensidad
            tiempoActual = 0f;
            cambiarIntensidad = false;
        }
    }
}
