using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wope : MonoBehaviour
{
    public float Invincibility;
   public float HardMode;

    void Start()
    {
        Invincibility = GameObject.Find("gage").GetComponent<dontdestrod>().Invincibility;
        HardMode = GameObject.Find("gage").GetComponent<dontdestrod>().HardMode;
    }

 
    public void InvincibilityMode()
    {
        Invincibility = 1;
        HardMode = 0;
    }
    public void InvincibilityModeOff()
    {
        Invincibility = 0;
   
    }
    public void DifficultyMode()
    {
        HardMode = 1;

        Invincibility = 0;
    }

    public void DifficultyModeoff()
    {
        HardMode = 0;
       
    }
}
