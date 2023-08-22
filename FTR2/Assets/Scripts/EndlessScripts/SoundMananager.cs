using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMananager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip wingSound;

    public void PlayWingSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(wingSound);   
        }
    }
}
