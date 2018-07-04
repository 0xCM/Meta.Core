//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Syntax;
    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Specifies the name of a Script
    /// </summary>
    public sealed class SqlScriptName : SqlName<SqlScriptName>
    {
        
        public static new SqlScriptName Parse(string s)
            => new SqlScriptName(s);

        public static implicit operator SqlScriptName(string Value)
            => new SqlScriptName(Value);

        public SqlScriptName(string Value)
            : base(Value)
        { }


        public SqlScriptName()
            : this(string.Empty)
        { }
                  


        public SqlScriptName(IName SqlName)
            : base(SqlName)
        { }

        public override string ToString()
            => UnqualifiedName;

    }
}
