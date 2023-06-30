using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPause : MonoBehaviour
{
    public GameObject pausePanel;
    public static bool flagPanel;
    public AudioSource[] allSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (flagPanel == false)
            {
                OffSound();
                flagPanel = true;
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                
            }
            else
            {
                OnSound();
                flagPanel = false;
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
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
}
