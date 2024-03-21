using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOnClick : MonoBehaviour
{
    public enum DirectionOfArrow
    {
        LEFT,
        RIGHT,
        UP, DOWN,
    };

    [Header("Direction Select")]
    public DirectionOfArrow ArrowDirection;

    [Header("References")]
    [SerializeField] MovableBox movableBox;
    SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.Instance;
        movableBox = GetComponentInParent<MovableBox>();
    }
    private void OnMouseDown()
    {
        soundManager.BounceSound();
        Debug.Log("nouse down detected");
        switch (ArrowDirection)
        {
            case DirectionOfArrow.LEFT:
                movableBox.MoveInDirection(-1f,0f);
                break;
            case DirectionOfArrow.RIGHT:
                movableBox.MoveInDirection(1f, 0f);
                break;
            case DirectionOfArrow.UP:
                movableBox.MoveInDirection(0f, 1f);
                break;
            case DirectionOfArrow.DOWN:
                movableBox.MoveInDirection(0f, -1f);
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collison");
        if (collision.gameObject.tag == GlobalConstants.TAG_OBSTACLE)
        {
            Debug.Log("Collison with obstacle");
            soundManager.TapSound();
            movableBox.StopMoving();
        }
        if (collision.gameObject.tag == GlobalConstants.TAG_ENDPT)
        {
            collision.gameObject.GetComponent<AttachBox>().AcceptBox();
            Destroy(movableBox.gameObject);
        }
    }
}
