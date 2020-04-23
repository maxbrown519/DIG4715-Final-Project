using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compactorWall : MonoBehaviour
{
    public float speed;
    public bool rightWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rightWall == false)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (rightWall == true)
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
    }
}
