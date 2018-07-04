//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using static metacore;

    /// <summary>
    /// Classifies a <see cref="SqlOptionValue"/>
    /// </summary>
    public class SqlOptionType : ValueObject<SqlOptionType>
    {
        public static implicit operator string(SqlOptionType subject) => subject.Name;

        /// <summary>
        /// The option type name
        /// </summary>
        public readonly string Name;

        public SqlOptionType(string Name)
        {
            this.Name = Name;
        }


        public SqlOptionValue CreateValue<T>(T value) 
            => new SqlOptionValue(this, value);
    }
}
