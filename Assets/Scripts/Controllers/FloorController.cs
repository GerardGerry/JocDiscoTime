using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameObject[] discoFloor;
    ColorSpriteChange _colorSpriteChange;
    SpriteRenderer _spriteRenderer;
    UnityEngine.Rendering.Universal.Light2D _objectLight;

    float randomNumber;
    float m_Hue;
    float m_Saturation = 1;
    float m_Value = 1f;
    float m_Intensity = 1f;
    float timer;

    Color newColor;

    [SerializeField]
    float interval = 3f;

    // Start is called before the first frame update
    void Awake()
    {
        _colorSpriteChange = GetComponent<ColorSpriteChange>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            ChangeGlobalColor();
        }
   
    }

    private void ChangeGlobalColor()
    {
        for (int i = 0; i < discoFloor.Length; i++)
        {
            ColorChange(i);
        }
        timer = 0;
    }

    public void ColorChange(int x)
    {
       
        _spriteRenderer = discoFloor[x].GetComponent<SpriteRenderer>();
        _objectLight = discoFloor[x].GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();

        MaterialChange();
        LightChange();
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
        m_Intensity = UnityEngine.Random.Range(0f, 0.5f);
        _objectLight.intensity = m_Intensity;

        // Cambia el color del objeto

        _objectLight.color = newColor;
    }
}
