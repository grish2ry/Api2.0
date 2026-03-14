using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Services.ErrorHandlerUtil;
using Tasks.LicenseUtil;
using Tasks.MenuUtil;
using Tasks.SplashUtil;
using Tasks.TaskServiceUtil;
using Tasks.UpdateUtil;

namespace Tasks;

public class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        var tcsL = new TaskCompletionSource<bool>();
        var tcsU = new TaskCompletionSource<bool>();

        var taskService = new TaskService(tcsL, tcsU);
        var menu = new Menu();
        var splash = new Splash();
        var license = new License();
        var update = new Update();

        




        var showSplashTask = splash.ShowSplash();
        var requestLicenseTask = showSplashTask.ContinueWith(
            _ => license.RequestLicense(),
            TaskContinuationOptions.OnlyOnRanToCompletion
        );

        var licenseErrorHandler = requestLicenseTask.ContinueWith(
            t => {
                taskService.SetL();
                ErrorHandler.HandleError(t);
            },
            TaskContinuationOptions.OnlyOnFaulted

        );


        var awaitLicenseOrError = Task.WhenAny(requestLicenseTask, licenseErrorHandler);


        var setupMenuTask = awaitLicenseOrError.ContinueWith(
            async t =>
            {
                if (requestLicenseTask.IsCompletedSuccessfully)
                {
                    Console.WriteLine("License granted, going to next page");
                }
                else
                {
                    await licenseErrorHandler;
                    Console.WriteLine("Still fixing...");
                    await taskService.tcsL.Task;
                    Console.WriteLine("Error with license fixed, going to next page");
                }
                menu.SetupMenu();
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
        ).Unwrap();

        var checkForUpdateTask = showSplashTask.ContinueWith(
            _ => update.CheckForUpdate(),
            TaskContinuationOptions.OnlyOnRanToCompletion
        );

        var dounloadUpdateTask = checkForUpdateTask.ContinueWith(
            _ => update.DownloadUpdate(),
            TaskContinuationOptions.OnlyOnRanToCompletion
        );

        var dounloadErrorHandler = dounloadUpdateTask.ContinueWith(
            t => {
                taskService.SetU();
                ErrorHandler.HandleError(t);
            },
            TaskContinuationOptions.OnlyOnFaulted
        );



        var awaitUpdateOrError = Task.WhenAny(dounloadErrorHandler, dounloadUpdateTask);


        var finalTask = Task.WhenAll(awaitUpdateOrError, setupMenuTask);

        var taskMenuWelcome = finalTask.ContinueWith(
            async t=>{
                if (dounloadUpdateTask.IsCompletedSuccessfully)
                {
                    Console.WriteLine("Update downloaded, going to next page");
                }
                else
                {
                    await dounloadErrorHandler;
                    Console.WriteLine("Still fixing...");
                    await taskService.tcsU.Task;
                    Console.WriteLine("Error with update fixed, going to next page");
                }

                menu.Welcome();
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
        ).Unwrap();


        var hideSplashTask = taskMenuWelcome.ContinueWith(
            _ => splash.HideSplash(),
            TaskContinuationOptions.OnlyOnRanToCompletion
        );

        app.MapGet("/", async() => 
        {

            await showSplashTask;

            if (showSplashTask.IsCompleted)
            {
                Console.WriteLine("Вся цепочка выполнена!");
            }

        }
        );



        app.Run();
    }
}











