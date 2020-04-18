using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hostileProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 4);
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerControllerScript>().HP -= 1;
            Destroy(this.gameObject);

        }
    }
}
