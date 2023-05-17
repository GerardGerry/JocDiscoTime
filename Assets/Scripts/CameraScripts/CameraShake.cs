using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0f;
    public float shakeMagnitude = 0.7f;

    private void Start()
    {
        shakeDuration = 0f;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = transform.localPosition + UnityEngine.Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime;
        }

        else
        {
            shakeDuration = 0f;
        }
    }

    public void ShakeCamera(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }

}