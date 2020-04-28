using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valueController : MonoBehaviour
{
    private float volume;
    private void Start()
    {
        volume = GameObject.Find("gage").GetComponent<dontdestrod>().Volume;
    }
}
