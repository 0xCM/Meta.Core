//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using static metacore;



    /// <summary>
    /// Defines operations on the Record type family
    /// </summary>
    public partial class Record 
    {
        /// <summary>
        /// Returns the generic type definition the record type for a specified arity
        /// </summary>
        /// <param name="arity">The number of generic parameters appearing in the record</param>
        /// <returns></returns>
        static Option<Type> TypeDef(int arity)
            => arity is 1 ? typeof(Record<>)
            : arity is 2 ? typeof(Record<,>)
            : arity is 3 ? typeof(Record<,,>)
            : arity is 4 ? typeof(Record<,,,>)
            : arity is 5 ? typeof(Record<,,,,>)
            : arity is 6 ? typeof(Record<,,,,,>)
            : arity is 7 ? typeof(Record<,,,,,,>)
            : none<Type>();

        /// <summary>
        /// Retrieves the fields defined by the record
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="r"></param>
        /// <returns></returns>
        public static Lst<RecordField> fields<R>()
            where R : IRecord<R>, new()
                => mapi(type<R>().DeclaredPublicInstanceProperties,
                    (i, p) => new RecordField(p, i));

    }
}