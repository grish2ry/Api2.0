namespace Tasks.ShowSplashUtil;
public class ShowSplash : ITask
{
    private Task t;
    public Task GetTask()
    {
        return Task.Run(() =>
        {
            Console.WriteLine("=========some header=========");
        });
    }
}