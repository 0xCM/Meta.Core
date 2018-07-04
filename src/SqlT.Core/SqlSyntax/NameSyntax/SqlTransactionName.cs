//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    /// <summary>
    /// Specifies a transaction name
    /// </summary>
    public sealed class SqlTransactionName : SqlName<SqlTransactionName>
    {


        public new static SqlTransactionName Parse(string s)
            => new SqlTransactionName(Componetize(s));

        public static implicit operator SqlTransactionName(string LocalName)
            => new SqlTransactionName(LocalName);

        public SqlTransactionName()
            : this(string.Empty)
        { }

        public SqlTransactionName(params string[] components)
            : base(components)
        {

        }


        public override string FullName
            => CreateFullName(false);

        public bool IsAnonymous
            => NameComponents.Count == 0;

    }


}