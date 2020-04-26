using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Options : MonoBehaviour
{
    [SerializeField]public float Invincibility;
    [SerializeField]public float HardMode;

    public void Update()
    {
        
    }


    public void InvincibilityMode()
    {
        Invincibility = 1;

    }
    public void InvincibilityModeOff()
    {
        Invincibility = 0;

    }
    public void DifficultyMode()
    {
        HardMode = 1;
    }

    public void DifficultyModeoff()
    {
        HardMode = 0;
    }
}
