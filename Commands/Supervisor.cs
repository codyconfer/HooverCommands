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

    public virtual Job Job { get; }
    
    public async Task<Status> Run()
    {
        var commands = Job.Execute();
        await foreach(var command in commands)
            Console.WriteLine(command.Result);
        var status = new Status(await commands.ToListAsync());
        return status;
    }
}

public record Status(IEnumerable<Command> Commands)
{
    public bool Complete => Commands.All(x => x.Result != null);
    public bool Error =>  Commands.Any(x => x.Result?.HasError ?? false);
    public bool Success =>  Complete && !Error;
}