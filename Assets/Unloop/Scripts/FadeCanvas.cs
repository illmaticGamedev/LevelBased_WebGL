using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvas : MonoBehaviour
{
    UnloopManager unloopManager;
    void Start()
    {
        unloopManager = UnloopManager.Instance;
    }

    public void RestartCurrentLevel()
    {
        unloopManager.LevelSpawn();
    }
}
