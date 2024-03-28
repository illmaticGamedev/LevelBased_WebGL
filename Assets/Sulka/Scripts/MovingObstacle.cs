using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    Transform targetPoint;

    private void Start()
    {
        GameObject newTarget = new GameObject("TargetPoint");
        newTarget.transform.SetParent(transform.parent);
        newTarget.transform.position = point2.position;
        targetPoint = newTarget.transform;
    }

    private void Update()
    {
        moveBetweenPoints();
    }

    void moveBetweenPoints()
    {
        if(transform.position == targetPoint.position)
        {
            switchTarget();
        }
            transform.position = Vector2.MoveTowards(transform.position, targetPoint.transform.position, speed * Time.deltaTime);
    }

    void switchTarget()
    {
        if(targetPoint.position == point1.position)
        {
            targetPoint.position = point2.position;
        }
        else
        {
            targetPoint.position = point1.position;
        }
    }
}
