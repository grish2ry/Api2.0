class Program
{
    static async Task Main(string[] args)
    {
        //Пример работы (написано ИИ)
        var taskService = new TaskService();
        
        // Сценарий 1: Загрузка с обработкой ошибок
        Console.WriteLine("Scenario 1: Download with error handling");
        var downloadTask = new Download();
        await taskService.AddConsistent(downloadTask);
        
        // Сценарий 2: Параллельная инициализация
        Console.WriteLine("\nScenario 2: Parallel initialization");
        taskService.AddParallel(new License());
        taskService.AddParallel(new UpdateCheck());
        taskService.AddParallel(new Menu());
        
        await taskService.ExecuteAll();
        
        // Сценарий 3: Смешанный подход
        Console.WriteLine("\nScenario 3: Mixed approach");
        taskService.Clear();
        
        // Параллельные подготовительные задачи
        taskService.AddParallel(new ShowSplash());
        taskService.AddParallel(new License());
        
        // Ждем их выполнения
        await taskService.ExecuteAll();
        
        // Последовательные задачи
        await taskService.AddConsistent(new Welcome());
        await taskService.AddConsistent(new Menu());
        await taskService.AddConsistent(new HideSplash());
        
        Console.WriteLine("\nAll scenarios completed successfully!");
    }
}
