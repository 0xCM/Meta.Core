//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Collections;
    using System.Linq.Expressions;

    using Meta.Core;
    using Meta.Core.Modules;

    using static metacore;
    using static express;

    using static ConversionMessages;
   
    /// <summary>
    /// Encapsulates a set of projectors which are used to realize <see cref="IConversionSuite"/> contract
    /// </summary>
    /// <remarks>
    /// The implementation is predicated on the concept of what it means for a set of methods
    /// to be "conforming":
    /// - A *projector* in this context is any static method F:X->Y or F:(C,X)->Y where C
    /// is an ambinent context. In the latter case, the projector is said to be *contextual*
    /// - A set of projectors P is said to be "conforming" if the ordered pairs (X,Y),
    /// where X and Y represent input/output types of elements of P form a unique set.
    /// - This specifed a well-defined correspondence that identifes a source type X and a target
    /// type Y with a unique projector among a set of conforming projectors
    /// </remarks>
    public class ConversionSuite : IConversionSuite
    {
        /// <summary>
        /// Creates a <see cref="IConversionSuite"/> from map of identified converters
        /// </summary>
        /// <param name="converters">The identified converters</param>
        /// <returns></returns>
        public static IConversionSuite FromIndex(Map<long, Converter> converters)
            => new ConversionSuite(converters);
      

        /// <summary>
        /// Creates a <see cref="IConversionSuite"/> from a method array
        /// </summary>
        /// <param name="methods">The conversion methods</param>
        /// <returns></returns>
        public static IConversionSuite FromMethods(params MethodInfo[] methods)
            => new ConversionSuite(methods);

        /// <summary>
        /// Creates a <see cref="IConversionSuite"/> from a method sequence
        /// </summary>
        /// <param name="methods">The conversion methods</param>
        /// <returns></returns>
        public static IConversionSuite FromMethods(Seq<MethodInfo> methods)
            => new ConversionSuite(methods.Stream());

        /// <summary>
        /// Creates a <see cref="IConversionSuite"/> from an array of types that, by convention,
        /// define sets of static/non-contextual conversion functions        
        /// </summary>
        /// <param name="types">The types that define the conversion functions</param>
        /// <returns></returns>
        public static IConversionSuite FromTypes(params Type[] types)
        {
            var methods =
                from t in types
                from m in t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                where
                    m.ReturnType != typeof(void)
                let parameters = m.GetParameters()
                where
                    parameters.Length == 1 ||
                    (
                        parameters.Length == 2 &&
                        parameters[0].ParameterType == typeof(IApplicationContext)
                    )
                select m;
            return FromMethods(methods.ToArray());
        }

        /// <summary>
        /// Creates a weakly-typed converter
        /// </summary>
        /// <param name="m">The method for which a converter will be created</param>
        /// <returns></returns>
        static Converter converter(MethodInfo m)
        {
            var src = Expression.Parameter(typeof(object), "src");
            var convert = Expression.Convert(src, m.GetParameters()[0].ParameterType);
            var callResult = Expression.Call(null, m, convert);
            var result = Expression.Convert(callResult, typeof(object));
            return Expression.Lambda<Converter>(result, src).Compile();
        }

        /// <summary>
        /// Creates a strongly-typed converter
        /// </summary>
        /// <typeparam name="TDst"></typeparam>
        /// <param name="m"></param>
        /// <returns></returns>
        static Converter<TDst> converter<TDst>(MethodInfo m)
        {
            var src = Expression.Parameter(typeof(object), "src");
            var convert = Expression.Convert(src, m.GetParameters()[0].ParameterType);
            var callResult = Expression.Call(null, m, convert);
            return Expression.Lambda<Converter<TDst>>(callResult, src).Compile();
        }


        /// <summary>
        /// Creates a <see cref="IConversionSuite"/> from a type that, by convention,
        /// defines a set of static/non-contextual conversion functions
        /// </summary>
        /// <typeparam name="T">The defining type</typeparam>
        /// <returns></returns>
        public static IConversionSuite FromType<T>()
            => FromTypes(typeof(T));

        ConversionSuite(string name)
        {
            this.name = name;
        }

        ConversionSuite(Map<long, Converter> converters)
        {
            this.projectors = converters;            
        }

        ConversionSuite(IEnumerable<MethodInfo> methods)
            : this(String.Empty)
        {
            var keys = new MutableSet<long>();
            foreach (var m in methods)
            {
                var key = ConversionKey.FromMethod(m);
                if (keys.Contains(key))
                    throw new Exception(
                        $"The method {m.Name}:{m.GetParameters().Single().ParameterType.Name}=>{m.ReturnType.Name} duplicates another signature");
                else
                    keys.Add(key);
            }

            projectors = seq(from m in methods
                              let parameters = m.GetParameters()
                              where parameters.Length == 1
                              let srcType = parameters.Last().ParameterType
                              let key = ConversionKey.FromTypes(srcType, m.ReturnType).KeyValue
                              select (key, converter(m)));

            ctxprojectors = seq(from m in methods
                                 let parameters = m.GetParameters()
                                 where parameters.Length == 2
                                 let srcType = parameters.Last().ParameterType
                                 let key = ConversionKey.FromTypes(srcType, m.ReturnType).KeyValue
                                 select (key, m.ToContextualConverter()));
        }

        ConversionSuite(params MethodInfo[] methods)
            : this(stream(methods))
        {

        }

        Map<long, Converter> projectors { get; }
            = Map<long, Converter>.Empty;

        Map<long, ContextualConverter> ctxprojectors { get; }
            = Map<long, ContextualConverter>.Empty;

        string name { get; }

        public ConversionSuite(string name, params MethodInfo[] methods)
            : this(methods)
        {
            this.name = name;
        }

        /// <summary>
        /// Determines whether the suite defines a conversion from a value
        /// of one type to another
        /// </summary>
        /// <param name="srcType">The type of input value</param>
        /// <param name="dstType">The type of output value</param>
        /// <returns></returns>
        public bool CanConvert(Type srcType, Type dstType)
        {
            var key = ConversionKey.FromTypes(srcType, dstType);
            return projectors.ContainsKey(key);
        }

        /// <summary>
        /// Determines whether conversion from a source value to a target type is possible
        /// </summary>
        /// <param name="srcValue">The source value</param>
        /// <param name="dstType">The target type</param>
        /// <returns></returns>
        public bool CanConvert(object srcValue, Type dstType)
        {
            var key = ConversionKey.FromTypes(srcValue.GetType(), dstType);
            return projectors.ContainsKey(key);
        }

        public bool CanConvert<TDst>(object srcValue)
        {
            var key = ConversionKey.FromTypes(srcValue.GetType(), typeof(TDst));
            return projectors.ContainsKey(key);
        }

        /// <summary>
        /// Determines whether the conversion from one type to another is supported
        /// </summary>
        /// <typeparam name="TSrc">The source type</typeparam>
        /// <typeparam name="TDst">The target type</typeparam>
        /// <returns></returns>
        public bool CanConvert<TSrc, TDst>()
            => projectors.ContainsKey(ConversionKey.FromTypes(typeof(TSrc), typeof(TDst)));

        /// <summary>
        /// Converts the source value to a target type value if possible, using a
        /// supplied fallback function if specifed whenever the target type
        /// is not directly supported
        /// </summary>
        /// <typeparam name="TDst">The target type</typeparam>
        /// <param name="srcValue">The source value</param>
        /// <param name="fallback">The secondary converter</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TDst Convert<TDst>(object srcValue, Func<object, TDst> fallback = null)
            => cast<TDst>(fallback != null
                ? Convert(typeof(TDst), srcValue, x => fallback(srcValue))
                : Convert(typeof(TDst), srcValue, null));

        /// <summary>
        /// Conversion attempt of last resort
        /// </summary>
        /// <param name="DstType">The source type</param>
        /// <param name="SrcValue">The target type</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static object MysteryConvert(Type DstType, object SrcValue)
            => DstType.IsEnum
            ? Enum.Parse(DstType, SrcValue.ToString(), true)
            : System.Convert.ChangeType(SrcValue, DstType);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Convert(Type dstType, object srcValue, Func<object, object> fallback = null)
        {
            if (srcValue is null)
                return null;

            var key = ConversionKey.FromTypes(srcValue.GetType(), dstType);
            if (projectors.TryGetValue(key, out Converter projector))
                return projector(srcValue);
            else
            {
                return not(fallback is null)
                    ? fallback(srcValue)
                    : MysteryConvert(dstType, srcValue);
            }
        }

        /// <summary>
        /// Attemps to convert the source value to the target type. Returns the
        /// converted value if successful, oterwise None
        /// </summary>
        /// <typeparam name="TDst">The target type</typeparam>
        /// <param name="srcValue">The source value</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Option<TDst> TryConvert<TDst>(object srcValue)
        {
            var dstType = typeof(TDst);
            var srcType = srcValue?.GetType();

            if (srcValue is null)
                return none<TDst>(ConversionInputNull(dstType));            
            try
            {
                var key = ConversionKey.FromTypes(srcType, dstType);
                if (projectors.TryGetValue(key, out Converter converter))
                    return (TDst)converter(srcValue);
                else
                    return (TDst)MysteryConvert(dstType, srcValue);                
            }
            
            catch(Exception e)
            {
                return none<TDst>(e);
            }
        }

        /// <summary>
        /// Converts a heterogenous array of item values
        /// </summary>
        /// <param name="dstTypes">The target item types</param>
        /// <param name="srcValues">The source item values</param>
        /// <returns></returns>
        public object[] ConvertItems(Type[] dstTypes, object[] srcValues)
        {
            var len = Math.Min(dstTypes.Length, srcValues.Length);
            var dstValues = new object[len];
            for (int i = 0; i < len; i++)
                dstValues[i] = Convert(dstTypes[i], srcValues[i]);
            return dstValues;
        }


        /// <summary>
        /// Converts a heterogenous sequence of item values
        /// </summary>
        /// <param name="items">A sequence of (TargetType,ItemValue) tuples</param>
        /// <returns></returns>
        public Seq<object> ConvertItems(Seq<(Type dstType, object srcValue)> items)
            => Seq.map(x => Convert(x.dstType, x.srcValue), items);

        IEnumerable<TDst> ConvertStream<TDst>(IEnumerable values)
        {
            foreach (var value in values)
                yield return Convert<TDst>(value);
        }

        Seq<TDst> IConversionSuite.ConvertStream<TDst>(IEnumerable values)
            => seq(ConvertStream<TDst>(values));

        public TDst Convert<TDst>(PropertyBag properties) 
            where TDst : new()
        {
            var dst = new TDst();
            iter(properties.ToDictionary(),
                p => propval(dst, p.Key, Convert(proptype(dst, p.Key), p.Value)));
            return dst;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TDst Convert<TDst>(IApplicationContext context, object srcValue)
            => cast<TDst>(Convert(context, typeof(TDst), srcValue));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Convert(IApplicationContext context, Type dstType, object srcValue)
        {
            var key = ConversionKey.FromTypes(srcValue.GetType(), dstType);
            var projector = default(ContextualConverter);
            if (ctxprojectors.TryGetValue(key, out projector))
                return projector(context, srcValue);
            else
                return System.Convert.ChangeType(srcValue, dstType);
        }
    }

}