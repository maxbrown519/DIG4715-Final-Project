using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlockingHostile : MonoBehaviour
{
    public Transform fallback;
    public Transform fallback2;
    public Transform finalpoint;
    public Transform PlayerTarget;
    public bool moved = false;
    public bool fellback = false;
    public bool playerseen;
    NavMeshAgent nav;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerseen == true)
        {
            Player = GameObject.Find("PLaayer");
            PlayerTarget = Player.transform;
            Vector3 lookVector = Player.transform.position - transform.position;
            //lookVector.y = Player.transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
            nav.SetDestination(fallback.position);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //player takes damage
        }
        if (other.gameObject.tag == "D1")
        {
            moved = true;
        }
        if (other.gameObject.tag == "D2")
        {
            fellback = true;
        }
        if (other.gameObject.tag == "projectile")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && playerseen == false)
        {
            playerseen = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Player" && playerseen == false)
        {
            playerseen = true;
        }*/
        if (playerseen == true)
        {
            if (other.gameObject.tag == "Player" && moved == false)
            {
                nav.SetDestination(fallback.position);
                moved = true;
            }
        }
    }
}
