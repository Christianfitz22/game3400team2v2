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

    [SerializeField]
    private Transform respawnPoint;

    private float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        distToGround = gameObject.GetComponent<CapsuleCollider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, -1, QueryTriggerInteraction.Ignore);
    }

    private void Movement()
    {
        grounded = controller.isGrounded || isGrounded();
        //grounded = isGrounded();
        Debug.Log(grounded);
        if (grounded && velocity.y < 0)
        {
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

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    public void Respawn()
    {
        transform.SetParent(null);
        controller.enabled = false;
        gameObject.transform.position = respawnPoint.position;
        gameObject.transform.rotation = respawnPoint.rotation;
        velocity.y = 0;
        controller.enabled = true;
    }

    public void AddVelocity(Vector3 add)
    {
        velocity += add;
    }
}
