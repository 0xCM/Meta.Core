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
    public class NumberTest
    {
        [UT.TestMethod]
        public void Conversions()
        {
            claim.equal(operators.convert<int, decimal>(4), 4.0m);
            claim.equal(operators.convert<decimal, int>(4.0m), 4);

            var fifty = Number.fromInt<decimal>(50);
            claim.equal(int32G(50), fifty.Convert<int>());
            claim.equal(int16G(50), fifty.Convert<short>());
            claim.equal(uint64G(50), fifty.Convert<ulong>());
        }

        [UT.TestMethod]
        public void Bounds()
        {
            var maxVal = Number.max<byte>();
            var next = Number.next(maxVal);
            claim.none(next);

            var prior = Number.prior(maxVal);
            claim.equal(maxVal - Number.one<byte>(), prior);
        }


        [UT.TestMethod]
        public void DecimalMin()
        {            
            claim.equal(@decimal(32), max(@decimal(3), @decimal(32)));
            claim.equal(@decimal(3), min(@decimal(3), @decimal(32)));
        }

        [UT.TestMethod]
        public void UInt32Max()
            => claim.equal(uint32(32), max(uint32(3), uint32(32)));

        [UT.TestMethod]
        public void UInt32Min()
            => claim.equal(uint32(3), min(uint32(3), uint32(32)));

        [UT.TestMethod]
        public void UInt64Max()
            => claim.equal(uint64(32), max(uint64(3), uint64(32)));

        [UT.TestMethod]
        public void UInt64Min()
            => claim.equal(uint64(3), min(uint64(3), uint64(32)));

        [UT.TestMethod]
        public void UInt16Max()        
            => claim.equal(uint16(32), max(uint16(3), uint16(32)));
        
        [UT.TestMethod]
        public void Int16Max()
            => claim.equal(int16(32), max(int16(3), int16(32)));        

        [UT.TestMethod]
        public void Int16Sum()
            => claim.equal(int16(30), int16(-5) + int16(35));

        [UT.TestMethod]
        public void Int32Sum()
            => claim.equal(int32(30), int32(-5) + int32(35));

        [UT.TestMethod]
        public void Int46Sum()
            => claim.equal(int64(30), int64(-5) + int64(35));

        [UT.TestMethod]
        public void UInt32Sum()
            => claim.equal(uint32(30), uint32(15) + uint32(15));

        [UT.TestMethod]
        public void LinqSum()
        {
            var sum = from x in number(10)
                      from y in number(20L)
                      select y + x;

            claim.equal(30L, sum.Value);
        }

        [UT.TestMethod]
        public void UInt8Increment()
        {
            var x = uint8G(5);
            claim.equal(uint8G(6), ++x);
        }

        [UT.TestMethod]
        public void Int8Increment()
        {
            var x = int8G(5);
            claim.equal(int8G(6), ++x);
        }

        [UT.TestMethod]
        public void UInt16Increment()
        {
            var x = uint16G(5);
            claim.equal(uint16G(6), ++x);
        }

        [UT.TestMethod]
        public void Int32Increment()
        {
            var x = int32G(5);
            claim.equal(int32G(6), ++x);
        }

        [UT.TestMethod]
        public void UInt8Decrement()
        {
            var x = uint8G(5);
            claim.equal(uint8G(4), --x);
        }

        [UT.TestMethod]
        public void Int8Decrement()
        {
            var x = int8G(5);
            claim.equal(int8G(4), --x);
        }

        [UT.TestMethod]
        public void UInt16Decrement()
        {
            var x = uint16G(5);
            claim.equal(uint16G(4), --x);
        }

        [UT.TestMethod]
        public void Int32Decrement()
        {
            var x = int32G(5);
            claim.equal(int32G(4), --x);
        }

        [UT.TestMethod]
        public void Int64Decrement()
        {
            var x = int64G(5);
            claim.equal(int64G(4), --x);
        }

        [UT.TestMethod]
        public void UInt64Decrement()
        {
            var x = uint64G(5);
            claim.equal(uint64G(4), --x);
        }

        [UT.TestMethod]
        public void UInt64Increment()
        {
            var x = uint64G(5);
            claim.equal(uint64G(6), ++x);
        }

        [UT.TestMethod]
        public void DecimalDecrement()
        {
            var x = decimalG(5);
            claim.equal(decimalG(4), --x);
        }

        [UT.TestMethod]
        public void DecimalIncrement()
        {
            var x = decimalG(5);
            claim.equal(decimalG(6), ++x);
        }

        [UT.TestMethod]
        public void FromInteger()
        {
            claim.equal(decimalG(3), Number.fromInt<decimal>(3));
        }
    }

}
