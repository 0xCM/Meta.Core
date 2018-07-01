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
    using System.Text;
    using System.Threading;
    using System.Collections.Concurrent;
    using System.Security.Cryptography;
    using System.Reflection;
    using MathNet.Numerics.Random;
    
    using static metacore;

    /// <summary>
    /// Defines a standard set of value generators
    /// </summary>
    public static class Synthetics
    {
        static ThreadLocal<MD5CryptoServiceProvider> Md5Provider
            = new ThreadLocal<MD5CryptoServiceProvider>(() => new MD5CryptoServiceProvider());

        static ConcurrentDictionary<string, Fare.Xeger> patterns
            = new ConcurrentDictionary<string, Fare.Xeger>();

        static IReadOnlyDictionary<Type, MethodInfo> GeneratorFactories { get; }

        static Synthetics()
        {
            var res = AssemblyResourceProvider.Get();
            GeneratorFactories = dict(from m in typeof(Synthetics).GetStaticMethods()
                                    where Attribute.IsDefined(m, typeof(ValueGeneratorAttribute))
                                    let arg = m.ReturnType.GetGenericArguments()[0]
                                    select (arg, m));
        }

        static internal IReadOnlyDictionary<Type, MethodInfo> Factories
            => GeneratorFactories;

        static byte[] MD5(int value) 
            => Md5Provider.Value.ComputeHash(Encoding.Default.GetBytes(value.ToString()));

        /// <summary>
        /// Creates a randomize with an optional seed
        /// </summary>
        /// <param name="seed">The optional seet. If no seed is specified one will be generated</param>
        /// <returns></returns>
        static Random Randomizer(int ? seed = null)
            => seed != null
                ? new MersenneTwister(seed.Value, true)
                : new MersenneTwister(true);

        /// <summary>
        /// Defines a sequence of of integers as determined by a randomizer that live within a specified range
        /// </summary>
        /// <param name="min">The inclusive minimum</param>
        /// <param name="max">The inclusive maximum</param>
        /// <param name="count">If specified, the number of integers with which to populate the sequence; 
        /// otherwise, no upper bound will placed on the number of values that the sequence will. In this case, 
        /// calling ToList(), for example, would be unhelpful</param>
        /// <returns></returns>
        static IEnumerable<int> Integers(this Random randomizer, int min, int max, int ? count = null) 
            =>  count != null
            ?   randomizer.NextInt32Sequence(min, max + 1).Take(count.Value)
            :   randomizer.NextInt32Sequence(min, max + 1);

        /// <summary>
        /// Creates a source for <see cref="short"/> values that aligns with supplied facet and seed specification
        /// </summary>
        /// <param name="facets">The facets to apply</param>
        /// <param name="seed">The seed, if desired</param>
        /// <returns></returns>
        [ValueGenerator]
        static ValueSource<short> GF_Int16(IFacetSet facets, int? seed = null)
        {
            
            var randomizer = Randomizer(seed);
            var min = facets.FindValueOrElse(CommonFacetNames.Min, Int16.MinValue);
            var max = facets.FindValueOrElse(CommonFacetNames.Min, Int16.MaxValue - 1);
            return () => (short)randomizer.Next(min, max + 1);
        }

        /// <summary>
        /// Creates a source for <see cref="ushort"/> values that aligns with supplied facet and seed specification
        /// </summary>
        /// <param name="facets">The facets to apply</param>
        /// <param name="seed">The seed, if desired</param>
        /// <returns></returns>
        [ValueGenerator]
        static ValueSource<ushort> GF_UInt16(IFacetSet facets, int? seed = null)
        {

            var randomizer = Randomizer(seed);
            var min = facets.FindValueOrElse(CommonFacetNames.Min, UInt16.MinValue);
            var max = facets.FindValueOrElse(CommonFacetNames.Min, UInt16.MaxValue - 1);
            return () => (ushort)randomizer.Next(min, max + 1);
        }

        /// <summary>
        /// Creates a source for <see cref="byte"/> values that aligns with supplied facet and seed specification
        /// </summary>
        /// <param name="facets">The facets to apply</param>
        /// <param name="seed">The seed, if desired</param>
        /// <returns></returns>
        [ValueGenerator]
        static ValueSource<byte> GF_UInt8(IFacetSet facets, int? seed = null)
        {

            var randomizer = Randomizer(seed);
            var min = facets.FindValueOrElse(CommonFacetNames.Min, Byte.MinValue);
            var max = (byte)facets.FindValueOrElse(CommonFacetNames.Min, Byte.MaxValue - 1);
            return () => randomizer.NextByte(min, max);
        }

        /// <summary>
        /// Creates a source for <see cref="int"/> values that aligns with supplied facet and seed specification
        /// </summary>
        /// <param name="facets">The facets to apply</param>
        /// <param name="seed">The seed, if desired</param>
        /// <returns></returns>
        [ValueGenerator]
        static ValueSource<int> GF_Int32(IFacetSet facets, int? seed = null)
        {
            
            var randomizer = Randomizer(seed);
            var min = facets.FindValueOrElse(CommonFacetNames.Min, -2000000);
            var max = facets.FindValueOrElse(CommonFacetNames.Min, 2000000);
            return () => randomizer.Next(min, max + 1);
        }


        /// <summary>
        /// Creates a source for <see cref="Guid"/> values that aligns with supplied facet and seed specification
        /// </summary>
        /// <param name="facets">The facets to apply</param>
        /// <param name="seed">The seed, if desired</param>
        /// <returns></returns>
        [ValueGenerator]
        static ValueSource<Guid> GF_Guid(IFacetSet facets, int? seed = null)
        {
            var randomizer = Randomizer(seed);
            return () => new Guid(MD5(randomizer.Next()));
        }

        /// <summary>
        /// Creates a source for <see cref="Date"/> values that aligns with supplied facet and seed specification
        /// </summary>
        /// <param name="facets">The facets to apply</param>
        /// <param name="seed">The seed, if desired</param>
        /// <returns></returns>
        [ValueGenerator]
        static ValueSource<Date> GF_Date(IFacetSet facets, int? seed = null)
        {
            var randomizer = Randomizer(seed);
            var center = Date.Today;
            return () => center.AddDays(randomizer.Next(-365, 365));
        }


        /// <summary>
        /// Creates a source for strings that aligns with supplied facet and seed specification
        /// </summary>
        /// <param name="facets">The facets to apply</param>
        /// <param name="seed">The seed, if desired</param>
        /// <returns></returns>
        [ValueGenerator]
        static ValueSource<string> GF_String(IFacetSet facets, int? seed = null)
        {
            var min = facets.FindValueOrElse(CommonFacetNames.MinLength, 10);
            var max = facets.FindValueOrElse(CommonFacetNames.MaxLength, 75);
            var pattern = "([a-zA-Z0-9]){" + toString(min) + "," + toString(max) + "}";
            var source = patterns.GetOrAdd(pattern, p => new Fare.Xeger(p, Randomizer(seed)));
            return () => source.Generate();
        }

        /// <summary>
        /// Creates a source for <see cref="decimal"/> values that aligns with supplied facet and seed specification
        /// </summary>
        /// <param name="facets">The facets to apply</param>
        /// <param name="seed">The seed, if desired</param>
        /// <returns></returns>
        [ValueGenerator]
        static ValueSource<decimal> GF_Decimal(IFacetSet facets, int? seed = null)
        {
            var min = 50000m;
            var max = 2500000m;
            var scale = 4;
            var randomizer = Randomizer(seed);
            return () =>
            {

                var whole = randomizer.Next((int)min, (int)max);
                var fracs = randomizer.Integers(0, 10, scale).Aggregate((x, y) => x + y);
                return decimal.Parse($"{whole}.{fracs}");
            };

        }

        /// <summary>
        /// Retrieves an item from a list as determined by a supplied randomizer
        /// </summary>
        /// <typeparam name="T">The type of item contained in the list</typeparam>
        /// <param name="randomizer">The randomizer thta determines the item</param>
        /// <param name="items">The list from which an item will be chosen</param>
        /// <returns></returns>
        static T NextItem<T>(this Random randomizer, IReadOnlyList<T> items)
            => items[randomizer.Next(0, items.Count)];


#if FSMATH
        /// <summary>
        /// Implements a non-repeating RNG
        /// </summary>
        /// <remarks>
        /// See:
        /// http://preshing.com/20121224/how-to-generate-a-sequence-of-unique-random-integers/
        /// https://gist.github.com/steveash/fe241f54aa6d7fb73da9
        /// </remarks>
        static ValueSource<uint> NonRepeatingUInt32(uint min, uint max, uint? seed = null)
        {
            var prime = Prime.minPrime(max);
            var seed1 = seed ?? (uint)now().Ticks;
            var seed2 = seed1 ^ 0x87761332;

            Func<uint, uint> ModPrime = value => value % prime;

            Func<uint, uint> Residue = value =>
            {
                var x = ModPrime(value * value);
                return value <= (prime / 2) ? x : prime - x;
            };

            Func<uint, uint> Next = idx =>
            {
                // map the values above the prime to themselves
                if (idx >= prime)
                    return idx;

                var x = Residue(ModPrime(idx + seed1));
                return Residue(ModPrime(x + seed2));
            };

            var _delta = max - min;
            var seq = from i in new ClosedInterval<uint>(1, _delta).Points() select Next(i) + min;
            var enumerator = seq.GetEnumerator();
            return () => enumerator.MoveNext() ? enumerator.Current : max;
        }
#endif //FSMATH

        /// <summary>
        /// Exposes generic accesses to <see cref="ValueSource{V}"/> production
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static ValueSource<T> CreateSource<T>(int? seed = null)
        {
            var m = GeneratorFactories[typeof(T)];            
            return (ValueSource<T>)m.Invoke(null, new object[] {new FacetSet(),  seed });
        }

        /// <summary>
        /// Cretaes a value source that incorporates a supplied connection of facets
        /// </summary>
        /// <typeparam name="T">The type of item produced by the source</typeparam>
        /// <param name="facets">The facets to apply</param>
        /// <param name="seed">The randomizer seet</param>
        /// <returns></returns>
        public static ValueSource<T> CreateSource<T>(IFacetSet facets, int? seed = null)
        {
            var m = GeneratorFactories[typeof(T)];
            return (ValueSource<T>)m.Invoke(null, new object[] {facets, seed });
        }
    }
}
