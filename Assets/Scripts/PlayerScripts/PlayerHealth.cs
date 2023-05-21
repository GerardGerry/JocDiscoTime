using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ItTakesDamage, ItHeals
{
    [SerializeField]
    [Range (0, 8)]
    private int m_currentHearts = 6;
    

    [SerializeField]
    HUD hud;

    public void TakeDamage()
    {
        m_currentHearts--;
        CheckAmount(m_currentHearts);
        hud.SetHealth(m_currentHearts);
    }

    public void Heal()
    {
        m_currentHearts++;
        CheckAmount(m_currentHearts);
        hud.SetHealth(m_currentHearts);
    }
    private void CheckAmount(int amount)
    {
        if (amount < 0) { m_currentHearts = 0; }
        else if (amount > 8) { m_currentHearts = 8; }
    }
}
