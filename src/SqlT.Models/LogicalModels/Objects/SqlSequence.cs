//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using SqlT.Syntax;


    /// <summary>
    /// Characterizes a sequence object
    /// </summary>
    [SqlElementType(SqlElementTypeNames.Sequence)]
    public sealed class SqlSequence : SqlObject<SqlSequence>
    {
        public SqlSequence
        (
            SqlSequenceName SequenceName, 
            typeref SequenceDataType,
            string InitialValue = "1",
            string Increment = "1",
            string MaxValue = null,
            string CacheSize = "10"     
         )
            : base(SequenceName)
        {
            this.SequenceDataType = SequenceDataType;
            this.InitialValue = InitialValue;
            this.Increment = Increment;
            this.MaxValue = MaxValue;
            this.CacheSize = CacheSize;
            this.ObjectName = SequenceName;
        }

        public new SqlSequenceName ObjectName { get; }

        public typeref SequenceDataType { get; }

        public string InitialValue { get; }

        public string Increment { get; }

        public string MaxValue { get; }

        public string CacheSize { get; }

        public SqlDataTypeName ReferencedTypeName 
            => SequenceDataType.type_name;

    }
}
