using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commands;

public interface IReceiver
{
    public IEnumerable<Command> Commands { get; }
    public IAsyncEnumerable<Response> Execute();
}

public class Receiver : IReceiver
{
    public Receiver(IEnumerable<Command> commands)
    {
        Commands = commands;
    }
    
    public IEnumerable<Command> Commands { get; }

    public virtual async IAsyncEnumerable<Response> Execute()
    {
        foreach (var command in Commands)
        {
            command.Result = await command.Action();
            yield return command.Result;
        }
    }
}