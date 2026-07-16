using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RulesFiller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Rule1;
    [SerializeField] private TextMeshProUGUI Rule2;
    [SerializeField] private TextMeshProUGUI Rule3;


    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void OnEnable()
    {
        StartCoroutine(FillBarsNextFrame());
    }

    private System.Collections.IEnumerator FillBarsNextFrame()
    {
        yield return null;
        List<string> list = NicknameSystem.instance.GetRulebookForToday(DayStats.instance);
        Rule1.text = list[0];
        Rule2.text = list[1];
        Rule3.text = list[2];
    }
}
