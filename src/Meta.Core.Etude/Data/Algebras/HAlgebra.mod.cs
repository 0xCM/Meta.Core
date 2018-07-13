//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    
    public class HAlgebra : ClassModule<HAlgebra, IHAlgebra>
    {
        public HAlgebra()
            : base(typeof(HAlgebra<>))
        { }


        /// <summary>
        /// Retrieves the Heyting Algebra specialized for the <see cref="bool"/> data type
        /// </summary>
        /// <returns></returns>
        public static IHAlgebra<bool> @bool()
            => HAlgebraBoolean.instance;

    }



}