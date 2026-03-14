namespace Tasks.SplashUtil;

public class Splash{
    public Task ShowSplash()
    {
        Console.WriteLine("============SOME HEADER===========");
        return Task.CompletedTask;
        
    }
    public Task HideSplash()
    {
        Console.WriteLine("============SOME FOOTER===========");
        return Task.CompletedTask;
    }
}
