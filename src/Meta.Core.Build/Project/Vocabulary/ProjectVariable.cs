//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Defines a named parameter for a <see cref="DevProject"/>
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public class  ProjectVariable<V> : IProjectVariable<V>
    {
        public static readonly ProjectVariable<V> Empty 
            = new ProjectVariable<V>(string.Empty);

        public ProjectVariable(string Name)
        {
            this.Name = Name;
            this.Value = none<V>();
        }

        public ProjectVariable(string Name, V value)
        {
            this.Name = Name;
            this.Value = value;

        }
        
        /// <summary>
        /// The variable name
        /// </summary>
        public string Name { get; }


        /// <summary>
        /// The variable value
        /// </summary>
        public Option<V> Value { get; }

        public string Render()
            => Value.MapValueOrDefault(v => $"{v}", string.Empty);

        object IProjectVariable.Value
            => Value.Map(v => (object)v, ()=> null);

        public virtual ProjectVariable<V> Rename(string NewName)
            => Value.MapValueOrDefault(
                v => new ProjectVariable<V>(NewName, v), 
                @default: new ProjectVariable<V>(NewName)
                );

        public override string ToString()
            => Value.Map(v => $"{v}", () => "$(" + Name + ")");
    }

    public sealed class ProjectVariable : ProjectVariable<ProjectVariable, string>
    {
        public ProjectVariable(string Name, string Value)
            : base(Name, Value)
        {

        }

    }

}
