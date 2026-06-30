using TMPro;
using UnityEngine;

public class StatsFiller : MonoBehaviour
{
    
    [SerializeField] private Transform dutyInside;
    [SerializeField] private Transform absurdityInside;
    [SerializeField] private Transform sufferingInside;
    [SerializeField] private TextMeshProUGUI nicknameText;
    
    public void OnEnable()
    {
        StartCoroutine(FillBarsNextFrame());
    }

    private System.Collections.IEnumerator FillBarsNextFrame()
    {
        yield return null; // bir frame bekle, herkesin Awake'i bitsin

        var normalized = NicknameSystem.instance.NormalizeStats(DayStats.instance);
        var scores = NicknameSystem.instance.calculateGroupScores(normalized);

        dutyInside.localScale = new Vector3(Mathf.Clamp01(scores.duty), 1f, 1f);
        absurdityInside.localScale = new Vector3(Mathf.Clamp01(scores.absurdity), 1f, 1f);
        sufferingInside.localScale = new Vector3(Mathf.Clamp01(scores.suffering), 1f, 1f);
        
        nicknameText.text = NicknameSystem.instance.GetNickname(DayStats.instance);
    }
}
