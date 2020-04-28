using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class monitorScript : MonoBehaviour
{
    private GameObject gage;
    private float lvl1;
    private float lvl2;
    private float lvl3;
    public TextMeshPro lvl1Status;
    public TextMeshPro lvl2Status;
    public TextMeshPro lvl3Status;
    // Start is called before the first frame update
    void Start()
    {
        gage = GameObject.Find("gage");
        lvl1 = gage.GetComponent<dontdestrod>().level1;
        lvl2 = gage.GetComponent<dontdestrod>().level2;
        lvl3 = gage.GetComponent<dontdestrod>().level3;

    }

    // Update is called once per frame
    void Update()
    {
        if (lvl1 == 0)
        {
            lvl1Status.text = "Test chamber 1 status: INCOMPLETE";
        }
        if (lvl2 == 0)
        {
            lvl2Status.text = "Test chamber 2 status: INCOMPLETE";
        }
        if (lvl3 == 0)
        {
            lvl3Status.text = "Test chamber 3 status: INCOMPLETE";
        }
        if (lvl1 == 1)
        {
            lvl1Status.text = "Test chamber 1 status: COMPLETE";
        }
        if (lvl2 == 1)
        {
            lvl2Status.text = "Test chamber 2 status: COMPLETE";
        }
        if (lvl3 == 1)
        {
            lvl3Status.text = "Test chamber 3 status: COMPLETE";
        }
    }
}
