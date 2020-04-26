using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dontdestrod : MonoBehaviour
{
    public static GameObject Instance;
    private GameObject hardText;
    public Text HardModeText;
    private GameObject invText;
    public Text InvincibilityText;
    [SerializeField] public float Invincibility;
    [SerializeField] public float HardMode;
    private float ActiveInvincivility;
    private float ActiveHardMode;
    public GameObject VolSlider;
    public float Volume;
    
    private void Awake()
    {
            DontDestroyOnLoad(this.gameObject);
            Instance = this.gameObject;
        hardText = GameObject.Find("hard mode");
        HardModeText = hardText.GetComponent<Text>();
        invText = GameObject.Find("invinsability");
        InvincibilityText = invText.GetComponent<Text>();
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
        InvincibilityText.text = "Invincibility Mode Enabled";
        HardMode = 0;
    }
    public void InvincibilityModeOff()
    {
        Invincibility = 0;
        InvincibilityText.text = "";
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
        HardModeText.text = "";
    }

    public void ChangeVol()
    {
        Volume = GameObject.Find("Volume Slider").GetComponent<Slider>().value;

    }
}

