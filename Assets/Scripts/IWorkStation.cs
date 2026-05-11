public interface IWorkStation
{
    bool IsBroken { get; } 

    float WorkDuration { get; } 

    void OnEmployeeFinished(); 
}