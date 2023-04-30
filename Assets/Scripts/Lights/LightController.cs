using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    Light lightComponent;
    Renderer myRenderer;

    void Start()
    {
        // Get the Light component attached to the GameObject
        lightComponent = GetComponent<Light>();
        myRenderer = GetComponent<Renderer>();
    }

    public void SetLightColor(Color color)
    {
        // Set the color of the light to the color passed in as a parameter
        lightComponent.color = myRenderer.material.color; ;
    }
}
