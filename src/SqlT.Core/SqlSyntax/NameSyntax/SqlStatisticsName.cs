//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;

    public sealed class SqlStatisticsName : SqlName<SqlStatisticsName>
    {

        public static readonly string UriPartIdentifier = "stats";

        public new static SqlStatisticsName Parse(string s)
            => new SqlStatisticsName(Componetize(s));

        public static implicit operator SqlStatisticsName(string LocalName)
            => new SqlStatisticsName(LocalName);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlStatisticsName(params string[] components)
            : base(components)
        {

        }

        public SqlStatisticsName()
            : this(string.Empty)
        { }

        public override string FullName
            => CreateFullName(false);
    }

}