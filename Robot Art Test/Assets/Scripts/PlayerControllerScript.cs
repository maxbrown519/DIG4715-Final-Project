﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerScript : MonoBehaviour
{
  
    public GameObject options;
    // Start is called before the first frame update
    public float speed;
    Vector3 velocity;
    public float grav = -9.81f;
    public float JHeight = 3f;
    public float dashDistance = 3f;
    public CharacterController controller;
    public Transform GCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float jumpHeight;
    public bool DJumped;
    public bool AirDashed;
    public Rigidbody projectile;
    public Rigidbody grappleingHook;
    public Transform SpawnLocation;
    public float ProjectileSpeed;
    public HingeJoint hinge;
    static Vector3 mousePos;


    public AudioSource sfx;
    public AudioClip jump;
    public AudioClip shoot;
    public AudioClip dash;

    public Animator anim;
    [SerializeField] public int health;
    public healthbar healthBar;
    //compactor walls
    public bool comL = false;
    public bool comR = false;
    public bool crushed = false;

    public Transform BackToHub;
    public GameObject ThePlayer;

    void Start()
    {
        anim = GetComponent<Animator>();
        health = 5;
        healthBar.SetMaxHealth(health);
        options = GameObject.Find("gage");
        if (options.GetComponent<dontdestrod>().HardMode == 1)
        {
            health = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel") || Input.GetButton("Back"))
        {
            Application.Quit();
        }
        isGrounded = Physics.CheckSphere(GCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isGrounded == true)
        {
            AirDashed = false;
            DJumped = false;
            velocity.z = 0;
            velocity.x = 0;
        }


        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(JHeight * -2f * grav);

            sfx.clip = jump; //sfx for jump
            sfx.Play();
        }
        if (Input.GetButtonDown("A button") && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(JHeight * -2f * grav);

            sfx.clip = jump; //sfx for jump
            sfx.Play();
        }
        if (Input.GetButtonDown("Jump") && isGrounded == false && DJumped == false)
        {
            DJumped = true;
            velocity = transform.up * Mathf.Sqrt(JHeight * -4f * grav);

            sfx.clip = jump; //sfx for double jump
            sfx.Play();
        }
        if (Input.GetButtonDown("A button") && isGrounded == false && DJumped == false)
        {
            DJumped = true;
            velocity = transform.up * Mathf.Sqrt(JHeight * -4f * grav);

            sfx.clip = jump; //sfx for double jump
            sfx.Play();
        }
        if (Input.GetButtonDown("Submit") && isGrounded == false)
        {
            velocity = transform.forward * Mathf.Sqrt(dashDistance);
            AirDashed = true;
            //transform.Translate(transform.forward * Mathf.Sqrt(dashDistance));

            sfx.clip = dash; //dash sfx
            sfx.Play();
        }
        if (Input.GetButtonDown("B button") && isGrounded == false)
        {
            velocity = transform.forward * Mathf.Sqrt(dashDistance);
            AirDashed = true;
            //transform.Translate(transform.forward * Mathf.Sqrt(dashDistance));

            sfx.clip = dash; //dash sfx
            sfx.Play();
        }

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("right Trigger"))
        {
            mousePos = Input.mousePosition;
            Rigidbody GHookInstance;
            GHookInstance = Instantiate(projectile, SpawnLocation.position, SpawnLocation.rotation);
            GHookInstance.AddForce(SpawnLocation.forward * ProjectileSpeed);

            sfx.clip = shoot; //sfx for projectile
            sfx.Play();
        }
        if (Input.GetButtonDown("Fire2") || Input.GetButtonDown("left Trigger"))
        {
            mousePos = Input.mousePosition;
            Rigidbody GHookInstance;
            GHookInstance = Instantiate(grappleingHook, SpawnLocation.position, SpawnLocation.rotation);
            GHookInstance.AddForce(SpawnLocation.forward * ProjectileSpeed);
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += grav * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (health <= 0)
        {
            SceneManager.LoadScene("Lose Screen"); //load end screen
        }

        //animation movement
        if (Input.GetKey(KeyCode.W))
        {
            if (anim.GetBool("dashing") == true)
            {
                return;
            }
            else if (anim.GetBool("dashing") == false)
            {
                anim.SetBool("idle", false);
                anim.SetBool("walking", true);
                anim.SetInteger("condition", 1);
            }

        }
        else
        {
            anim.SetBool("idle", true);
            anim.SetBool("walking", false);
            anim.SetInteger("condition", 0);
        }
        GetInput();
        if(comR && comL == true)
        {
            health = 0;
        }
        //hp bar
        healthBar.SetHealth(health);


        if (Input.GetKey(KeyCode.R)) //teleport player back to hub
        {
            ThePlayer.transform.position = BackToHub.transform.position;
        }

    }
    void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        if (Other.gameObject.tag == "compactorL")
        {
            comL = true;
        }
        if (Other.gameObject.tag == "compactorR")
        {
            comR = true;
        }
        if(Other.gameObject.tag == "roof")
        {
            health = 0;
        }
    }
    private void OnCollisionExit(Collision Other)
    {
        if (Other.gameObject.tag == "compactorL")
        {
            comL = false;
        }
        if (Other.gameObject.tag == "compactorR")
        {
            comR = false;
        }
    }

    private void FixedUpdate()
    {
        if (options.GetComponent<dontdestrod>().Invincibility == 1)
        {
            if (health < 5)
            {
                health = 5;
            }
        }
    }

    //dash animation plays in the air
    void GetInput()
    {
        if (isGrounded == false)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("B button"))
            {
                if (anim.GetBool("walking") == true)
                {
                    anim.SetBool("walking", false);
                    anim.SetInteger("condition", 0);
                }
                if (anim.GetBool("walking") == false)
                {
                    Dashing();
                }
            }
        }
    }

    //plays dash when walking anim is on
    void Dashing()
    {
        StartCoroutine(DashingRoutine());
    }

    IEnumerator DashingRoutine()
    {
        anim.SetBool("dashing", true);
        anim.SetInteger("condition", 2);
        yield return new WaitForSeconds(1);
        anim.SetInteger("condition", 0);
        anim.SetBool("dashing", false);
    }
}

