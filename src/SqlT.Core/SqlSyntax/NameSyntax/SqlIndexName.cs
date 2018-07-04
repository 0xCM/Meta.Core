//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;

    using SqlT.Syntax;

    /// <summary>
    /// Specifies an index name
    /// </summary>
    public sealed class SqlIndexName : SqlName<SqlIndexName>, ISimpleSqlName
    {
        public static readonly string UriSegmentName = "ix";

        public new static SqlIndexName Parse(string s)
            => new SqlIndexName(Componetize(s));

        public static implicit operator SqlIndexName(string LocalName)
            => new SqlIndexName(LocalName);

        public SqlIndexName(params string[] components)
            : base(false, components)
        {

        }

        public SqlIndexName(bool quote, params string[] components)
            : base(quote, components)
        {

        }


        public SqlIndexName()
            : this(string.Empty)
        { }


        public override string FullName
            => CreateFullName(Quoted);


    }


}