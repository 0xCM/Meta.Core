//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;

    using N = SystemNode;

    public interface ILinkedShellSession : ILinkedComponent, IShellSession
    {                   
        void SubmitCommand(Type CommandType, SystemUri uri, CorrelationToken? ct);

        Option<CommandSubmission<TSpec>> SubmitCommand<TSpec>(TSpec Command, N DstNode, CorrelationToken? ct)
            where TSpec : CommandSpec<TSpec>, new();

        Option<CommandSubmission> SubmitCommand(N DstNode, ICommandSpec spec, CorrelationToken? ct);

        Option<ReadOnlyList<CommandSubmission<TSpec>>> SubmitCommands<TSpec>(N DstNode, IEnumerable<TSpec> commands, CorrelationToken? ct)
           where TSpec : CommandSpec<TSpec>, new();

        Option<int> SaveCommand(ICommandSpec command);

        Option<TResult> ExecuteCommand<TSpec, TResult>(TSpec command, CorrelationToken? ct)
            where TSpec : CommandSpec<TSpec, TResult>, new();
                   
        IAppMessage ListItem(object item);

        IReadOnlyList<IAppMessage> ListItems(IEnumerable<object> items);

        IReadOnlyList<IAppMessage> ListItems<T>(IEnumerable<T> items, Func<T, string> formatter);

        void setValue(string SettingName, string SettingValue);

        void Notify(IAppMessage m);



    }
}
