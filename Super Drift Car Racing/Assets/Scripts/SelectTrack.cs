using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTrack : MonoBehaviour
{
    private GameObject[] tracks;
    private int indexer;

    private void Start()
    {
        indexer = PlayerPrefs.GetInt("SelectTrack");

        tracks = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            tracks[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in tracks)
        {
            go.SetActive(false);
        }

        if (tracks[indexer])
        {
            tracks[indexer].SetActive(true);
        }
    }

    public void SelectLeft()
    {
        tracks[indexer].SetActive(false);
        indexer--;
        if (indexer < 0)
        {
            indexer = tracks.Length - 1;
        }
        tracks[indexer].SetActive(true);
    }

    public void SelectRight()
    {
        tracks[indexer].SetActive(false);
        indexer++;
        if (indexer == tracks.Length)
        {
            indexer = 0;
        }
        tracks[indexer].SetActive(true);
    }
}
