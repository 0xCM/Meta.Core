//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Build
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using static metacore;

    partial class BuildSyntax
    {

        public abstract class SymbolicPropertyGroup<G> : Group<G, SymbolicVariable>
            where G : SymbolicPropertyGroup<G>
        {

            static IReadOnlyList<ClrProperty> Properties { get; }
               = metacore.rolist(ClrClass.Get<G>().DeclaredPublicInstanceProperties.Where(p => p.PropertyType == typeof(SymbolicVariable)));


            Dictionary<string, SymbolicVariable> PropertyValues { get; }
                = new Dictionary<string, SymbolicVariable>();

            protected SymbolicVariable read([CallerMemberName] string PropertyName = null)
                => PropertyValues.TryFind(PropertyName).ValueOrElse(() => SymbolicVariable.Define(PropertyName));

            protected void write(SymbolicVariable Value, [CallerMemberName] string PropertyName = null)
                => PropertyValues[PropertyName] = SymbolicVariable.Define(PropertyName, Value.Components.ToArray()); 

            public SymbolicPropertyGroup(IEnumerable<SymbolicVariable> Properties, string Label = null, string Condition = null)
                : base("PropertyGroup", Properties, Label, Condition)
            {

            }

            public SymbolicPropertyGroup()
                : this(stream<SymbolicVariable>(), string.Empty, string.Empty)
            {

            }

            public SymbolicPropertyGroup(string Label, string Condition = null)
                : this(stream<SymbolicVariable>(), Label, Condition)
            {

            }

            public SymbolicVariable this[string Name]
            {
                get { return read(Name); }
                set { write(value, Name); }
            }

            public override IEnumerable<SymbolicVariable> Members
                => from p in Properties
                   select (SymbolicVariable)p.GetValue(this);
                

            protected override string FormatMember(SymbolicVariable member)
                => $"{tab()}<{member.VariableName}>{member.Format()}</{member.VariableName}>";

        }



    }
}