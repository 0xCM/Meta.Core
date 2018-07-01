//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public class CommandServiceDescriptor
{
    IReadOnlyList<string> _Preconditions { get; }
    Option<Type> _SpecType { get; }

    public CommandServiceDescriptor()
    {

    }

    public CommandServiceDescriptor(string CommandName, string SpecTypeName)
    {
        this.CommandName = CommandName;
        this.SpecTypeName = SpecTypeName;
        this.CommandDescription = String.Empty;
        this._Preconditions = ReadOnlyList.Create<string>();
    }

    public CommandServiceDescriptor(string CommandName, Type SpecType, string CommandDescription, params string[] Preconditions)
    {
        this.CommandName = CommandName;
        this.CommandDescription = CommandDescription ?? String.Empty;
        this._Preconditions = Preconditions.ToList();
        this._SpecType = SpecType;
        this.SpecTypeName = SpecType.AssemblyQualifiedName;
    }

    public string CommandName { get; set; }

    public string CommandDescription { get; set; }

    public string SpecTypeName { get; set; }

    public Option<Type> SpecType { get; set; }

    public IReadOnlyList<string> Preconditions 
        => _Preconditions;

        
}




