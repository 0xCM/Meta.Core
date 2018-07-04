//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;

    public interface ISqlWorkfowModule
    {
        object Invoke(SqlConnectionString connector, object o);
    }

    public interface ISqlWorkflowModule<in X, out Y> : ISqlWorkfowModule
    {
        Y Invoke(SqlConnectionString connector, X x);
    }


}