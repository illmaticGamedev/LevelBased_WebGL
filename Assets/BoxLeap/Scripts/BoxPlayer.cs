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
    public bool IsGrounded = false;
    public bool IsGroundedOnce = false; 
    SoundManager soundManager;
    void Start()
    {
        soundManager = SoundManager.Instance;
        boxLeapMan = BoxLeapManager.Instance;
        rb = GetComponent<Rigidbody2D>();
        ResetPlayer();
    }

    void frontMovement()
    {
        if (IsGroundedOnce)
        rb.velocity = new Vector2(forceAmt,rb.velocity.y);
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(new Vector3(rb.velocity.x, jumpForceAmt), ForceMode2D.Impulse);
            soundManager.BounceSound();
            IsGrounded = false;
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

    public void ResetPlayer()
    {
        IsGrounded = false;
        IsGroundedOnce = false;
        rb.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GlobalConstants.TAG_GROUND)
        {
            IsGrounded = true;
            IsGroundedOnce = true;
        }

        if(collision.gameObject.tag == GlobalConstants.TAG_OBSTACLE)
        {
            boxLeapMan.ResetPlayerPos();
        }
        if(collision.gameObject.tag == GlobalConstants.TAG_ENDPT)
        {
            boxLeapMan.NextLevel();
        }
    }
}
