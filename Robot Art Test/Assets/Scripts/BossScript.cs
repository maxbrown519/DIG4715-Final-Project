using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BossScript : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public float attkRate;
    public Transform PlayerTarget;
    public GameObject player;
    // tracks which locations it's been to
    public bool T1 = false;
    public bool T2 = false;
    public bool T3 = false;
    public bool T4 = false;

    public bool PlayerSpoted = false;
    public Rigidbody enemyProjectile;
    public Transform SpawnLocation1;
    public Transform SpawnLocation2;
    public Transform SpawnLocation3;
    public Transform SpawnLocation4;
    public float projectileSpeed;
    public float attackRate;
    public Transform Player;
    public float HP;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("PLaayer");
        HP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
        if (PlayerSpoted == true)
        {
            player = GameObject.Find("PLaayer");
            PlayerTarget = player.transform;
            Vector3 lookVector = player.transform.position - transform.position;
            lookVector.y = Player.transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
            attackRate -= Time.deltaTime;
            if (attackRate <= 0)
            {
                shoot();
            }
        }

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
    private void OnCollisionEnter(Collision other)
    {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            PlayerSpoted = true;
        }

    }
    void shoot()
    {
        //projectile 1
        Rigidbody bulletInstance;
        bulletInstance = Instantiate(enemyProjectile, SpawnLocation1.position, SpawnLocation1.rotation);
        bulletInstance.AddForce(SpawnLocation1.forward * projectileSpeed);
        attackRate = attkRate;
        //prjectile 2
        Rigidbody bulletInstance2;
        bulletInstance2 = Instantiate(enemyProjectile, SpawnLocation2.position, SpawnLocation2.rotation);
        bulletInstance2.AddForce(SpawnLocation2.forward * projectileSpeed);
        attackRate = attkRate;
        //projectile 3
        Rigidbody bulletInstance3;
        bulletInstance3 = Instantiate(enemyProjectile, SpawnLocation3.position, SpawnLocation3.rotation);
        bulletInstance3.AddForce(SpawnLocation3.forward * projectileSpeed);
        attackRate = attkRate;
        //projectile 4
        Rigidbody bulletInstance4;
        bulletInstance4 = Instantiate(enemyProjectile, SpawnLocation4.position, SpawnLocation4.rotation);
        bulletInstance4.AddForce(SpawnLocation4.forward * projectileSpeed);
        attackRate = attkRate;
    }
}
