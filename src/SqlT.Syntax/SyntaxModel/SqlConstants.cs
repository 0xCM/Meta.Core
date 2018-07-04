//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Models;

    static public class SqlConstants
    {
        public static SqlNullability NULL = SqlNullability.NULL;
        public static SqlNullability NOTNULL = SqlNullability.NOTNULL;

        public enum Unbounded { Yes = 0 }
        public static Unbounded MAX = Unbounded.Yes;

    }

    public enum FileTablePathOption : byte
    {
        Default = 0,
        Unconverted = 1,
        Full = 2
    }

}