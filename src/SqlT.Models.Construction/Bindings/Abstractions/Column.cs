//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings
{
    using System;    

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;

    partial class TypeStructures
    {
        public abstract class Column<T> : Element<T, SqlColumn, SqlColumnName>, IColumn
            where T : Column<T>, new()
        {
            protected Column(SqlColumnName Name, sxc.data_type_ref DataType, int Position)
            {
                this.Name = Name;
                this.DataType = DataType;
                this.Position = Position;            
            }

            public override SqlColumnName Name { get; }

            public sxc.data_type_ref DataType { get; }

            public int Position { get; }

            public override string ToString()
                => $"{Position.ToString().PadLeft(2, '0')} {Name} {DataType}";
        }
    }
}