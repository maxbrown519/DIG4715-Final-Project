using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorScript : MonoBehaviour
{
    public GameObject lockTarget;
    public bool isOpened = false;
    public float killTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lockTarget.GetComponent<TargetScript>().isLocked == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            Destroy(this.gameObject, killTime);
        }
    }
}
