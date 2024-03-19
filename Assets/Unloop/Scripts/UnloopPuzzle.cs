using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloopPuzzle : MonoBehaviour
{
    public bool IsComplete = false;
    [SerializeField] List<UnloopPuzzle> dependentLoops;

    public bool IsLineLocked()
    {
        if(dependentLoops.Count > 0)
        foreach(UnloopPuzzle loop in dependentLoops)
        {
            if (!loop.IsComplete)
            {
                return true;
            }
        }
        return false;
    }
}
