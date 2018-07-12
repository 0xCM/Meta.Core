//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

using static metacore;

/// <summary>
/// Defines a correspondence between a command specificatation and a block of text
/// </summary>
public sealed class TextCommand : ICommandSpec
{
    public TextCommand(string Text)
    {
        this.Text = Text;
        Arguments = new CommandArguments(stream(new CommandArgument(nameof(Text), Text)));
    }

    CommandArguments Arguments { get; }

    public string Text { get; }

    CommandName ICommandSpec.CommandName
        => string.Empty;

    string ICommandSpec.CommandDescription
        => string.Empty;

    string ICommandSpec.CommandArea
        => string.Empty;

    string ICommandSpec.CommandAction
        => string.Empty;

    string ICommandSpec.SpecName
        => Text;

    CommandArguments ICommandSpec.Arguments
        => Arguments;

    public override string ToString()
        => Text;

    IAppMessage ICommandSpec.DescribeIntent()
        => AppMessage.Empty;

    ICommandSpec ICommandSpec.ExpandVariables()
        => this;
}