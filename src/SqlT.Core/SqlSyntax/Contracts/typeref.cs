//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.ComponentModel;

    using Meta.Syntax;
    using SqlT.Core;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;

    partial class contracts
    {
        public interface type_ref : ISyntaxExpression
        {
            /// <summary>
            /// Specifies whether the referenced type is a table type
            /// </summary>
            [Description("Specifies whether the referenced type is a table type")]
            bool is_table_type { get; }

            /// <summary>
            /// Specifies whether a value must be specified when creating a value of the referenced type
            /// </summary>
            [Description("Specifies whether a value must be specified when creating a value of the referenced type")]
            bool nullable { get; }

            /// <summary>
            /// The name of the referenced type
            /// </summary>
            [Description("The name of the referenced type")]
            SqlTypeName type_name { get; }
        }

        public interface type_ref<n> : type_ref
            where n : sxc.type_name
        {
            /// <summary>
            /// The type-specific referenced type name
            /// </summary>
            [Description("The type-specific referenced type name")]
            new n type_name { get; }
        }

        public interface table_type_ref : type_ref<SqlTableTypeName>
        {

        }       

        [Description("Defines a reference to SQL type")]
        public interface data_type_ref : type_ref<SqlDataTypeName>
        {

            /// <summary>
            /// Specifies the maximum length of a value of the referenced type, if applicable
            /// </summary>
            [Description("Specifies the maximum length of a value of the referenced type, if applicable")]
            int? length { get; }

            /// <summary>
            /// Specifies the numeric precision of a value of the referended type, if applicable
            /// </summary>
            [Description("Specifies the numeric precision of a value of the referended type, if applicable")]
            byte? precision { get; }

            /// <summary>
            /// Specifies the numeric scale a value of the referended type, if applicable
            /// </summary>
            [Description("Specifies the numeric scale a value of the referended type, if applicable")]
            byte? scale { get; }

            /// <summary>
            /// Creates a new reference based on a descriptor
            /// </summary>
            /// <param name="descriptor"></param>
            /// <returns></returns>
            data_type_ref retype(SqlTypeDescriptor descriptor);
        }
    }
}