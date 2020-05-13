using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity, move;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;



    bool water;
    GameObject player;
    public GameObject cam;
    float sprint;
    float acceleration = 1.5f;


    private void Start()
    {
        player = this.gameObject;
    }


    void Update()
    {
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
    }

    void Swimming()
    {
        float moveSprint = Input.GetAxis("Vertical") * (1 + Input.GetAxis("Sprint") * acceleration);
        Vector3 moveX = moveSprint * cam.GetComponent<MouseLook>().Ahead;
        Vector3 moveZ = Input.GetAxis("Horizontal") * cam.GetComponent<MouseLook>().Side;

        
        move = moveX + moveZ;
        controller.Move(move * speed * Time.deltaTime);

        print(moveX.z);
    }

    private void OnTriggerEnter(Collider other)
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
        }
    }
}
