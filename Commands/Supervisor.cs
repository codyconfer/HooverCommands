// ReSharper disable PossibleMultipleEnumeration
namespace Commands;

public interface ISupervisor
{
    public Job Job { get; }
    public Task<Status> Run();
}

public class Supervisor : ISupervisor
{
    public Supervisor(Job job)
    {
        Job = job;
    }

    public Job Job { get; }
    
    public async Task<Status> Run()
    {
        var commands = Job.Execute();
        await foreach(var command in commands)
            Console.WriteLine(command.Result);
        var status = new Status(Job.Id, await commands.ToListAsync());
        return status;
    }
}

public record Status(Guid JobId, IEnumerable<Command> Commands)
{
    public bool Complete => Commands.All(x => x.Result.IsComplete);
    public bool Error =>  Commands.Any(x => x.Result.HasError);
    public bool Success =>  Complete && !Error;
}