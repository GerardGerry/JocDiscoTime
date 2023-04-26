using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0f;
    public float shakeMagnitude = 0.7f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {

    }

    public void ShakeCamera(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime;


        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }
}