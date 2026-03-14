namespace Tasks.MenuUtil;

public class Menu
{
    public Task SetupMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1 help");
        Console.WriteLine("2 help");
        Console.WriteLine("3 help");
        Console.WriteLine("4 help");
        return Task.CompletedTask;
    }

    public Task Welcome()
    {
        Console.WriteLine("Welcome!!!!!!!!");
        return Task.CompletedTask;
    
    }
}