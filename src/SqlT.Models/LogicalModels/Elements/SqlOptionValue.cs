//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using static metacore;

    /// <summary>
    /// Represents an option within some context
    /// </summary>
    public class SqlOptionValue : ValueObject<SqlOptionValue>
    {
        public readonly SqlOptionType OptionType;
        public readonly object InnerValue;

        /// <summary>
        /// Initializes a new <see cref="SqlOptionValue"/> instance
        /// </summary>
        /// <param name="OptionType"></param>
        /// <param name="InnerValue"></param>
        public SqlOptionValue(SqlOptionType OptionType, object InnerValue)
        {
            this.OptionType = OptionType;
            this.InnerValue = InnerValue;
        }


    }
}
