using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCar : MonoBehaviour
{
    public GameObject[] block;
    private GameObject[] cars;
    public static int index;


    private void Start()
    {
        index = PlayerPrefs.GetInt("SelectCar");

        cars = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            cars[i] = transform.GetChild(i).gameObject;
        }
        
        foreach (GameObject go in cars)
        {
            go.SetActive(false);
        }

        if (cars[index])
        {
            cars[index].SetActive(true);
        }
    }

    
    public void SelectLeft()
    {
        cars[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = cars.Length - 1;
        }
        cars[index].SetActive(true);
        if (index == 1)
        {
            if (PlayerPrefs.GetInt("FirstCarAccess") == 1)
            {
                block[0].SetActive(false);
            }
            else
            {
                block[0].SetActive(true);
            }
        }
        else
        {
            block[0].SetActive(false);
        }

        if (index == 2)
        {
            if (PlayerPrefs.GetInt("SecondCarAccess") == 1)
            {
                block[1].SetActive(false);
            }
            else
            {
                block[1].SetActive(true);
            }
        }
        else
        {
            block[1].SetActive(false);
        }
    }

    public void SelectRight()
    {
        cars[index].SetActive(false);
        index++;
        if (index == cars.Length)
        {
            index = 0;
        }
        cars[index].SetActive(true);
        if (index == 1)
        {
            if (PlayerPrefs.GetInt("FirstCarAccess") == 1)
            {
                block[0].SetActive(false);
            }
            else
            {
                block[0].SetActive(true);
            }
        }
        else
        {
            block[0].SetActive(false);
        }

        if (index == 2)
        {
            if (PlayerPrefs.GetInt("SecondCarAccess") == 1)
            {
                block[1].SetActive(false);
            }
            else
            {
                block[1].SetActive(true);
            }
        }
        else
        {
            block[1].SetActive(false);
        }
    }
}

