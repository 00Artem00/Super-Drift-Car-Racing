using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CheckRace : MonoBehaviour
{
    int countPoint = 0;
    
    private float seconds = 0;
    public static int countFinish = 1;
    public static bool flag = false;
    public int circleCount;
    public Text textCountCircle;
    public string howManyCircle;
    public GameObject winMenu;
    public GameObject[] points;
    public Text DriftScore;
    public Text TotalScoreUI;
    public Text textMoney;
    public Text textSeconds;
    public static float sumMoney;
    int tempMoney = 0;
    int tempRoundMoney = 0;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            countPoint++;
            if (countPoint == points.Length)
            {
                countFinish++;
                if (countFinish == circleCount + 1)
                {
                    textCountCircle.text = " ";
                    flag = true;
                    StartCoroutine(EndFinish());
                    countPoint = 0;
                }
                else
                {
                    textCountCircle.text = "Круг " + countFinish + howManyCircle;
                    countPoint = 0;
                }
            }
            collision.gameObject.SetActive(false);
            points[countPoint].SetActive(true);
        }
    }

    private void Start()
    {
        countFinish = 1;
        countPoint = 0;
        flag = false;
        PrometeoCarController.sumScore = 0;
        seconds = 0;
        sumMoney = 0;
    }
    private void Update()
    {
        float temp = 0;
        if (!flag)
        {
            seconds += Time.deltaTime;
        }
        else
        {
            DriftScore.text = PrometeoCarController.sumScore.ToString("0");
            if (seconds % 60 < 10) textSeconds.text = Mathf.Floor(seconds / 60).ToString("0") + ":0" + (seconds % 60).ToString("0");
            else textSeconds.text = Mathf.Floor(seconds / 60).ToString("0") + ":" + (seconds % 60).ToString("0");
            temp = PrometeoCarController.sumScore / seconds;
            TotalScoreUI.text = Mathf.Round(temp * 100).ToString("0");
            textMoney.text = "+" + Mathf.Ceil(temp).ToString();
        }
    }

    IEnumerator EndFinish()
    {
        yield return new WaitForSeconds(0.7f);
        winMenu.SetActive(true);
        tempMoney = PlayerPrefs.GetInt("Money");
        tempRoundMoney = Mathf.CeilToInt(PrometeoCarController.sumScore / seconds);
        PlayerPrefs.SetInt("Money", tempMoney+ tempRoundMoney);
        DriftScore.enabled = true;
        textSeconds.enabled = true;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0f;
    }
}

