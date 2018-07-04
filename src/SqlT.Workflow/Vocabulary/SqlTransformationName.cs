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
    public sealed class SqlTransformationName : SqlName<SqlTransformationName>
    {
        
        public static new SqlTransformationName Parse(string s)
            => new SqlTransformationName(s);

        public static implicit operator SqlTransformationName(string Value)
            => new SqlTransformationName(Value);

        public SqlTransformationName(SqlTransformationName Source, SqlTransformationName Target)
            : base($"{Source}=>{Target}")
        {

        }

        public SqlTransformationName(string Value)
            : base(Value)
        { }


        public SqlTransformationName()
            : this(string.Empty)
        { }
                  


        public SqlTransformationName(ICompositeSqlName SqlName)
            : base(SqlName)
        { }

        public override string ToString()
            => UnqualifiedName;

    }
}
