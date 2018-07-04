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
    /// Specifies a trigger name
    /// </summary>
    public sealed class SqlServerTriggerName : SqlName<SqlServerTriggerName>
    {

        public static readonly string UriPartIdentifier = "trigger";

        protected override string UriComponentName
            => UriPartIdentifier;

        public static new SqlServerTriggerName Parse(string s)
            => new SqlServerTriggerName(s);

        public static implicit operator SqlServerTriggerName(string x)
            => new SqlServerTriggerName(x);


        public SqlServerTriggerName()
            : this(string.Empty)
        { }


        public SqlServerTriggerName(ISimpleSqlName SqlName)
            : base(SqlName)
        { }

        public SqlServerTriggerName(string Value)
            : base(Value)
        {

        }

        public override string FullName
            => CreateFullName(false);


        public bool IsSpecified
            => !string.IsNullOrWhiteSpace(FullName);


    }


}