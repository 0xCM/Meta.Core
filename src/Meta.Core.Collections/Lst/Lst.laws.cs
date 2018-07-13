﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using G = System.Collections.Generic;

    public delegate Lst<X> LstFactory<X>(G.IEnumerable<X> source);

    public interface ILst : IDataModule
    {

    }

    public interface ILst<X> :  ILst, IDataModule<X,Lst<X>>, IContainer<X, Lst<X>>
    {

    }

}