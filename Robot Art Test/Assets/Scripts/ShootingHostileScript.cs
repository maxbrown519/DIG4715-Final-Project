using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingHostileScript : MonoBehaviour
{
    //   //sets points to walk to
    public Transform target;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public float attkRate;
    //animator
    Animator anima;
    //refrences player distractions and if it is feared or not
    public Transform PlayerTarget;
    public GameObject player;
    // tracks which locations it's been to
    public bool T1 = false;
    public bool T2 = false;
    public bool T3 = false;
    public bool T4 = false;

    public bool distracted = false;
    public bool PlayerSpoted = false;

    public Rigidbody enemyProjectile;
    public Transform SpawnLocation;
    public float projectileSpeed;
    public float attackRate;

    //feild of view
    public Transform Player;
    public float MaxAngle;
    public float MaxRadius;
    bool IsInFov = false;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anima = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        PlayerSpoted = IsInFov;

        if (PlayerSpoted == true)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            PlayerTarget = player.transform;
            Vector3 lookVector = player.transform.position - transform.position;
            //lookVector.y = Player.transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
            // agent.SetDestination(PlayerTarget.position);
            attackRate -= Time.deltaTime;
            if (attackRate <= 0)
            {
                shoot();
            }

        }
        if (PlayerSpoted == false)
        {
            if (T1 == false)
            {
                agent.SetDestination(target.position);
            }
            if (T1 == true)
            {
                agent.SetDestination(target2.position);
            }
            if (T1 == true && T2 == true)
            {
                agent.SetDestination(target3.position);
            }
            if (T1 && T2 && T3 == true)
            {
                agent.SetDestination(target4.position);
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
        if (other.gameObject.tag == "D1")
        {
            T1 = true;
        }
        if (other.gameObject.tag == "D2")
        {
            T2 = true;
        }
        if (other.gameObject.tag == "D3")
        {
            T3 = true;
        }
        if (other.gameObject.tag == "D4")
        {
            T1 = false;
            T2 = false;
            T3 = false;
            T4 = false;
            T4 = false;
        }


    }



    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            PlayerSpoted = true;
        }
        if (other.gameObject.tag == "D1")
        {
            T1 = true;
        }
        if (other.gameObject.tag == "D2")
        {
            T2 = true;
        }
        if (other.gameObject.tag == "D3")
        {
            T3 = true;
        }
        if (other.gameObject.tag == "D4")
        {
            T1 = false;
            T2 = false;
            T3 = false;
            T4 = false;
            T4 = false;
        }

    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            PlayerSpoted = false;
        }
    }

    void shoot()
    {
        Rigidbody bulletInstance;
        bulletInstance = Instantiate(enemyProjectile, SpawnLocation.position, SpawnLocation.rotation);
        bulletInstance.AddForce(SpawnLocation.forward * projectileSpeed);
        attackRate = attkRate;
    }
}
