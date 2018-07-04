//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    public struct SqlNullability
    {
        public static readonly SqlNullability NULL = new SqlNullability(true);
        public static readonly SqlNullability NOTNULL = new SqlNullability(false);

        public static implicit operator bool(SqlNullability x)
            => x._nullable;

        public static implicit operator SqlNullability(bool x)
            => x ? NULL : NOTNULL;

        /// <summary>
        /// Toggles between nullable and nonnullable specifications
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static SqlNullability operator !(SqlNullability x)
            => ReferenceEquals(x, NOTNULL) ? NULL : NOTNULL;

        bool _nullable { get; }

        SqlNullability(bool isNullable)
        {
            this._nullable = isNullable;
        }


    }
}
