using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    public GameObject[] cars;
    public GameObject[] cameras;
    private int indexCar;

    private void Awake()
    {
        indexCar = PlayerPrefs.GetInt("SelectCar");

        for (int i = 0; i < cars.Length; i++)
        {
            if (i == indexCar)
            {
                cars[i].SetActive(true);
            }
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == indexCar)
            {
                cameras[i].SetActive(true);
            }
        }
         
    }
}
