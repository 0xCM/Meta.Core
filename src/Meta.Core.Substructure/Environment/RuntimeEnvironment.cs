//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;


/// <summary>
/// Represents an execution/runtime environment
/// </summary>
public class RuntimeEnvironment 
{
    public static implicit operator string(RuntimeEnvironment environment) 
        => environment.Name;

    public static implicit operator RuntimeEnvironment(string name)
        => RuntimeEnvironments.TryFind(
                x => x.Name == name).ValueOrDefault(RuntimeEnvironments.NONE);
    
    /// <summary>
    /// The environment name
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// The environment classification
    /// </summary>
    public readonly RuntimeEnvironmentKind Type;

    /// <summary>
    /// Initializes a new <see cref="RuntimeEnvironment"/> instance
    /// </summary>
    /// <param name="Name">The name of the environment</param>
    public RuntimeEnvironment(string Name, RuntimeEnvironmentKind Type)
    {
        this.Name = Name;
        this.Type = Type;
    }

    public override string ToString()
        => Name;

}


