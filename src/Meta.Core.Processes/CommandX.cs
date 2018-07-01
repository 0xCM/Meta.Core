namespace Meta.Core
{

    public static class CommandX
    {
    
        public static IConsoleCommand Adapt(this ScriptCommand command, int pos = 0)
            => new ConsoleScriptCommandAdapter(command, pos);




    }
}
