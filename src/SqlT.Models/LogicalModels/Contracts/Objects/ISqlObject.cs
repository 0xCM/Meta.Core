﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using sxc = SqlT.Syntax.contracts;


    public interface ISqlObject<N> : sxc.sql_object, sxc.sql_object<N>, ISqlElement
        where N : sxc.ISqlObjectName, new()
    {

    }

}
