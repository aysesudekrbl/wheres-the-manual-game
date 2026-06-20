using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class NicknameSystem : MonoBehaviour
{
    public NicknameData data;
    public static NicknameSystem instance;

    void Awake()
    {
        instance = this;
    }

    public Dictionary<string, float> NormalizeStats(DayStats stats)
    {
        Dictionary<string, float> normalized = new Dictionary<string, float>();
        normalized["stepCount"] = stats.stepCount / data.maxValues["stepCount"];
        normalized["coffeeCount"] = stats.coffeeCount / data.maxValues["coffeeCount"];
        normalized["inkCount"] = stats.inkCount / data.maxValues["inkCount"];
        normalized["azarlanmaCount"] = stats.azarlanmaCount / data.maxValues["azarlanmaCount"];
        normalized["birdOnHeadSeconds"] = stats.birdOnHeadSeconds / data.maxValues["birdOnHeadSeconds"];
        normalized["vantOnHeadSeconds"] = stats.vantOnHeadSeconds / data.maxValues["vantOnHeadSeconds"];
        normalized["employeesSleepingSeconds"] = stats.employeesSleepingSeconds / data.maxValues["employeesSleepingSeconds"];
        normalized["sitandstandupCount"] = stats.sitandstandupCount / data.maxValues["sitandstandupCount"];
        normalized["mailCount"] = stats.mailCount / data.maxValues["mailCount"];
        normalized["employeeAngerSeconds"] = stats.employeeAngerSeconds / data.maxValues["employeeAngerSeconds"];

        return normalized;
    }

    public string FindUniqueNickname(Dictionary<string, float> normalized)
    {
        string bestStat = null;
        float bestValue = 0.9f;
        foreach (KeyValuePair<string, float> normalized_data in normalized)
        {
            if ((normalized_data.Value) >= bestValue)
            {
                bestStat = normalized_data.Key;
                bestValue = normalized_data.Value;
            }
        }

        return bestStat;
    }


    public (float duty, float absurdity, float suffering) calculateGroupScores(Dictionary<string, float> normalized)
    {
        float absurdityScore = 0f, dutyScore = 0f, sufferingScore = 0f;
        foreach (KeyValuePair<string, float> normalized_data in normalized)
        {
            if (data.absurdityStats.Contains(normalized_data.Key))
            {
                absurdityScore += normalized_data.Value;
            }

            if (data.dutyStats.Contains(normalized_data.Key))
            {
                dutyScore += normalized_data.Value;
            }

            if (data.sufferingStats.Contains(normalized_data.Key))
            {
                sufferingScore += normalized_data.Value;
            }
        }

        absurdityScore = absurdityScore / data.absurdityStats.Count;
        dutyScore = dutyScore / data.dutyStats.Count;
        sufferingScore = sufferingScore / data.sufferingStats.Count;
        return (dutyScore, absurdityScore, sufferingScore);

    }

    public string ScoreToLevel(float score)
    {
        if (score <= 0.33) return "LOW";
        else if (score <= 0.66) return "MID";
        else return "HIGH";
    }

    public string calculateLevels(Dictionary<string, float> normalized)
    {
        string result = "";
        var scores = calculateGroupScores(normalized);
        float absurdityScore = scores.absurdity;
        float dutyScore = scores.duty;
        float sufferingScore = scores.suffering;

        result += ScoreToLevel(dutyScore);
        result += "_";
        result += ScoreToLevel(absurdityScore);
        result += "_";
        result += ScoreToLevel(sufferingScore);

        return result;
    }


    public string getNickname(Dictionary<string, float> normalized)
    {
        string special = FindUniqueNickname(normalized);
        if (special != null)
        {
            return data.specialNicknames[special];
        }
        else
        {
            return data.nicknames[calculateLevels(normalized)];
        }
    }

    public List<string> findTopStats(Dictionary<string, float> normalized)
    {
        var sorted = normalized.OrderByDescending(x => x.Value);
        List<String> topStats = new List<String>();
        int count = 0;
        foreach (var pair in sorted)
        {
            if (count == 3) break;
            topStats.Add(pair.Key);
            count++;
        }

        return topStats;
    }

    public List<string> findSentences(List<string> topStats)
    {

        List<string> result = new List<string>();
        
        foreach (string stat in topStats)
        {
            List<string> sentences = data.rulebookLines[stat];
            int randomIndex = UnityEngine.Random.Range(0, sentences.Count);
            result.Add(sentences[randomIndex]);
        }

        return result;
    }


    public string GetNickname(DayStats stats)
    {
        var normalized = NormalizeStats(stats);
        return getNickname(normalized);
    }
    
    public List<string> GetRulebookForToday(DayStats stats)
    {
        var normalized = NormalizeStats(stats);
        var topStats = findTopStats(normalized);
        return findSentences(topStats);
    }
    
    
    //BUNU BURDAN KALDIRMAYI UNUTMA
    public void DebugPrintEndOfDay(DayStats stats)
    {
        string nickname = GetNickname(stats);
        List<string> lines = GetRulebookForToday(stats);

        Debug.Log("Nickname: " + nickname);
        Debug.Log("Rule 1: " + lines[0]);
        Debug.Log("Rule 2: " + lines[1]);
        Debug.Log("Rule 3: " + lines[2]);
    }
    }
    

