using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorScript : MonoBehaviour
{
    public GameObject lockTarget;
    public bool isOpened = false;
    public float speed;
    public float killTime;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Boss Door")
        {
            if (boss.GetComponent<BossScript>().HP <= 0)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                Destroy(this.gameObject);
            }
        }
        else if(this.gameObject.tag != "Boss Door"){
            if (lockTarget.GetComponent<TargetScript>().isLocked == false)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                Destroy(this.gameObject, killTime);
            }
        }
    }
}
