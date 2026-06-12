namespace Tasks.UpdateUtil;
public class UpdateCheck : ITask
{
    public Task GetTask()
    {
        return Task.Run( ()=>
        {
            Console.WriteLine("Checking updates...");
        });
    }
}