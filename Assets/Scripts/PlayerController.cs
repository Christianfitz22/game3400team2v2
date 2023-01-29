using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private bool grounded;
    public float playerSpeed = 1.0f;
    public float jumpHeight = 1.0f;
    public float gravity = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        grounded = controller.isGrounded;
        Debug.Log(grounded);
        Debug.Log(velocity);
        if (grounded && velocity.y < 0)
        {
            Debug.Log("y reset");
            velocity.y = 0;
        }

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        var movement = transform.right * xMove + transform.forward * zMove;
        controller.Move(movement * (playerSpeed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt((jumpHeight * -3f * gravity));
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }
}
