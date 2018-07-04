//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    public static class SqlOptionTypeNames
    {
        public const string DropIfExists = nameof(DropIfExists);
        public const string SkipIfExists = nameof(SkipIfExists);
        public const string IgnoreExists = nameof(IgnoreExists);
    }

    public static class SqlOptionTypes
    {
        public static readonly SqlOptionType DropIfExists = new SqlOptionType(SqlOptionTypeNames.DropIfExists);
        public static readonly SqlOptionType SkipIfExists = new SqlOptionType(SqlOptionTypeNames.SkipIfExists);
        
        /// <summary>
        /// When true no existence changes are made prior to element creation
        /// </summary>
        public static readonly SqlOptionType IgnoreExists = new SqlOptionType(SqlOptionTypeNames.IgnoreExists);
    }
}
