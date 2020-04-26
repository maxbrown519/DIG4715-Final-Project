using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dontdestrod : MonoBehaviour
{
    public static GameObject Instance;
    public Text HardModeText;
    public Text InvincibilityText;
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
        HardModeText.text = "Invincibility Mode Enabled";
        HardMode = 0;
    }
    public void InvincibilityModeOff()
    {
        Invincibility = 0;
        
    }
    public void DifficultyMode()
    {
        HardMode = 1;
        HardModeText.text = "Hard Mode Enabled";
        Invincibility = 0;
    }

    public void DifficultyModeoff()
    {
        HardMode = 0;
    }
}

