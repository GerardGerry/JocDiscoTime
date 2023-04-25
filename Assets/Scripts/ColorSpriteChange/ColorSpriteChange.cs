using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpriteChange : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    [SerializeField]
    float interval = 0.5f;
    float randomNumber;
    float m_Hue;
    float m_Saturation = 1;
    float m_Value = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

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

            // Cambia el color del objeto
            _spriteRenderer.material.color = Color.HSVToRGB(m_Hue, m_Saturation, m_Value);


            yield return new WaitForSeconds(interval);
        }
    }

}
