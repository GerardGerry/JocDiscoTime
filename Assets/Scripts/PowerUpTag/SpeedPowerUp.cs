using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField]
    float increasedSpeed;
    public void IncreaseSpeed(bool activated, InputMover _inputMover)
    {
       if (activated)
        {
            Destroy(this.gameObject);
            Debug.Log(_inputMover);
            _inputMover.SpeedBoot(increasedSpeed);            
        }       
    }   
}
