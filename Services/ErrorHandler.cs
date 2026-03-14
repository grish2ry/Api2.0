namespace Services.ErrorHandlerUtil;

public static class ErrorHandler
{
    
    public static Task HandleError(Task t)
    {

        Console.WriteLine($"Error {t.Exception.Message} handling...");
        return Task.CompletedTask;
    }
}