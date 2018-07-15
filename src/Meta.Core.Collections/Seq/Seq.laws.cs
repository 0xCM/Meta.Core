//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;    

    public delegate Seq<X> SeqFactory<X>(IEnumerable<X> source);


    public interface ISeq : IDataModule
    {

    }


    public interface ISeq<X> : ISeq, IDataModule<X,Seq<X>>, IContainer<X, Seq<X>>
    {

    }

}