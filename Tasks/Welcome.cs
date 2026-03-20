namespace Tasks.WelcomeUtil;
public class Welcome : ITask
{
      public Task GetTask()
    {
        return Task.Run( ()=>
        {
            Console.WriteLine("Welcome");
        });
    }
}
