using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip startClip, backClip, levelOpenClip, completeClip, tapSound, bounceClip, blastClip, errorClip;

    [Header("Cat Game")]
    [SerializeField] AudioClip jumpClip, dieClip, wonClip;

    private void Awake()
    {
        Instance = this;
    }

    public void StartSound()
    {
        audioSource.PlayOneShot(startClip);
    }

    public void BackSound()
    {
        audioSource.PlayOneShot(backClip);
    }

    public void LevelOpenSound()
    {
        audioSource.PlayOneShot(levelOpenClip);
    }

    public void CompleteSound()
    {
        audioSource.PlayOneShot(completeClip);
    }

    public void TapSound()
    {
        audioSource.PlayOneShot(tapSound);
    }

    public void BounceSound()
    {
        audioSource.PlayOneShot(bounceClip);
    }

    public void BlastSound()
    {
        audioSource.PlayOneShot(blastClip);
    }

    public void ErrorSound()
    {
        audioSource.PlayOneShot(errorClip);
    }

    public void JumpSound()
    {
        audioSource.PlayOneShot(jumpClip);
    }
    public void DeadSound()
    {
        audioSource.PlayOneShot(dieClip);
    }

    public void WonSound()
    {
        audioSource.PlayOneShot(wonClip);
    }
}
