//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using SqlT.Syntax;

    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Characterizes a routine parameter
    /// </summary>
    [SqlElementType(SqlElementTypeNames.Parameter)]
    public sealed class SqlRoutineParameter : SqlElement<SqlRoutineParameter>
    {

        public SqlRoutineParameter
        (
            SqlParameterName ParameterName,
            sxc.type_ref TypeReference, 
            bool IsReadOnly = false,
            bool IsOutput = false,
            SqlElementDescription Documentation = null
        ) : base(ParameterName, Documentation: Documentation)
        {
            this.ParameterName =  ParameterName;
            this.TypeReference = TypeReference;
            this.IsReadOnly = TypeReference.is_table_type ? true : IsReadOnly;
            this.IsOutput = TypeReference.is_table_type ? false : IsOutput;
        }


        public SqlParameterName ParameterName { get; }

        public sxc.type_ref TypeReference { get; }

        public bool IsReadOnly { get; }

        public bool IsOutput { get; }

        public SqlTypeName ReferencedType
            => TypeReference.type_name;

        public override string ToString() 
            => $"{ParameterName} {TypeReference}";


    }

}
