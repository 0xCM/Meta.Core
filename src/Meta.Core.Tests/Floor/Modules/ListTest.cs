//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Modules.Tests
{
    using System;
    using System.Linq;
    using Meta.Core.Modules;

    using static List;    
    using static operators;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory(nameof(metacore) + "/algebra")]
    public class ListTest
    {

        [UT.TestMethod]
        public void Test01()
        {
            var items = cons(2, 4, 6, 8);
            var doubled = map(x => 2 * x, items);
            claim.equal(cons(4, 8, 12, 16), doubled);
        }

        [UT.TestMethod]
        public void Test05()
        {
            var items = cons(2, 4, 6, 8);
            var f = Function.make((int x, int y) => (x + y) * 2);
            var folded = foldl(f, 1, items);
            claim.equal(120, folded);

        }

        [UT.TestMethod]
        public void Test15()
        {
            var input = cons(5, 10, 15, 20);
            var lResult = foldl(add, 5, input);
            var rResult = foldr(add, 5, input);
            claim.equal(lResult, rResult);

        }

        [UT.TestMethod]
        public void ListParse()
        {
            var input = cons(10, -6, 16, 12, -8, 20, 14, -10, 24, 12, -4, 32, 14, -6, 40, 16, -8, 48, 14, -2, 48, 16, -4, 60, 18, -6, 72);
            var format = input.ToString();
            var output = _List.parse<int>(format);
            claim.equal(input, output);
        }

        [UT.TestMethod]
        public void ListFoldable()
        {
            var input = cons(5, 10, 15, 20);
            var output = etude.foldr((x, y) => x + y, 0, input);
            claim.equal(add(add(add(5, 10), 15), 20), output);
        }

        [UT.TestMethod]
        public void ListFunctor1()
        {            
            var output = etude.fmap(x => x * 2,cons(2, 4, 6));
            var expect = cons(4, 8, 12);
            claim.equal(expect, output);

        }



        [UT.TestMethod]
        public void ListApplicative1()
        {
            //var applicative = Applicative<int, int>();
            //var output = applicative.apply((int x) => x * 2, cons(2, 4, 6));
            //var expect = cons(4, 8, 12);
            //claim.equal(expect, output);

        }

        [UT.TestMethod]
        public void ListApplicative2()
        {
            var numbers = cons(2, 4, 6);
            var functions = cons<Func<int, int>>(x => x * 2, x => x * 3, x => x * 4);
            var outcome = functions.Stream().Map(f => from n in map(f, numbers).Stream() select n);

        }

        [UT.TestMethod]
        public void SumTest()
        {
            var sum = from x in Sum.make(1)
                      from y in x + Sum.make(7)
                      select y;
            claim.equal(8, sum.Value);
        }

        [UT.TestMethod]
        public void ListLinq()
        {
            var list1 = cons(1, 2);
            var list2 = cons(3, 4);
            var output = from x in list1
                         from y in list2
                         select x + y;

            var expect = make(
                from x in list1.Stream()
                from y in list2.Stream()
                select x + y);

            claim.equal(expect, output);

        }

        [UT.TestMethod]
        public void ListFunctor()
        {
        }



    }
}

