using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableButton : MonoBehaviour
{
    [SerializeField] LineController line;
    bool isUsed = false;
    private void OnMouseDown()
    {
        if(!isUsed)
        {
            isUsed = true;
            line.LineRetraction();
        }
    }
}
