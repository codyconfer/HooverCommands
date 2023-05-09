using Commands;
using DemoCommands;

var commands = new List<Command>
{
    DemoCommandLibrary.Lookup[DemoCommandNames.ActionOne],
    DemoCommandLibrary.Lookup[DemoCommandNames.ActionTwo]
};
Job demoJob = new(commands);
Supervisor supervisor = new (demoJob);
var status = await supervisor.Run();
Console.WriteLine(status.Success);