using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    AudioSource audioSource;
    
   

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
    public void OnMovement(InputValue input)
    {
        if (audioSource.clip != SoundBank.Instance.stepAudio)
        {
            audioSource.clip = SoundBank.Instance.stepAudio;
            audioSource.loop = true;

        }
        if (!audioSource.isPlaying) { audioSource.Play(); }
        
    }
    private void OnMovementStop(InputValue input)
    {
        audioSource.Stop();
        //audioSource.Pause();
    }

}
