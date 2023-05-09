using Commands;
using CommandsDemo;

Task<Response> ActionOne() => Task.FromResult(new Response("Testing Action One", true));
Task<Response> ActionTwo() => Task.FromResult(new Response("Testing Action Two"));

var commandLibrary = new CommandLibrary<ImplementationCommandNames>
{
    { ImplementationCommandNames.ActionOne, new Command(ActionOne)},
    { ImplementationCommandNames.ActionTwo, new Command(ActionTwo)}
};

var r = new Receiver(commandLibrary.Values);
var results = r.Execute();
await foreach(var result in results)
    Console.WriteLine(result.ResponseMessage);
