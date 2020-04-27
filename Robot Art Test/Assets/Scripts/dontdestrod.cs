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
    public float level1;
    public float level2;
    public float level3;
    public bool sun = false;

    private void Awake()
    {
            DontDestroyOnLoad(this.gameObject);
            Instance = this.gameObject;
        hardText = GameObject.Find("hard mode");
        HardModeText = hardText.GetComponent<Text>();
        invText = GameObject.Find("invinsability");

       
    }
    private void LateUpdate()
    {
        ActiveInvincivility = Invincibility;
        ActiveHardMode = HardMode;
       
    }

    private void Update()
    {
        if (GameObject.Find("stuff") == null)
        {
            sun = false;
        }

        if (GameObject.Find("stuff") != null)
        {
            sun = true;
        }

        if (sun == true)
        {
            HardMode = GameObject.Find("stuff").GetComponent<wope>().HardMode;
            Invincibility = GameObject.Find("stuff").GetComponent<wope>().Invincibility;
        }
       
    }
   

    public void InvincibilityMode()
    {
        Invincibility = 1;
        InvincibilityText.text = "Invincibility Enabled";
        HardMode = 0;
        HardModeText.text = "";
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
        InvincibilityText.text = "";
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
    public void L1complete()
    {

    }
}

