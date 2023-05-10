using Commands;

namespace DemoCommands;

public enum DemoCommandNames
{
    ActionOne,
    ActionTwo
}

public static class DemoCommandLibrary
{
    public static CommandLibrary<DemoCommandNames> Lookup =>
        new()
        {
            {
                DemoCommandNames.ActionOne,
                new Command("Testing Action One")
            },
            {
                DemoCommandNames.ActionTwo,
                new Command("Testing Action Two")
            },
        };

    public static IEnumerable<Command> DemoSet => new List<Command>
    {
        Lookup[DemoCommandNames.ActionOne],
        Lookup[DemoCommandNames.ActionTwo]
    };
}