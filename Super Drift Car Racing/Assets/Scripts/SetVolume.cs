using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioCar;
    [SerializeField] private AudioSource[] audioMap;
    [SerializeField] private Slider sliderCar;
    [SerializeField] private Slider sliderMap;
    private float volumeCar;
    private float volumeMap;

    void Awake()
    {
        volumeCar = PlayerPrefs.GetFloat("VolumeCar");
        if (VolumeValue.flagFirstStart == false)
        {
            volumeCar = 1;
        }

        volumeMap = PlayerPrefs.GetFloat("VolumeMap");
        if (VolumeValue.flagFirstStart == false)
        {
            volumeMap = 1;
        }
        

        for (int i = 0; i < audioCar.Length; i++)
        {
            audioCar[i].volume = volumeCar;
        }
        sliderCar.value = volumeCar;

        for (int i = 0; i < audioMap.Length; i++)
        {
            audioMap[i].volume = volumeMap;
        }
        sliderMap.value = volumeMap;
    }

    private void Update()
    {
        for (int i = 0; i < audioMap.Length; i++)
        {
            audioMap[i].volume = volumeMap;
        }

        for (int i = 0; i < audioCar.Length; i++)
        {
            audioCar[i].volume = volumeCar;
        }
    }

    public void SetVolumeCar(float volume)
    {
        volumeCar = volume;
        VolumeValue.flagFirstStart = true;
        ButtonEvents.flagFirstStart = true;
        if (PlayerPrefs.GetFloat("VolumeMap") == 0) PlayerPrefs.SetFloat("VolumeMap", 1);
        PlayerPrefs.SetFloat("VolumeCar", volumeCar);
    }

    public void SetVolumeMap(float volume)
    {
        volumeMap = volume;
        VolumeValue.flagFirstStart = true;
        ButtonEvents.flagFirstStart = true;
        if (PlayerPrefs.GetFloat("VolumeCar") == 0) PlayerPrefs.SetFloat("VolumeCar", 1);
        PlayerPrefs.SetFloat("VolumeMap", volumeMap);
    }
}
