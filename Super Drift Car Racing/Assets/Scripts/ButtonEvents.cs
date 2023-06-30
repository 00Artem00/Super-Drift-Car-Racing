using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;

public class ButtonEvents : MonoBehaviour
{
    public GameObject MenuScene;
    public GameObject arrows;
    public GameObject arrowsMenu;
    public static bool flag;
    public AudioSource audioBlock;
    public AudioSource audioOpen;
    public AudioSource[] allSound;
    public Slider sliderCar;
    public Slider sliderMap;
    public static bool flagFirstStart;

    public void ShowMenu()
    {
        if (SelectCar.index == 1)
        {
            if (PlayerPrefs.GetInt("FirstCarAccess") == 1)
            {
                audioOpen.Play();
                MenuScene.SetActive(true);
                arrows.SetActive(false);
                arrowsMenu.SetActive(true);
            }
            else
            {
                audioBlock.Play();
                flag = true;
                StartCoroutine(TwoSeconds());
            }
        }
        else if (SelectCar.index == 2)
        {
            if (PlayerPrefs.GetInt("SecondCarAccess") == 1)
            {
                audioOpen.Play();
                MenuScene.SetActive(true);
                arrows.SetActive(false);
                arrowsMenu.SetActive(true);
            }
            else
            {
                audioBlock.Play();
                flag = true;
                StartCoroutine(TwoSeconds());
            }
        }
        else
        {
            audioOpen.Play();
            MenuScene.SetActive(true);
            arrows.SetActive(false);
            arrowsMenu.SetActive(true);
        }
    }

    public void CloseMenu()
    {
        MenuScene.SetActive(false);
        arrowsMenu.SetActive(false);
        arrows.SetActive(true);
    }

    public void GoClassicTrack()
    {
        PlayerPrefs.SetInt("SelectCar", SelectCar.index);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("ClassicTrack");
    }

    public void GoParkTrack()
    {
        PlayerPrefs.SetInt("SelectCar", SelectCar.index);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("ParkTrack");
    }

    public void GoAtronInternationalTrack()
    {
        PlayerPrefs.SetInt("SelectCar", SelectCar.index);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("AtronInternationalCircuit1");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void GoFreeRace()
    {
        PlayerPrefs.SetInt("SelectCar", SelectCar.index);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("FreeRace");
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator TwoSeconds()
    {
        yield return new WaitForSeconds(2f);
        flag = false;
    }

    public void OnPauseButton(GameObject onPanel)
    {
        OffSound();
        ShowPause.flagPanel = true;
        onPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OffPauseButton(GameObject offPanel)
    {
        OnSound();
        ShowPause.flagPanel = false;
        offPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnSound()
    {
        for (int i = 0; i < allSound.Length; i++)
        {
            allSound[i].Play();
        }
    }

    private void OffSound()
    {
        for (int i = 0; i < allSound.Length; i++)
        {
            allSound[i].Stop();
        }
    }

    public void ShowPanelVolume(GameObject volumePanel)
    {
        if (flagFirstStart == false) FirstStart();
        sliderCar.value = PlayerPrefs.GetFloat("VolumeCar");
        sliderMap.value = PlayerPrefs.GetFloat("VolumeMap");
        audioOpen.Play();
        volumePanel.SetActive(true);
    }

    public void ClosePanelVolume(GameObject volumePanel)
    {
        audioOpen.Play();
        volumePanel.SetActive(false);
    }

    public void ShowPanelAuthor(GameObject panelAuthor)
    {
        audioOpen.Play();
        panelAuthor.SetActive(true);
    }

    public void ClosePanelAuthor(GameObject panelAuthor)
    {
        audioOpen.Play();
        panelAuthor.SetActive(false);
    }

    public void FirstStart()
    {
        PlayerPrefs.SetFloat("VolumeCar", 1);
        PlayerPrefs.SetFloat("VolumeMap", 1);
        flagFirstStart = true;
    }
}
