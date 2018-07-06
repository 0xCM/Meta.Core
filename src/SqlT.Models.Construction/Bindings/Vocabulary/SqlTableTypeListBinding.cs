//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;    

    using SqlT.Core;
        
    public sealed class SqlTableTypeListBinding<TTable, TType> : SqlListBinding<TTable, TType>
       where TTable : class, ISqlTableProxy, new()
       where TType : class, ISqlTableTypeProxy, new()
    {

        public SqlTableTypeListBinding(string ListName, SqlColumnName IdentifierColumn)
            : base(ListName, IdentifierColumn)
        {

        }
    }
}