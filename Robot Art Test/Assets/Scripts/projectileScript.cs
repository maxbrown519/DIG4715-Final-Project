using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 4);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
        if (other.gameObject.tag == "hostile")
        {
            Destroy(other.gameObject);
        }
    }
    /*private void OncTriggerEnter(Collision other)
    {
        Destroy(this.gameObject);
        if (other.gameObject.tag == "hostile")
        {
            Destroy(other.gameObject);
        }
    }*/
    /*private void OnTriggerEnter(Collider other)
    {
        // Destroy(this.gameObject);
        if (other.gameObject.tag == "hostile")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }*/
}
