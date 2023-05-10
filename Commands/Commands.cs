namespace Commands;

public class Command
{
    public Command(Func<Task<Result>>? action = null)
    {
        Action = action ?? (() => Task.FromResult(new Result()));
    }

    public Command(string message) 
        : this(() => Task.FromResult(new Result(message))) { }

    public Func<Task<Result>> Action { get; }

    public Result Result { get; set; } = new ();
}

public record Result(string Message = "", bool HasError = false);

public class CommandLibrary<TCommandName> :
    Dictionary<TCommandName, Command> 
    where TCommandName : Enum { }