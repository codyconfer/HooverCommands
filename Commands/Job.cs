using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    
    public IEnumerable<Command> Commands { get; }

    public async IAsyncEnumerable<Command> Execute()
    {
        foreach (var command in Commands)
        {
            command.Result = await command.Action();
            yield return command;
        }
    }
}