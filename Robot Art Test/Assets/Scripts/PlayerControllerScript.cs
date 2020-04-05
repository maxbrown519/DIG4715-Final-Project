using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
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
    public float Range;
    public HingeJoint hinge;
    static Vector3 mousePos;
    public float HP = 5;

    void Start()
    {
        
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
            DJumped = false;
            velocity.z = 0;
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(JHeight * -2f * grav);
        }
        if (Input.GetButtonDown("A button") && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(JHeight * -2f * grav);
        }
        if (Input.GetButtonDown("Jump") && isGrounded == false && DJumped == false)
        {
            DJumped = true;
            velocity.y = Mathf.Sqrt(JHeight * -2f * grav);
        }
        if (Input.GetButtonDown("A button") && isGrounded == false && DJumped == false)
        {
            DJumped = true;
            velocity.y = Mathf.Sqrt(JHeight * -2f * grav);
        }
        if (Input.GetButtonDown("Submit") && isGrounded == false)
        {
            velocity.z = Mathf.Sqrt(dashDistance);
        }
        if (Input.GetButtonDown("B button") && isGrounded == false)
        {
            velocity.z = Mathf.Sqrt(dashDistance);
        }

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("right Trigger"))
        {
            mousePos = Input.mousePosition;
            Rigidbody GHookInstance;
            GHookInstance = Instantiate(projectile, SpawnLocation.position, SpawnLocation.rotation);
            GHookInstance.AddForce(SpawnLocation.forward * Range);


        }
        if (Input.GetButtonDown("Fire2") || Input.GetButtonDown("left Trigger"))
        {
            Rigidbody weaponInstance;
            weaponInstance = Instantiate(grappleingHook, SpawnLocation.position, Quaternion.LookRotation(transform.forward)) as Rigidbody;
            //weaponInstance.AddForce(SpawnLocation.forward * Range);
            //StartCoroutine(hookUsed());
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += grav * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (HP <= 0)
        {
            //load end screen
        }
    }
}

