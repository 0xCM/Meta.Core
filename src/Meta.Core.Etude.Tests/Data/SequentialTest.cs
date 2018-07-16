//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;


    using static metacore;
    using static etude;


    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("metacore/etude/data")]
    public class SequentialTest
    {

        [UT.TestMethod]
        public void CanSequenceUInt8()
            => claim.@true(operators.sequential<byte>());

        [UT.TestMethod]
        public void CanSequenceInt8()
            => claim.@true(operators.sequential<sbyte>());

        [UT.TestMethod]
        public void CanSequenceInt16()
            => claim.@true(operators.sequential<short>());

        [UT.TestMethod]
        public void CanSequenceUInt16()
            => claim.@true(operators.sequential<ushort>());


        [UT.TestMethod]
        public void CanSequenceInt32()
            => claim.@true(operators.sequential<int>());

        [UT.TestMethod]
        public void CanSequenceUInt32()
            => claim.@true(operators.sequential<uint>());


        [UT.TestMethod]
        public void CanSequenceInt64()
            => claim.@true(operators.sequential<long>());

        [UT.TestMethod]
        public void CanSequenceUInt64()
            => claim.@true(operators.sequential<ulong>());

        [UT.TestMethod]
        public void CanSequenceDecimal()
            => claim.@true(operators.sequential<decimal>());

        [UT.TestMethod]
        public void UInt8Successors()
        {
                        
        }
    }

}