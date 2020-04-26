using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestrod : MonoBehaviour
{
    public static GameObject Instance;
    [SerializeField] public float Invincibility;
    [SerializeField] public float HardMode;
    private float ActiveInvincivility;
    private float ActiveHardMode;
    
    private void Awake()
    {

            DontDestroyOnLoad(this.gameObject);
            Instance = this.gameObject;
        


    }
    private void LateUpdate()
    {
        ActiveInvincivility = Invincibility;
        ActiveHardMode = HardMode;
    }

    private void Update() { }
   

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

