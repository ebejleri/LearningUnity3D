using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioSource healthSound;

    public void PlayHurtSound()
    {
        hitSound.Play();
    }

    public void PlayHealSound()
    {
        healthSound.Play();
    }

}
