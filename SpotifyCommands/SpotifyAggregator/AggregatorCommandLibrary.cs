using Commands;

namespace SpotifyCommands.SpotifyAggregator;

public enum AggregatorCommandNames
{
    CommandOne
}

public static class AggregatorCommandLibrary
{
    public static CommandLibrary<AggregatorCommandNames> Lookup =>
        new CommandLibrary<AggregatorCommandNames>
        {
            { AggregatorCommandNames.CommandOne, new Command() }
        }; 
}