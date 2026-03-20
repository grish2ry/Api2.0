namespace Tasks.MenuUtil;
public class Menu : ITask
{
      public Task GetTask()
    {
        return Task.Run( ()=>
        {
            Console.WriteLine("Demo menu");
        });
    }
}