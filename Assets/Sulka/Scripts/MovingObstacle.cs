using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Vector2 targetPos;

    [SerializeField] Transform wavepointParent;
    List<Transform> wavepoints;
    int pointIndex = 0;
    int wavepointCount = 0;
    int direction = 1;

    private void Awake()
    {
        addWavepoints();
    }
    void Start()
    {
    }

    void addWavepoints()
    {
        wavepointCount = wavepointParent.childCount;
        for (int i = 0; i < wavepointCount; i++)
        {
            wavepoints.Add(wavepointParent.GetChild(i));
        }
    }


}
