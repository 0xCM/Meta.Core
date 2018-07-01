namespace Meta.Core
{
    using cls = Meta.Core.Shell.commands_spec;

    public static class CommandX
    {
        public static IConsoleCommand Adapt(this ShellCommand command, int pos = 0)
            => new ConsoleCommand(command, pos);


        public static cls.setx setx(this EnvironmentVariable variable, string value)
            => new cls.setx(variable, value);

        public static IMutableContext WithDefaultCommandProvider(this IMutableContext C)
        {
            ShellCommandProvider.InjectProviders(C, true);
            return C;
        }


    }
}
