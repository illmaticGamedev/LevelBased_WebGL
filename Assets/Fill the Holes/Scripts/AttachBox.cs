using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachBox : MonoBehaviour
{
    Animator anim;
    BoxCollider2D boxCollider;
    public bool IsAttached = false;
    FillHoleManager holeManager;
    SoundManager soundManager;
    private void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        soundManager = SoundManager.Instance;
        holeManager = FillHoleManager.Instance;
    }

    public void AcceptBox()
    {
        anim.SetTrigger(GlobalConstants.ANIM_BOXATTACH);
        boxCollider.enabled = false;
        IsAttached = true;
        soundManager.CompleteSound();
        holeManager.CompleteVerification();
    }
}
