using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip startClip, backClip, levelOpenClip, completeClip, tapSound, bounceClip, blastClip;

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
}
