namespace Tasks.Downloader;

public class Download : ITask
{
    private Random random = new Random();
    public Task GetTask()
    {
        return Task.Run(() =>
        {
            if(random.Next()%2 == 0)
                throw new Exception("download ex");
            Console.WriteLine("Dounloading...");
        });
    }
}