namespace Services.ExeptionWrapUtil;
public static class ExeptionWrapper
{
    public static async Task Safecall(Task t)
    {
        try
        {
            await t;
        }
        catch
        {
            await ErrorHandler.HandleError(t);
        }
    }
}