using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    public void PlaySound(AudioSource sound)
    {
        sound.Play();
    }
}
