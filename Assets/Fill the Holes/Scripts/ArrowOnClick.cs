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
    MovableBox movableBox;

    private void Start()
    {
        movableBox = GetComponentInParent<MovableBox>();
    }
    private void OnMouseDown()
    {
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
}
