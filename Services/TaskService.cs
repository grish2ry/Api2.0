namespace Services.TaskServiceUtil;

public class TaskService
{
    public List<Task> tasks;
    public TaskBuilder taskBuilder;
    public TaskService()
    {

        tasks = new List<Task>();
        taskBuilder = new TaskBuilder();
    }

    public void AddParallel(ITask task)
    {
        var newTask = task.GetTask();
        tasks.Add(newTask);
    }
    public async Task AddConsistent(ITask task)
    {
        tasks.Add(task.GetTask());
        var newT = taskBuilder.Build(tasks);
        var wrap = ExeptionWrapper.Safecall(newT);
        await wrap;
        tasks.Clear();
        tasks.Add(wrap);
    }
    public void Clear()
    {
        tasks.Clear();
    }   
    public async Task ExecuteAll()
    {
        var wrap = ExeptionWrapper.Safecall(Task.WhenAll(tasks));
        await wrap;
    }
}

