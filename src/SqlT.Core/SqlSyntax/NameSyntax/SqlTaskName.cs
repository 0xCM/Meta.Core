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
    /// Specifies a task name
    /// </summary>
    public sealed class SqlTaskName : SqlName<SqlTaskName>
    {

        public static readonly string UriPartIdentifier = "task";

        protected override string UriComponentName
            => UriPartIdentifier;

        public static new SqlTaskName Parse(string s)
            => new SqlTaskName(s);

        public static implicit operator SqlTaskName(string x)
            => new SqlTaskName(x);


        public SqlTaskName()
            : this(string.Empty)
        { }


        public SqlTaskName(ICompositeSqlName SqlName)
            : base(SqlName)
        { }

        public SqlTaskName(string Value)
            : base(Value)
        {

        }

        public override string FullName
            => CreateFullName(false);


        public bool IsSpecified
            => !string.IsNullOrWhiteSpace(FullName);


    }


}