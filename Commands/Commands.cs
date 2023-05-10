namespace Commands;

public class Command
{
    public Command(Func<Task<Result>>? action = null)
    {
        Action = action ?? (() => CreateResult.AsyncInProgress());
    }

    public Command(string message) 
        : this(() => CreateResult.AsyncCompleted(message)) { }
    
    public Guid Id { get; } = Guid.NewGuid();

    public Func<Task<Result>> Action { get; }

    public Result Result { get; set; } = new InProgressResult();
}

public record Result(string Message, bool IsComplete, Exception? Exception = null)
{
    public bool HasError => Exception != null;
}
public record InProgressResult(string Message = "") : Result(Message, false);
public record CompletedResult(string Message) : Result(Message, true);
public record FailedResult(string Message, Exception Exception) : Result(Message, true, Exception);

public static class CreateResult
{
    public static Result InProgress(string message = "") => 
        new InProgressResult(message);
    public static Result Completed(string message) => 
        new CompletedResult(message);
    public static Result Failed(string message, Exception exception) => 
        new FailedResult(message, exception);
    public static Task<Result> AsyncInProgress(string message = "") => 
        Task.FromResult(InProgress(message));
    public static Task<Result> AsyncCompleted(string message) => 
        Task.FromResult(Completed(message));
    public static Task<Result> AsyncFailed(string message, Exception exception) => 
        Task.FromResult(Failed(message, exception));
}

public class CommandLibrary<TCommandName> :
    Dictionary<TCommandName, Command> 
    where TCommandName : Enum { }