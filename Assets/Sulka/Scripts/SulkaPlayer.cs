using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SulkaPlayer : MonoBehaviour
{
    [SerializeField] float speed = 200f;
    [SerializeField] float jumpForce = 100f;
    float inputX;
    Rigidbody2D rb;
    Animator anim;
    bool isInAir = false;
    bool stopMovement = false;
    SulkaLevelManager levelMan;
    SoundManager soundManager;
    bool isFlipped = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        levelMan = SulkaLevelManager.Instance;
        soundManager = SoundManager.Instance;
    }

    void Update()
    {
        jump();
    }

    private void FixedUpdate()
    {
        movement();
    }

    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isInAir && !stopMovement)
        {
            Debug.Log("jump");
            soundManager.JumpSound();
            isInAir = true;
            anim.SetBool(GlobalConstants.ANIM_JUMP, true);
            rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    void movement()
    {
        if (stopMovement)
            inputX = 0f;
        else
            inputX = Input.GetAxisRaw("Horizontal");
        if (inputX == 0)
        {
            anim.SetFloat(GlobalConstants.ANIM_SPEED, 0); // Idle
        }
        else
        {
            anim.SetFloat(GlobalConstants.ANIM_SPEED, 1); // Moving
        }

        if(inputX >0 && isFlipped)
        {
            isFlipped = false;
            flip();
        }
        else if(inputX < 0 && !isFlipped)
        {
            isFlipped = true;
            flip();
        }

        rb.velocity = new Vector2((inputX * speed), rb.velocity.y);
    }

    void reloadLevel()
    {
        levelMan.LoadLevel();
    }

    void nextLevel()
    {
        levelMan.NextLevel();
    }

    void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == GlobalConstants.TAG_GROUND)
        {
            isInAir = false;
            anim.SetBool(GlobalConstants.ANIM_JUMP, false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GlobalConstants.TAG_OBSTACLE)
        {
            stopMovement = true;
            anim.SetTrigger(GlobalConstants.ANIM_DEAD);
            soundManager.DeadSound();
            Invoke(nameof(reloadLevel), 2f);
        }

        if(collision.gameObject.tag == GlobalConstants.TAG_ENDPT)
        {
            stopMovement = true;
            anim.SetTrigger(GlobalConstants.ANIM_WON);
            soundManager.WonSound();
            Invoke(nameof(nextLevel), 2f);
        }
    }
}
