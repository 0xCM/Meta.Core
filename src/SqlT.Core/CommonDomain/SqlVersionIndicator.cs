//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    public enum SqlVersionIndicator : byte
    {
        Sql2005 = 90,
        Sql2008 = 100,
        Sql2008R2 = 105,
        Sql2012 = 110,
        Sql2014 = 120,
        Sql2016 = 130,
        Sql2017 = 140
    }


}
