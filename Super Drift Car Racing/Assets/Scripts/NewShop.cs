using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewShop : MonoBehaviour
{
    public Text textCoin;
    public int access, price;
    public string objectName;
    public GameObject block;
    private void Awake()
    {
        textCoin.text = PlayerPrefs.GetInt("Money").ToString();
    }

    void AccessUpdate()
    {
        access = PlayerPrefs.GetInt(objectName + "Access");

        if (access == 1)
        {
            block.SetActive(false);
        }
    }

    public void Buy()
    {
        int coins = PlayerPrefs.GetInt("Money");

        if (access == 0)
        {
            if (coins >= price)
            {
                PlayerPrefs.SetInt(objectName + "Access", 1);
                PlayerPrefs.SetInt("Money", coins - price);
                textCoin.text = PlayerPrefs.GetInt("Money").ToString();
                AccessUpdate();
            }
        }
    }
}
