using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxPlayer : MonoBehaviour
{
    BoxLeapManager boxLeapMan;
    Rigidbody2D rb;
    [SerializeField] float forceAmt = 30f;
    [SerializeField] float jumpForceAmt = 40f ;
    [SerializeField] bool isGrounded = false;
    void Start()
    {
        boxLeapMan = BoxLeapManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }

    void frontMovement()
    {
        rb.velocity = new Vector2(forceAmt,rb.velocity.y);
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump");
            rb.AddForce(new Vector3(rb.velocity.x, jumpForceAmt), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        frontMovement();
    }
    private void Update()
    {
        jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GlobalConstants.TAG_GROUND)
        {
            Debug.Log("Ground");
            isGrounded = true;
        }

        if(collision.gameObject.tag == GlobalConstants.TAG_OBSTACLE)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
