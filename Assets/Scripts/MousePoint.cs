using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    private void Start()
    {
        // Ocultar el cursor del ratón
        Cursor.visible = false;
    }

    private void Update()
    {
        // Obtener la posición del ratón en coordenadas del mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Asegurarse de que el punto esté en el plano Z = 0

        // Mover el objeto a la posición del ratón
        transform.position = mousePosition;
    }
}
