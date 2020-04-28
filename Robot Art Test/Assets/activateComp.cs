using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateComp : MonoBehaviour
{
    public Animator anima;
    public GameObject activator;
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        activator = GameObject.FindGameObjectWithTag("compactor activeator");
        anima.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        activator.GetComponent<comStart>().active = on;
        if (on == true)
        {
            anima.enabled = true;
        }
    }
}
