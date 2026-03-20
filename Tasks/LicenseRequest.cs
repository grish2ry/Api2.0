namespace Tasks.LicenseUtil;
public class License : ITask
{
    private Random random = new Random();

      public Task GetTask()
    {
        return Task.Run(() =>
        {
            if(random.Next()%2 == 0)
                throw new Exception("license ex");
            Console.WriteLine("Checking license.....");
        });
    }
}
