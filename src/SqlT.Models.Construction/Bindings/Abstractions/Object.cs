//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings
{
    using System;
    using System.Linq;

    using SqlT.Core;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;

    partial class TypeStructures
    {

        public abstract class ObjectStructure<T,M, N>  : Element<T,M,N>, IObject<N>
            where T : ObjectStructure<T,M, N>, new()
            where M : sxc.sql_object
            where N : sxc.ISqlObjectName
        {

            public virtual SqlSchemaName SchemaName
                => GetType().Namespace;
                
            sxc.ISqlObjectName IObject.Name
                => Name;
        }
    }
}