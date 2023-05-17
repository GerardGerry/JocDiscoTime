using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    private void Start()
    {
        // Ocultar el cursor del rat�n
        Cursor.visible = false;
    }

    private void Update()
    {
        // Obtener la posici�n del rat�n en coordenadas del mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Asegurarse de que el punto est� en el plano Z = 0

        // Mover el objeto a la posici�n del rat�n
        transform.position = mousePosition;
    }
}
