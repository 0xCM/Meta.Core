//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;

    using static metacore;
    
    public sealed class Identity : ClassModule<Identity,IIdentity>
    {
        public Identity()
            : base(typeof(Identity<>))
        {

        }

        /// <summary>
        /// Constructs a type's identity
        /// </summary>
        /// <typeparam name="X">The type for which identity will be constructed</typeparam>
        /// <returns></returns>
        public static Identity<X> make<X>()
            => Identity<X>.instance;
    }    

}