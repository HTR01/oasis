using GameAnalyticsSDK.Setup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float sprintSpeed = 24f;
    public float baseSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity, move;

    public static float moveTotal;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;
    public static bool isCrouched = false;
    //public GameObject waterTint;

    public static bool water;
    GameObject player;
    public GameObject cam;
    float sprint;
    float acceleration = 1.5f;
    public Camera FPCam;


    private void Start()
    {
        player = this.gameObject;        
    }


    void Update()
    {
        moveTotal = move.x + move.y + move.z;

        if (water == false)
        {
            groundMove();
        }
        else
        {
            Swimming();
        }
    }


    void groundMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("SlowWalk"))
        {
            speed = speed / 2;
            isCrouched = true;
            FPCam.fieldOfView = 50;
        }

        if (Input.GetButtonUp("SlowWalk"))
        {
            speed = speed * 2;
            isCrouched = false;
            FPCam.fieldOfView = 60;
        }

        if (Input.GetButtonDown("Sprint") && water == false)
        {
            speed = sprintSpeed;
            FPCam.fieldOfView = 70;
        }

        if (Input.GetButtonUp("Sprint") && water == false)
        {
            speed = baseSpeed;
            FPCam.fieldOfView = 60;
        }
    }


    
    void Swimming()
    {
        float moveSprint = Input.GetAxis("Vertical") * (1f + Input.GetAxis("Sprint") * acceleration / 3);
        Vector3 moveX = moveSprint * cam.GetComponent<MouseLook>().Ahead;
        Vector3 moveZ = Input.GetAxis("Horizontal") * cam.GetComponent<MouseLook>().Side;

        move = moveX + moveZ;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButton("Jump"))
        {
            transform.position += new Vector3(0, 0.5f, 0);
        }
        if (Input.GetButton("SlowWalk"))
        {
            transform.position -= new Vector3(0, 0.5f, 0);
        }

        print(Input.GetAxis("lift"));
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            water = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            water = false;
            speed = baseSpeed;
        }
    }
}
