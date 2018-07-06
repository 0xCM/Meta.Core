//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings
{
    using System;
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;

    using static metacore;
    using sxc = SqlT.Syntax.contracts;

    partial class TypeStructures
    {
        public interface IObject : IElement
        {
            new sxc.ISqlObjectName Name { get; }
        }

        public interface IObject<N> : IObject, IElement<N>
            where N : sxc.ISqlObjectName
        {

        }



    }

}