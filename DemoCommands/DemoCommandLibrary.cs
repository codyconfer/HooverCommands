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
        new CommandLibrary<DemoCommandNames>
        {
            {
                DemoCommandNames.ActionOne,
                new (() => Task.FromResult(new Result("Testing Action One")))
            },
            {
                DemoCommandNames.ActionTwo,
                new (() => Task.FromResult(new Result("Testing Action Two")))
            },
        };
}