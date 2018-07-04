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
    /// Specifies a (logical) schedule name
    /// </summary>
    public sealed class SqlScheduleName : SqlName<SqlScheduleName>
    {

        public static readonly string UriPartIdentifier = "schedule";

        protected override string UriComponentName
            => UriPartIdentifier;

        public static new SqlScheduleName Parse(string s)
            => new SqlScheduleName(s);

        public static implicit operator SqlScheduleName(string x)
            => new SqlScheduleName(x);


        public SqlScheduleName()
            : this(string.Empty)
        { }


        public SqlScheduleName(ICompositeSqlName SqlName)
            : base(SqlName)
        { }

        public SqlScheduleName(string Value)
            : base(Value)
        {

        }

        public override string FullName
            => CreateFullName(false);


        public bool IsSpecified
            => !string.IsNullOrWhiteSpace(FullName);


    }


}