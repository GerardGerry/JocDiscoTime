using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth health;
    [SerializeField]
    private TextMeshProUGUI currentHealth;
    [SerializeField]
    private GameObject[] hearts;
   
    // Update is called once per frame
    //void Update()
    //{
    //    currentHealth.text = health.CurrentHealth1.ToString();
    //}

    public void DeactivateHearts(int heartNum)
    {
        hearts[heartNum].SetActive(false);
    }
    public void ActivateHearts(int heartNum)
    {
        hearts[heartNum].SetActive(true);
    }

    public void SetHeaTH(int N)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < N);
        }
    }

}
