using UnityEngine;
using TMPro;



public class Clock : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    public float daySeconds = 120f;
    public float startHour = 9f;
    public float endHour = 17f;
    private bool _dayEnded;

    public float passedSeconds;

    void Update()
    {
        if (_dayEnded) return;
        passedSeconds += Time.deltaTime;

        float dayPercentage = passedSeconds / daySeconds;
        float totalHoursInDay = endHour - startHour;
        float currentTime = startHour + (totalHoursInDay * dayPercentage);

        int currentHour = Mathf.FloorToInt(currentTime);
        int exactMinute = Mathf.FloorToInt((currentTime - currentHour) * 60);
        int displayMinute = (exactMinute / 30) * 30;

        if (passedSeconds >= daySeconds && !_dayEnded)
        {
            clockText.text = "17.00";
            Time.timeScale = 0;
            _dayEnded = true;
            DayStats.instance.PrintStats(); 
        }
        
        else{
            clockText.text = currentHour.ToString("00") + ":" + displayMinute.ToString("00");
        }
    }
}
