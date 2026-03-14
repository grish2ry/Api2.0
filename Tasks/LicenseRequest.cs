namespace Tasks.LicenseUtil;

public class License
{
    private Random random = new Random();

    public Task RequestLicense()
    {
        Console.WriteLine("Requesting license...");
        Console.WriteLine("License granted");
        if(random.Next() % 2 == 0)
            throw new TaskCanceledException("анлак1");
        return Task.CompletedTask;
    }

}
