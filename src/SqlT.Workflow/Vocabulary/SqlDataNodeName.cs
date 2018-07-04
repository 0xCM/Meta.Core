//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{

    using SqlT.Core;
    using SqlT.Syntax;

    /// <summary>
    /// Represents the name of a Script
    /// </summary>
    public sealed class SqlDataNodeName : SqlName<SqlDataNodeName>
    {
        
        public static new SqlDataNodeName Parse(string s)
            => new SqlDataNodeName(s);

        public static implicit operator SqlDataNodeName(string Value)
            => new SqlDataNodeName(Value);

        public SqlDataNodeName(string Value)
            : base(Value)
        { }


        public SqlDataNodeName()
            : this(string.Empty)
        { }
                  


        public SqlDataNodeName(ICompositeSqlName SqlName)
            : base(SqlName)
        { }

        public override string ToString()
            => UnqualifiedName;

    }
}
