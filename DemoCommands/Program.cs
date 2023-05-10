using Commands;
using DemoCommands;

Job demoJob = new (DemoCommandLibrary.DemoSet);
Supervisor supervisor = new (demoJob);
var status = await supervisor.Run();
Console.WriteLine(status.Success);
