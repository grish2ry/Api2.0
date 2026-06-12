namespace Services.Builders;

public class TaskBuilder
{
    public List<Task> prevParallelTasks;
    public TaskBuilder()
    {
        prevParallelTasks = new List<Task>();
    }
    public Task Build(List<Task> prevParallelTasks) => Task.WhenAll(prevParallelTasks);

}