using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, ItTakesDamage, ItHeals
{
    [SerializeField]
    [Range (0, 8)]
    private int m_currentHearts = 6;


    PlayerController _playerController;
    GetHit _hit;
    GetHeal _heal;



    [SerializeField] private ParticleSystem healingParticles;
    [SerializeField] private ParticleSystem BleedingParticles;

    //[SerializeField] private SceneManager _sceneManager;

    [SerializeField]
    HUD hud;

    public void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
        _hit = GetComponentInChildren<GetHit>();
        _heal = GetComponentInChildren<GetHeal>();
    }
    public void TakeDamage()
    {
        m_currentHearts--;
        _hit.TakeDamage();
        CheckAmount(m_currentHearts);
        hud.SetHealth(m_currentHearts);
    }

    public void Heal()
    {
        if(m_currentHearts != 8)
        {
            m_currentHearts++;
            _heal.Heal();
            CheckAmount(m_currentHearts);
            hud.SetHealth(m_currentHearts);
            healingParticles.Play();
        }
    }
    private void CheckAmount(int amount)
    {

        if (amount <= 0) 
        {
            SceneManager.LoadScene("MainMenu");
            m_currentHearts = 0; 
        }
        else if (amount > 8) { m_currentHearts = 8; }
        else if(amount == 3) { BleedingParticles.Stop(); }
        else if (amount < 3) 
        { 
            _playerController.PlayerHealthLow(amount);
            BleedingParticles.Play();
        }
    }
}
