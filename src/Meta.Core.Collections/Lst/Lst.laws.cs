//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using G = System.Collections.Generic;

    public delegate Lst<X> LstFactory<X>(G.IEnumerable<X> source);

    public interface ILst : IDataModule
    {
        Type ElementType { get; }

        Array AsArray();

        ILst Fill(IEnumerable<object> items);
    }

    public interface ILst<X> :  ILst, IDataModule<X,Lst<X>>, IContainer<X, Lst<X>>
    {
        new X[] AsArray();        
    }

}