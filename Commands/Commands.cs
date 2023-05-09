namespace Commands;

public class Command
{
    public Command(Func<Task<Result>>? action = null)
    {
        Action = action ?? (() => Task.FromResult(new Result()));
    }
    
    public Func<Task<Result>> Action { get; }

    public Result? Result { get; set; }
}

public record Result(string Message = "", bool HasError = false);

public class CommandLibrary<TCommandName> :
    Dictionary<TCommandName, Command> 
    where TCommandName : Enum { }