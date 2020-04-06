﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public bool isLocked = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projectile")
        {
            isLocked = false;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile")
        {
            Destroy(other.gameObject);
            isLocked = false;
        }
    }
}
