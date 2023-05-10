namespace Commands;

public interface IJob
{
    public IEnumerable<Command> Commands { get; }
    public IAsyncEnumerable<Command> Execute();
}

public class Job : IJob
{
    public Job(IEnumerable<Command> commands)
    {
        Commands = commands;
    }

    public Guid Id { get; } = Guid.NewGuid();
    
    public IEnumerable<Command> Commands { get; }

    public async IAsyncEnumerable<Command> Execute()
    {
        foreach (var command in Commands)
        {
            try
            {
                command.Result = await command.Action();
            }
            catch (Exception e)
            {
                command.Result = new FailedResult($"Uncaught error in job {Id} | command {command.Id}", e);
            }
            yield return command;
        }
    }
}