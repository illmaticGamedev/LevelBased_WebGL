using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MovableBox : MonoBehaviour
{
    bool isMoving = false;
    Vector2 move;
    float xVal, yVal = 0;
    [SerializeField] float speed = 2f;

    public void MoveInDirection(float x, float y)
    {
        if (!isMoving)
        {
            xVal = x;
            yVal = y;
            isMoving = true;
        }
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    void Update()
    {
        if (isMoving)
            moving();
    }

    void moving()
    {
        move = new Vector2(xVal, yVal);
        transform.Translate(move * speed * Time.deltaTime);
    }
}
