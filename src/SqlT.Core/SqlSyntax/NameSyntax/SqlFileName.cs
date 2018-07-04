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
    /// Specifies a logical filename
    /// </summary>
    public sealed class SqlFileName : SqlName<SqlFileName>
    {

        public static readonly string UriPartIdentifier = "file";

        protected override string UriComponentName
            => UriPartIdentifier;

        public static new SqlFileName Parse(string s)
            => new SqlFileName(s);

        public static implicit operator SqlFileName(string x)
            => new SqlFileName(x);


        public SqlFileName()
            : this(string.Empty)
        { }


        public SqlFileName(ICompositeSqlName SqlName)
            : base(SqlName)
        { }

        public SqlFileName(string Value)
            : base(Value)
        {

        }

        public override string FullName
            => CreateFullName(false);


        public bool IsSpecified
            => !string.IsNullOrWhiteSpace(FullName);


    }


}