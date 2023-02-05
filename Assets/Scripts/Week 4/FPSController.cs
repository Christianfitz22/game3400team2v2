using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private bool grounded;
    public float playerSpeed = 1.0f;
    public float jumpHeight = 1.0f;
    public float gravity = -9.81f;

    private float distToGround;

    [SerializeField]
    private StatController stats;
    [SerializeField]
    private int damage;

    private bool reloading;
    [SerializeField]
    private float reloadTime;
    private float elapsedTime;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        distToGround = gameObject.GetComponent<CapsuleCollider>().bounds.extents.y;

        reloading = false;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (!reloading)
        {
            Shooting();
        }
        else
        {
            Reloading();
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f, -1, QueryTriggerInteraction.Ignore);
    }

    private void Movement()
    {
        grounded = controller.isGrounded;
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

    private void Shooting()
    {
        if (stats.ammoCur > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
                {
                    if (hit.collider.gameObject.tag == "Boss")
                    {
                        stats.changeBossHealth(-damage);
                        stats.changeAmmo(-1);
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown("r"))
            {
                reloading = true;
                stats.changeAmmo(stats.ammoMax);
            }
        }
    }

    public void takeDamage(int damageTaken)
    {
        Debug.Log("taken damage");
        stats.changePlayerHealth(-damageTaken);
        if (stats.playerDead())
        {
            Die();
        }
    }

    private void Reloading()
    {
        if (elapsedTime >= reloadTime)
        {
            reloading = false;
            elapsedTime = 0f;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("TestScene");
    }
}
