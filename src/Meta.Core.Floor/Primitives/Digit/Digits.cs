﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;

    using static metacore;

    public readonly struct Digits : IContainer<Digit,Digits>, IEquatable<Digits>  
    {
        /// <summary>
        /// Trasforms the input text into a <see cref="Digits"/> value, if possible, otherwise None
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Option<Digits> Parse(string text)
        {
            var digits = map(c => Digit.Parse(c), text.AsList());

            return digits.Any(x => x.IsNone()) 
                ? default 
                : from d in flip(digits) select new Digits(d);                                             
        }
          
        /// <summary>
        /// Evaluates digit container equality
        /// </summary>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static bool operator ==(Digits s1, Digits s2)
            => s1.Equals(s2);

        /// <summary>
        /// Evaluates digit container equality
        /// </summary>
        /// <param name="s1">The first sequence</param>
        /// <param name="s2">The second sequence</param>
        /// <returns></returns>
        public static bool operator !=(Digits s1, Digits s2)
            => s1.Equals(s2);

        /// <summary>
        /// Canonical concatenator
        /// </summary>
        /// <param name="s1">The first digit container</param>
        /// <param name="s2">The second digit container</param>
        /// <returns></returns>
        public static Digits operator +(Digits s1, Digits s2)
            => s1.Data + s2.Data;

        /// <summary>
        /// Converts a <see cref="Digit"/> container to <see cref="Digit"/> list
        /// </summary>
        /// <param name="d"></param>
        public static implicit operator List<Digit>(Digits d)
            => d.Data;

        /// <summary>
        /// Converts a <see cref="Digit"/> array <see cref="Digit"/> container
        /// </summary>
        /// <param name="d"></param>
        public static implicit operator Digits(Digit[] data)
            => new Digits(data);

        /// <summary>
        /// Converts a <see cref="Digit"/> list <see cref="Digit"/> container
        /// </summary>
        /// <param name="d"></param>
        public static implicit operator Digits(List<Digit> data)
            => new Digits(data);

        public Digits(params Digit[] data)
            => this.Data = data;
       
        List<Digit> Data { get; }

        public Cardinality Cardinality
            => Cardinality.Finite;

        public Seq<Digit> Contained()
            => Data.Contained();

        public IEnumerable<Digit> Stream()
            => Data.Stream();

        public ContainerFactory<Digit, Digits> Factory()
           => src => new Digits(array(src));

        public bool Equals(Digits other)
            => this.Data.Equals(other.Data);

        public override bool Equals(object obj)
            => (obj is Digits) ? Equals((Digit)obj) : false;

        public override int GetHashCode()
            => Data.GetHashCode();

        public override string ToString()
            => Data.ToString();

    }


}