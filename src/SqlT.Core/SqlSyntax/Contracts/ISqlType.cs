//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;

    public static partial class contracts
    {
        public interface ISqlType : sql_object<SqlTypeName>
        {

            /// <summary>
            /// Specifies whether a length facet may be specified when creating a reference to the type
            /// </summary>
            bool CanSpecifyLength { get; }

            /// <summary>
            /// Specifies whether a precision facet may be specified when creating a reference to the type
            /// </summary>
            bool CanSpecifyPrecision { get; }

            /// <summary>
            /// Specifies whether a scale facet may be specified when creating a reference to the type
            /// </summary>
            bool CanSpecifyScale { get; }

            /// <summary>
            /// Specifies whether the type defines character data
            /// </summary>
            bool IsTextType { get; }

            /// <summary>
            /// Specifies whether the type defines ansi character data
            /// </summary>
            bool IsAnsiTextType { get; }

            /// <summary>
            /// Specifies whether the type defines unicode character data
            /// </summary>
            bool IsUnicodeTextType { get; }

        }
    }

}