using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] List<Transform> linePoints;
    [SerializeField] float animationTime = 5f;
    int pointsCount;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        pointsCount = linePoints.Count;
        drawLine();
        StartCoroutine(RetractLine());
    }

    // Update is called once per frame
    void Update()
    {
        drawLine();
    }

    void drawLine()
    {
        lineRenderer.positionCount = pointsCount;
        for (int i = 0; i < linePoints.Count; i++)
        {
            lineRenderer.SetPosition(i, linePoints[i].position);
        }
    }

    IEnumerator RetractLine()
    {
        float segmentDuration = animationTime / (pointsCount - 1);

        for (int i = pointsCount - 1; i > 0; i--)
        {
            float startTime = Time.time;
            Vector3 startPosition = linePoints[i-1].position;
            Vector3 endPosition = linePoints[i - 2].position;

            float t = 0f;
            while (t < 1f)
            {
                t = (Time.time - startTime) / segmentDuration;
                lineRenderer.SetPosition(i, Vector3.Lerp(startPosition, endPosition, t));
                yield return null;
            }
            RemovePoint(i);

            /*linePoints[i].position = endPosition;
            linePoints.Remove(linePoints[i]);
            lineRenderer.SetPosition(i, endPosition);*/
            yield return null;
        }
        linePoints.Clear();
    }

    IEnumerator DrawLineAnimation()
    {
        float segmentDuration = animationTime / pointsCount;

        for (int i = 0; i < pointsCount - 1; i++)
        {
            float startTime = Time.time;

            Vector3 startPostion = linePoints[i].position;
            Vector3 endPostion = linePoints[i + 1].position;

            Vector3 pos = startPostion;

            while (pos != endPostion)
            {
                float t = (Time.time - startTime) / segmentDuration;

                pos = Vector3.Lerp(startPostion, endPostion, t);

                for (int j = i + 1; j < pointsCount; j++)
                {
                    lineRenderer.SetPosition(j, pos);
                }
                yield return null;
            }
        }
    }

    public void RemovePoint(int indexToRemove)
    {
        if (indexToRemove >= 0 && indexToRemove < lineRenderer.positionCount)
        {
            // Create a new array to hold the updated positions
            Vector3[] positions = new Vector3[lineRenderer.positionCount - 1];

            // Copy positions from the original array, excluding the point to remove
            int targetIndex = 0;
            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                if (i != indexToRemove)
                {
                    positions[targetIndex++] = lineRenderer.GetPosition(i);
                }
            }

            // Update the LineRenderer with the new positions
            lineRenderer.positionCount = positions.Length;
            lineRenderer.SetPositions(positions);
        }
    }
}