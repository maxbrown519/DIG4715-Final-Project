using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compactorWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerControllerScript>().health -= 1;

        }
    }
}
