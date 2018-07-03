//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Tests
{
    using System;
    using System.Linq;
    
    //using static List;    
    using static operators;
    using static etude;
    using static metacore;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("metacore/collections")]
    public class ListTest
    {

        [UT.TestMethod]
        public void Test01()
        {
            var items = list(2, 4, 6, 8);
            var doubled = map(x => 2 * x, items);
            claim.equal(list(4, 8, 12, 16), doubled);
        }

        [UT.TestMethod]
        public void Test05()
        {
            var items = list(2, 4, 6, 8);
            var f = func((int x, int y) => (x + y) * 2);
            var folded = foldl(f, 1, items);
            claim.equal(120, folded);

        }

        [UT.TestMethod]
        public void Test15()
        {
            var input = list(5, 10, 15, 20);
            var lResult = foldl(add, 5, input);
            var rResult = foldr(add, 5, input);
            claim.equal(lResult, rResult);

        }

        [UT.TestMethod]
        public void ListParse()
        {
            var input = list(10, -6, 16, 12, -8, 20, 14, -10, 24, 12, -4, 32, 14, -6, 40, 16, -8, 48, 14, -2, 48, 16, -4, 60, 18, -6, 72);
            var format = input.ToString();
            var output = _List.parse<int>(format);
            claim.equal(input, output);
        }

        [UT.TestMethod]
        public void ListFoldable()
        {
            var input = list(5, 10, 15, 20);
            var output = foldr((x, y) => x + y, 0, input);
            claim.equal(add(add(add(5, 10), 15), 20), output);
        }

        [UT.TestMethod]
        public void ListFunctor1()
        {            
            var output = fmap(x => x * 2, list(2, 4, 6));
            var expect = list(4, 8, 12);
            claim.equal(expect, output);
        }


        [UT.TestMethod]
        public void ListApplicative()
        {
            var numbers = list(2, 4, 6);
            var functions = list<Func<int, int>>(x => x * 2, x => x * 3, x => x * 4);            
            var expect = from f in functions
                         from x in numbers
                         select f(x);

            var result = List.Apply<int, int>().apply(functions, numbers);
            claim.equal(expect, result);
        }

        [UT.TestMethod]
        public void SumTest()
        {
            var sum = from x in SemigroupOp.make(1)
                      from y in x + SemigroupOp.make(7)
                      select y;
            claim.equal(8, sum.Value);
        }

        [UT.TestMethod]
        public void ListLinq()
        {
            var list1 = list(1, 2);
            var list2 = list(3, 4);
            var output = from x in list1
                         from y in list2
                         select x + y;

            var expect = list(
                from x in list1.Stream()
                from y in list2.Stream()
                select x + y);

            claim.equal(expect, output);

        }

        [UT.TestMethod]
        public void ListTails()
        {
            var input = list(1, 2, 3, 4, 5);
            var output = tails(input);
            claim.equal(5, output.Count);
            claim.equal(input, output[0]);
            claim.equal(List.empty<int>(), output[4]);

        }

        [UT.TestMethod]
        public void ListBindTest()
        {
            var input = list(1, 5, 10);
            var f = func((int x) => list(x * 2, x * 4, x * 6));
            var expect = list(2, 4, 6, 10, 20, 30, 20, 40, 60);
            var result = bind(input, f);
            claim.equal(expect, result);

        }

        [UT.TestMethod]
        public void ListMulTest()
        {
            var l1 = list(1,2,3,4,5);
            var l2 = 3 * l1;
            var l3 = list(3, 6, 9, 12, 15);
            claim.equal(l3, l2);
            
        }



    }
}

