namespace Tasks.HideSplashUtil;
public class HideSplash : ITask
{
    public Task GetTask()
    {
        return  Task.Run( ()=>
        {
            Console.WriteLine("=========some footer==========");
        });
    }
};
    