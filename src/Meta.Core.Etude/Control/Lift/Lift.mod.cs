//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Lift : TypeModule<Lift>
    {
        /// <summary>
        /// Lifts a value
        /// </summary>
        /// <typeparam name="X">The value type</typeparam>
        /// <param name="value">The value to lift</param>
        /// <returns></returns>
        public static Lift<X> evolve<X>(X value)
            => new Lift<X>(value);

        /// <summary>
        /// Unwraps a lifted value
        /// </summary>
        /// <typeparam name="X">The value type</typeparam>
        /// <param name="lift">The lift containing the value to unwrap</param>
        /// <returns></returns>
        public static X devolve<X>(ILift<X> lift)
            => lift.Value;

    }


}