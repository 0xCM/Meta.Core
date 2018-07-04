//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    /// <summary>
    /// Encapsulates documentation for a parameter
    /// </summary>
    public class SqlParameterDocumentation : SqlElementDocumetation<SqlParameterName>
    {
        public SqlParameterDocumentation()
        {

        }

        public SqlParameterDocumentation(SqlParameterName Name, string Label, string Description, string Identifier)
            : base(Name, Label, Description, Identifier)
        {

        }
    }
}
