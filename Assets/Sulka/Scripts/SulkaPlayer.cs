using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SulkaPlayer : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 200f;
    [SerializeField] float jumpForce = 100f;
    float inputX;

    [Header("References")]
    Rigidbody2D rb;
    Animator anim;
    SulkaLevelManager levelMan;
    SoundManager soundManager;

    [Header("Bools")]
    bool isInAir = false;
    bool stopMovement = false;
    bool isFlipped = false;

    [Header("GravityReverse")]
    bool isReverse = false;
    float gravityVal = 1;
    float revGravityVal = 1;
    [SerializeField] float maxVerticalSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        levelMan = SulkaLevelManager.Instance;
        soundManager = SoundManager.Instance;
        gravityVal = rb.gravityScale;
        revGravityVal = gravityVal * -1;
    }

    void Update()
    {
        jump();
        gravitySwitch();
    }

    private void FixedUpdate()
    {
        movement();
    }

    void gravitySwitch()
    {
        if (isReverse && rb.gravityScale >= revGravityVal)
        {
            rb.gravityScale -= Time.deltaTime * 6;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -maxVerticalSpeed, maxVerticalSpeed));
        }
        else if (!isReverse && rb.gravityScale <= gravityVal)
        {
            rb.gravityScale += Time.deltaTime * 6;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -maxVerticalSpeed, maxVerticalSpeed));
        }
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
            movementSpriteFlip();
        }
        else if(inputX < 0 && !isFlipped)
        {
            isFlipped = true;
            movementSpriteFlip();
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

    void movementSpriteFlip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void gravitySpriteFlip()
    {
        Vector3 localScale = transform.localScale;
        localScale.y *= -1;
        transform.localScale = localScale;
    }
    
    void gravityReverse()
    {

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
            GetComponent<SpriteRenderer>().enabled = false;
            soundManager.DeadSound();
            GameObject ps = levelMan.ParticleSystemSpawn();
            ps.transform.position = transform.position;
            Invoke(nameof(reloadLevel), 2f);
        }

        if(collision.gameObject.tag == GlobalConstants.TAG_ENDPT)
        {
            stopMovement = true;
            anim.SetTrigger(GlobalConstants.ANIM_WON);
            soundManager.WonSound();
            Invoke(nameof(nextLevel), 2f);
        }
        if(collision.gameObject.tag == GlobalConstants.TAG_GRAVITYPLATFORM)
        {
            gravitySpriteFlip();
            isReverse = !isReverse;
            jumpForce *= -1;
        }
    }
}
