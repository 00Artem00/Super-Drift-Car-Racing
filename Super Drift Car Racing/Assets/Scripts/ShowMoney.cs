using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShowMoney : MonoBehaviour
{
    public Text textCoin;
    private int temp;

    void Start()
    {
        textCoin.text = PlayerPrefs.GetInt("Money").ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            temp = PlayerPrefs.GetInt("Money");
            PlayerPrefs.SetInt("Money", 300 + temp);
            textCoin.text = PlayerPrefs.GetInt("Money").ToString();
        }
    }
}
