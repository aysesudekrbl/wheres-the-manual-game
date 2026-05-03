using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Clock : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    public float daySeconds = 16f;
    public float startHour = 9f;
    public float endHour = 17f;
   
    public float passedSeconds = 0f;

    void Update()
    {
        
        passedSeconds += Time.deltaTime;

        float dayPercentage = passedSeconds / daySeconds;
        float totalHoursInDay = endHour - startHour;
        float currentTime = startHour + (totalHoursInDay * dayPercentage);

        int currentHour = Mathf.FloorToInt(currentTime);
        int exactMinute = Mathf.FloorToInt((currentTime - currentHour) * 60);
        int displayMinute = (exactMinute / 30) * 30;

        if (passedSeconds >= daySeconds)
        {
            clockText.text = "17.00";
        }
        else{
            clockText.text = currentHour.ToString("00") + ":" + displayMinute.ToString("00");
        }
    }
}
