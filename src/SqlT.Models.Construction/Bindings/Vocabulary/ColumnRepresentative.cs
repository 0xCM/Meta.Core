//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings
{
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;

    using System;
    using SqlT.Core;
    using SqlT.Syntax;

    partial class TypeStructures
    {
        public class ColumnRepresentative
        {
            public ColumnRepresentative(IElement DefiningElement, ClrProperty DefiningMember)
            {
                this.DefiningElement = DefiningElement;
                this.DefiningMember = DefiningMember;
            }

            public IElement DefiningElement { get; }

            public ClrProperty DefiningMember { get; }

            public V GetValue<V>()
                => DefiningMember.GetValue<V>(DefiningElement);

            public SqlColumnName ColumnName
                => DefiningMember.Name;

            public string Description
                => DefiningMember.GetCustomAttribute<DescriptionAttribute>()?.Description;

            public override string ToString()
                => DefiningMember.Name;
        }


    }



}