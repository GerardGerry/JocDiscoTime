using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpriteChange : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    UnityEngine.Rendering.Universal.Light2D _objectLight;

    [SerializeField]
    float interval = 0.1f;
    float randomNumber;
    float m_Hue;
    float m_Saturation = 1;
    float m_Value = 1f;
    float m_Intensity = 1f;
    float timer;

    Color newColor;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _objectLight = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
    }

    private void Update()
    {
        timer = timer + Time.deltaTime;
        ColorChange();

    }

    private void ColorChange()
    {
        if (timer >= interval)
        {
            MaterialChange();
            LightChange();
            timer = 0;
        }

    }

    private void MaterialChange()
    {
        randomNumber = UnityEngine.Random.value;
        m_Hue = randomNumber;
        randomNumber = UnityEngine.Random.value;
        m_Value = UnityEngine.Random.Range(0, 1);

        if (randomNumber == 0)
        {
            m_Saturation = 0.5f;
            m_Value = 0.2f;
        }
        else
        {
            m_Value = 1;
        }

        newColor = Color.HSVToRGB(m_Hue, m_Saturation, m_Value);
        _spriteRenderer.material.color = newColor;
    }

    private void LightChange()
    {
        m_Intensity = UnityEngine.Random.Range(0f, 1f);
        _objectLight.intensity = m_Intensity;

        // Cambia el color del objeto

        _objectLight.color = newColor;
    }

}
