using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comStart : MonoBehaviour
{
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            active = true;
        }
    }
}
