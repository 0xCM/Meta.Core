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
    /// Defines operations on the Record type family
    /// </summary>
    partial class Record
    {
        /// <summary>
        /// Retrieves the empty value for the identified record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <returns></returns>
        public static Record<X1> zero<X1>()
            => Record<X1>.Empty;

        /// <summary>
        /// Retrieves the empty value for the identified record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <returns></returns>
        public static Record<X1, X2> zero<X1, X2>()
            => Record<X1, X2>.Empty;

        /// <summary>
        /// Retrieves the empty value for the identified record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <returns></returns>
        public static Record<X1, X2, X3> zero<X1, X2, X3>()
             => Record<X1, X2, X3>.Empty;

        /// <summary>
        /// Retrieves the empty value for the identified record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4> zero<X1, X2, X3, X4>()
             => Record<X1, X2, X3, X4>.Empty;

        /// <summary>
        /// Retrieves the empty value for the identified record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <typeparam name="X5">The data type of the fifth field</typeparam>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5> zero<X1, X2, X3, X4, X5>()
            => Record<X1, X2, X3, X4, X5>.Empty;

        /// <summary>
        /// Retrieves the empty value for the identified record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <typeparam name="X5">The data type of the fifth field</typeparam>
        /// <typeparam name="X6">The data type of the sixth field</typeparam>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5, X6> zero<X1, X2, X3, X4, X5, X6>()
            => Record<X1, X2, X3, X4, X5, X6>.Empty;

        /// <summary>
        /// Retrieves the empty value for the identified record type
        /// </summary>
        /// <typeparam name="X1">The data type of the first field</typeparam>
        /// <typeparam name="X2">The data type of the second field</typeparam>
        /// <typeparam name="X3">The data type of the third field</typeparam>
        /// <typeparam name="X4">The data type of the fourth field</typeparam>
        /// <typeparam name="X5">The data type of the fifth field</typeparam>
        /// <typeparam name="X6">The data type of the sixth field</typeparam>
        /// <typeparam name="X7">The data type of the seventh field</typeparam>
        /// <returns></returns>
        public static Record<X1, X2, X3, X4, X5, X6, X7> zero<X1, X2, X3, X4, X5, X6, X7>()
            => Record<X1, X2, X3, X4, X5, X6, X7>.Empty;
    }
}
