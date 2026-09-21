using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Animator anim;
    public float moveSpeed = 10f;
    private Rigidbody2D roboManRigidBody;
    private SpriteRenderer roboManSpriteRenderer;
    private Camera cam;
    private bool roboManIsFacingRight = true;
    private bool roboManIsOnTheGround = true;
    private Vector2 jumpForce = new Vector2(0f, 8f);

    void Awake()
    {
        anim = GetComponent<Animator>();
        roboManRigidBody = GetComponent<Rigidbody2D>();
        roboManSpriteRenderer = GetComponent<SpriteRenderer>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && roboManIsOnTheGround)
        {
            Jump();
        }


        float horizontalInputValue = Input.GetAxis("Horizontal");


        Vector2 currentVelocity = new Vector2(horizontalInputValue * moveSpeed, roboManRigidBody.velocity.y);

        roboManRigidBody.velocity = currentVelocity;

        float clampedRoboManX = Mathf.Clamp(transform.position.x, -8, 8);
        transform.position = new Vector3(clampedRoboManX, transform.position.y, transform.position.z);

        if (horizontalInputValue == 0)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }

        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x < transform.position.x && roboManIsFacingRight)
        {
            FlipDirection();
        }
        else if (mousePosition.x > transform.position.x && !roboManIsFacingRight)
        {
            FlipDirection();
        }
    }


    void Jump()
    {
        roboManRigidBody.AddForce(jumpForce, ForceMode2D.Impulse);
    }
    private void FlipDirection()
    {
        roboManSpriteRenderer.flipX = !roboManSpriteRenderer.flipX;
        roboManIsFacingRight = !roboManIsFacingRight;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            roboManIsOnTheGround = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            roboManIsOnTheGround = false;
        }
    }
}
