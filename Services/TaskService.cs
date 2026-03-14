namespace Tasks.TaskServiceUtil;

public class TaskService
{
    public TaskCompletionSource<bool> tcsL {get; private set;}
    public TaskCompletionSource<bool> tcsU {get; private set;}

    public TaskService(TaskCompletionSource<bool> tcsL, TaskCompletionSource<bool> tcsU)
    {
        this.tcsL = tcsL;
        this.tcsU = tcsU;
    }

    public void SetU() => tcsU.TrySetResult(true);
    
    public void SetL() => tcsL.TrySetResult(true);
    
}

