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

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _objectLight = GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
        Debug.Log(_objectLight);

        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            randomNumber = Random.value;
            m_Hue = randomNumber;
            randomNumber = Random.value;
            m_Value = Random.Range(0, 1);

            if (randomNumber == 0)
            {
                m_Saturation = 0.5f;
                m_Value = 0.2f;
            }
            else
            {
                m_Value = 1;
            }

            m_Intensity = Random.Range(0f, 2f);
            _objectLight.intensity = m_Intensity;

            // Cambia el color del objeto
            Color newColor = Color.HSVToRGB(m_Hue, m_Saturation, m_Value);
            _spriteRenderer.material.color = newColor;
            _objectLight.color = newColor;

            yield return new WaitForSeconds(interval);
        }
    }

}
