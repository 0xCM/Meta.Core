//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    /// <summary>
    /// Constructs a description of a relationship between two tables
    /// </summary>
    /// <typeparam name="TClient">A table that takes a dependency on the supplier</typeparam>
    /// <typeparam name="TSupplier">The table on which the client depends</typeparam>
    public class SqlTableRelationBuilder<TClient, TSupplier>
        where TClient : ISqlTableProxy
        where TSupplier : ISqlTableProxy

    {

    }
}