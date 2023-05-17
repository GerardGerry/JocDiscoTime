using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{   
    [SerializeField]
    private GameObject[] hearts;

    public void SetHealth(int N)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < N);
        }
    }

}
