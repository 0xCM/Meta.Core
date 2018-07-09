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


    public static class RecordX
    {

        internal static bool RecordEquals<R>(this R r1, R r2)
            where R : IRecord<R>, new()
            => r1.Equals(r2);

        internal static bool RecordEquals<R>(this R r1, object r2)
            where R : IRecord<R>, new()
            => (r2 is R rr2)
                ? RecordEquals(r1, rr2) : false;

        /// <summary>
        /// Retrieves the fields defined by the record
        /// </summary>
        /// <typeparam name="R">The record type</typeparam>
        /// <param name="r">The record value</param>
        /// <returns></returns>
        public static Lst<RecordField> Fields<R>(this R r)
            where R : IRecord<R>, new()
                => Record.fields<R>();
    }

}