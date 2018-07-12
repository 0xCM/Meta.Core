//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;

    public interface IMeetSemilattice<X> : IPartialOrder<X>
    {

    }

    public interface IJoinSemilattice<X> : IPartialOrder<X>
    {

    }

    public interface ILattice : ITypeClass
    {

    }

    public interface ILattice<X> : IMeetSemilattice<X>, IJoinSemilattice<X>
    {

    }



}