using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleproter : MonoBehaviour
{
    
      public GameObject player;
      public Transform Point;
   void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 4);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
        if (other.gameObject.tag == "Point")
        {
           Point = other.gameObject.transform;
         player.transform.position = Point.transform.position;
           Destroy(this.gameObject);
           
        }
    }
}
