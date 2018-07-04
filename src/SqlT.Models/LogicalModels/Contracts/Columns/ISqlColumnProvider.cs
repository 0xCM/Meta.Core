//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using SqlT.Core;
    using sxc = SqlT.Syntax.contracts;

    public interface ISqlColumnProvider : sxc.column_name_provider
    {
        IReadOnlyList<ISqlColumn> Columns { get; }
    }

    public interface ISqlColumnProvider<C> : ISqlColumnProvider
    {

    }    
}
