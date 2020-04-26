using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]

public class Options : MonoBehaviour
{
    [SerializeField]public bool Invincibility = false;
    [SerializeField]public bool HardMode = false;

    public void InvincibilityMode()
    {
        Invincibility = !Invincibility;
    }
    public void DifficultyMode()
    {
        HardMode = !HardMode;
    }
}
