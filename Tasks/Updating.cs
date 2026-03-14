namespace Tasks.UpdateUtil;

public class Update
{
    private Random random = new Random();

    public Task CheckForUpdate()
    {
        Console.WriteLine("Checking for updates...");
        Console.WriteLine("Dota 3 beta is available");
        return Task.CompletedTask;
        
    }
    public Task DownloadUpdate()
    {
        Console.WriteLine("Downloading update...");

        if (random.Next() % 2 == 0)
        {
            throw new Exception("aнлак2");
        }
        return Task.CompletedTask;
    }
}