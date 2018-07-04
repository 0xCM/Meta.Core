﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    

    public abstract class SqlSequenceProxy : SqlObjectProxy, ISqlSequenceProxy
    {
    }

    public abstract class SqlSequenceProxy<S> : SqlSequenceProxy, ISqlSequenceProxy<S>
    {

    }

    public abstract class SqlSequenceProxy<T,S> : SqlObjectProxy<T>, ISqlSequenceProxy<T,S>
        where T : SqlSequenceProxy<T,S>, new()
    {

    }

}