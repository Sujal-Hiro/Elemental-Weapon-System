using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


    public AudioClip frostSFX;
    public AudioClip fireSFX;
    public AudioClip electricSFX;

    public AudioSource audioSource;
    public void PlaySFX(string weaponType)
    {
        AudioClip clipToPlay = null;

        switch (weaponType)
        {
            case "fire":
                clipToPlay = fireSFX;
                break;
            case "ice":
                clipToPlay = frostSFX;
                break;
            case "electric":
                clipToPlay = electricSFX;
                break;
        }

        if (clipToPlay != null && audioSource != null)
        {
            audioSource.PlayOneShot(clipToPlay);
        }
        

    }
}
