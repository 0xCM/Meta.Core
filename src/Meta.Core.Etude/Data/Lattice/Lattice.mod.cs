//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Constructs and manipulates <see cref="ILattice{X}"/> types and values
    /// </summary>
    public class Lattice : ClassModule<Lattice, ILattice>
    {
        public Lattice()
            : base(typeof(Lattice<>))
        {

        }

        public static Lattice<X> make<X>(Equator<X> equator, Orderer<X> orderer)
            => new Lattice<X>(equator, orderer);
    }
}