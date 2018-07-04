//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System.Collections.Generic;

    public interface ISqlColumnDocumentation : ISqlElementDocumentation<SqlColumnName>
    {
        /// <summary>
        /// Indicates whether the column is nullable
        /// </summary>
        bool ValueRequired { get; set; }

        /// <summary>
        /// The relative position of the column
        /// </summary>
        int Position { get; set; }

        /// <summary>
        /// The name of column's data type
        /// </summary>
        string DataTypeName { get; set; }

        /// <summary>
        /// The value of the column's conventional description property
        /// </summary>
        /// <remarks>
        /// By convention, the name of the property is MS_Description
        /// </remarks>
        string DescriptionProperty { get; set; }

        /// <summary>
        /// The role played by the column
        /// </summary>
        SqlColumnRoleType RoleType { get; }

    }




}