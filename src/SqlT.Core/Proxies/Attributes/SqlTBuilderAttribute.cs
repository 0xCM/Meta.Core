//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    using System;


    /// <summary>
    /// Identifies functions that produce SQL domain model elements from TSql, DSql or other representations 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SqlTBuilderAttribute : Attribute
    {
        public SqlTBuilderAttribute()
        {

        }
    }


}