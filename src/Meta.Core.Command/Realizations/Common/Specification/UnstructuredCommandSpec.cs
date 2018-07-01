//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

using static metacore;


/// <summary>
/// Represents an command specification for which type information has been extricated. 
/// </summary>
public class UnstructuredCommandSpec
{


    public UnstructuredCommandSpec ExpandVariables()
    {
        var src = this;
        return new UnstructuredCommandSpec
        {
            CommandName = src.CommandName,
            SpecName = src.SpecName,
            Arguments = src.Arguments.ExpandVariables(),
            CommandJson = src.CommandJson
        };
    }

    public UnstructuredCommandSpec()
    {

    }


    public UnstructuredCommandSpec(string CommandName, string SpecName, string CommandJson, CommandArguments Arguments)
    {
        this.CommandName = CommandName;
        this.SpecName = SpecName;
        this.CommandJson = CommandJson;
        this.Arguments = Arguments;
    }


    public UnstructuredCommandSpec(string CommandName, string CommandJson, CommandArguments Arguments)
    {
        this.CommandName = CommandName;
        this.SpecName = CommandName;
        this.CommandJson = CommandJson;
        this.Arguments = Arguments;
    }


    public string CommandName { get; set; }

    public string CommandDescription { get; set; }

    public string SpecName { get; set; }

    public string CommandJson { get; set; }

    public CommandArguments Arguments { get; set; }

    public override string ToString()
        => $"{CommandName}: {SpecName}";

    public ICommandSpec<TSpec> Restructure<TSpec>(IJsonSerializer serializer)
        where TSpec : CommandSpec<TSpec>, new()
            => serializer.ObjectFromJson<TSpec>(CommandJson);

    public ICommandSpec<TSpec,TPayload> Restructure<TSpec,TPayload>(IJsonSerializer serializer)
        where TSpec : CommandSpec<TSpec,TPayload>, new()
            => serializer.ObjectFromJson<TSpec>(CommandJson);

}


