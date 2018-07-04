//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using static metacore;

    using SqlT.Core;

    /// <summary>
    /// Applied to an element to specify that its attributes, or subset thereof, should align with
    /// a specified Table Type that defines a data contract
    /// </summary>
    public sealed class SqlDataContractProperty : SqlCustomProperty<SqlDataContractProperty, SqlTypeName>
    {
        public SqlDataContractProperty(SqlTypeName TableTypeName)
            : base(SqlPropertyNames.DataContract, TableTypeName)
        {

        }

    }



}