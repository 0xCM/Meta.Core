//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;


    public interface IExtend : IFunctor
    {

    }

    public interface IExtend<X,CX,Y,CY> : IExtend, IFunctor<X,CX,Y,CY>
        where CX : IContainer<X>
        where CY : IContainer<Y>
    {
        Func<CX, CY> extend(Func<CX, Y> f);
    }

    

}