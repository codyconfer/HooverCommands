namespace Commands;

public record Command(Func<Task<Response>>? Action = null)
{
    public Func<Task<Response>> Action = 
        Action ?? (() => Task.FromResult(new Response()));

    public Response? Result { get; set; }
}

public record Response(string ResponseMessage = "", bool HasError = false);

public class CommandLibrary<TCommandName> :
    Dictionary<TCommandName, Command> 
    where TCommandName : Enum { }