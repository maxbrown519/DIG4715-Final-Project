using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wope : MonoBehaviour
{
    public GameObject hardText;
    public GameObject invText;

    public float Invincibility;
    public float HardMode;
    public Text InvincibilityText;
    public Text HardModeText;

    void Start()
    {
        Invincibility = GameObject.Find("gage").GetComponent<dontdestrod>().Invincibility;
        HardMode = GameObject.Find("gage").GetComponent<dontdestrod>().HardMode;
        hardText = GameObject.Find("hard mode");
        HardModeText = hardText.GetComponent<Text>();
        invText = GameObject.Find("invinsability");
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

    private void Update()
    {
        if(Invincibility == 1)
        {
            InvincibilityText.text = "Invincibility Enabled";
        }
        if(Invincibility == 0)
        {
            InvincibilityText.text = "";
        }
        if(HardMode == 1)
        {
            HardModeText.text = "Hard Mode Enabled";
        }
        if(HardMode == 0)
        {
            HardModeText.text = "";
        }
    }
}
