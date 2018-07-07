//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;

    using static metacore;

    /// <summary>
    /// Constructs and manipulates <see cref="ILattice{X}"/> types and values
    /// </summary>
    public class Lattice : ClassModule<Lattice, ILattice>
    {
        public static Lattice<X> make<X>(Equator<X> equator, Orderer<X> orderer)
            => new Lattice<X>(equator, orderer);
    }


}