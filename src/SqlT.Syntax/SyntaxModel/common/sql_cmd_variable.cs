//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Syntax;
    using Meta.Models;
    using SqlT.Core;

    using static SqlSyntax;

    partial class SqlSyntax
    {
        /// <summary>
        /// Models a SQLCMD variable
        /// </summary>
        public sealed class sql_cmd_variable : Model<sql_cmd_variable>
        {
            public static implicit operator sql_cmd_variable(string name)
                => new sql_cmd_variable(name);

            public sql_cmd_variable(string Name, string Value = null)
            {
                this.Name = Name;
                this.Value = Value ?? string.Empty;
            }

            public string Name { get; }

            public string Value { get; }

            public override string ToString()
                => $"$({Name})";
        }


        public sealed class sql_cmd_variables : SyntaxList<sql_cmd_variable>
        {
            public static readonly sql_cmd_variables Empty = new sql_cmd_variables();

            public static implicit operator sql_cmd_variables(sql_cmd_variable[] items)
                => new sql_cmd_variables(items);

            public sql_cmd_variables(params sql_cmd_variable[] items)
                : base(items)
            { }
        }        
    }

}