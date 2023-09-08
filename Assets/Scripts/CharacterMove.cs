using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour
{
    private float moveSpeed;
    private float maxSpeed = 25;
    private float jumpForce = 2500;

    public LayerMask platformLayerMask;
    public bool canJump;

    private Vector2 moveForce; 
    private bool jump;

    public Rigidbody2D characterRigidbody;
    public BoxCollider2D boxCollider2D;

    // Update is called once per frame
    void Update()
    {
        moveForce = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, 0);

        if(canJump)
        {
            if(Input.GetButtonDown("Jump"))
            {
                jump = true;
            }

            moveSpeed = 150;
        }
        else
        {
            moveSpeed = 100;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        Move();

        Jump();
    }

    void Move()
    {
        if (characterRigidbody.velocity.x < maxSpeed && characterRigidbody.velocity.x > -maxSpeed)
        {
            characterRigidbody.AddForce(moveForce);
        }
    }

    void Jump()
    {
        if(jump)
        {
            characterRigidbody.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }
}