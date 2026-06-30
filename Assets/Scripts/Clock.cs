using UnityEngine;
using TMPro;



public class Clock : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    public float daySeconds = 10f;
    public float startHour = 9f;
    public float endHour = 17f;
    private bool _dayEnded;

    public float passedSeconds;
    public GameObject stats;
    public GameObject manualbookbutton;
    public SpriteRenderer pages;
    public GameObject outofpages;

    void Start()
    {
        Time.timeScale = 1;
        _dayEnded = false;
        stats.SetActive(false);
        manualbookbutton.SetActive(false);
        pages.enabled = false;
        outofpages.SetActive(false);
    }
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
            stats.SetActive(true);
            manualbookbutton.SetActive(true);
            DayStats.instance.PrintStats(); 
            NicknameSystem.instance.DebugPrintEndOfDay(DayStats.instance);
        }
        
        else{
            clockText.text = currentHour.ToString("00") + ":" + displayMinute.ToString("00");
        }
    }
}
