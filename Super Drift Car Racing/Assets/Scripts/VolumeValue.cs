using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    public string nameObject;
    private AudioSource sound;
    private float musicVolume = 1f;
    public static bool flagFirstStart;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        sound.volume = musicVolume;
    }

    public void SetVolume(float volume)
    {
        musicVolume = volume;
        flagFirstStart = true;
        if (nameObject == "VolumeCar") PlayerPrefs.SetFloat(nameObject, musicVolume);
        else if (nameObject == "VolumeMap") PlayerPrefs.SetFloat(nameObject, musicVolume);
    }
}
