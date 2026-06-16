using System.Collections;
using UnityEngine;

public class DayStats : MonoBehaviour
{
    public static DayStats instance;
    
    void Awake() 
    { 
        instance = this; 
    }
    
    private int stepCount = 0;
    private int coffeeCount = 0;
    private int inkCount = 0;
    private int azarlanmaCount = 0;
    private int birdOnHeadSeconds = 0;
    private int vantOnHeadSeconds = 0;
    private int employeesSleepingSeconds = 0;
    private int sitandstandupCount = 0;
    private int mailCount = 0;
    private int employeeAngerSeconds = 0;
    
    //1 saniye beklemesi için gerekli
    private IEnumerator WaitAndIncrease(System.Action action)
    {
        yield return new WaitForSeconds(1f);
        action();
    }
    // #########
    
    public void AzarlanmaCounter()
    {
        this.azarlanmaCount++;
    }

    public void VantOnHeadCounter()
    {
        StartCoroutine(WaitAndIncrease(() => vantOnHeadSeconds++));
    }
    public void BirdOnHeadSeconds()
    {
        StartCoroutine(WaitAndIncrease(() => birdOnHeadSeconds++));
    }

    
    public void EmployeesSleepingCounter()
    {
        StartCoroutine(WaitAndIncrease(() => employeesSleepingSeconds++));
    }
    
  
    public void IncreaseStepCount()
    {
        this.stepCount ++;
    }

    public void IncreaseCoffeeCount()
    {
        this.coffeeCount ++;
    }

    public void IncreaseInkCount()
    {
        this.inkCount++;
    }

    
    public void IncreaseSitandstandupCount()
    {
        this.sitandstandupCount++;
    }

    public void IncreaseMailCount()
    {
        this.mailCount++;
    }
    
    public void IncreaseEmployeeAngerSeconds()
    {
        StartCoroutine(WaitAndIncrease(() => employeeAngerSeconds++));
    }
    
    public void PrintStats()
    {
        Debug.Log($"step count: {stepCount}");
        Debug.Log($"coffee count: {coffeeCount}");
        Debug.Log($"ink count: {inkCount}");
        Debug.Log($"azarlanma count: {azarlanmaCount}");
        Debug.Log($"bird on head seconds: {birdOnHeadSeconds}");
        Debug.Log($"sit and standup count: {sitandstandupCount}");
        Debug.Log($"mail count: {mailCount}");
        Debug.Log($"total employeeAngerSeconds: {employeeAngerSeconds}");
        Debug.Log($"vant on head count: {vantOnHeadSeconds}");
        Debug.Log($"average time per employee sleeping: {employeesSleepingSeconds/4.0}");
    }
    
}
