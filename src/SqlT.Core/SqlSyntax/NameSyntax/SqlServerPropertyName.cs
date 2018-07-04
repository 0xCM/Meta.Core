//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    /// <summary>
    /// Specifies a server property name
    /// </summary>
    public sealed class SqlServerPropertyName : SqlName<SqlServerPropertyName>
    {
        public static implicit operator SqlServerPropertyName(string s)
            => Parse(s);

        public static new SqlServerPropertyName Parse(string s)
            => new SqlServerPropertyName(s);


        public static implicit operator string(SqlServerPropertyName x)
            => x.FullName;

        public SqlServerPropertyName()
            : base(string.Empty)
        { }


        public SqlServerPropertyName(string value)
            : base(false, value)
        {

        }

        public override string FullName
            => CreateFullName(false);
    }



}