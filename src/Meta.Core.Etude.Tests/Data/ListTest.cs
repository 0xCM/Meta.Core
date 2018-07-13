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
    public class ListTest
    {

        [UT.TestMethod]
        public void ListSlice1()
        {
            var l1 = list(15,16,17,18,19);
            claim.equal(list(15, 16, 17), l1[0, 2]);
        }

        [UT.TestMethod]
        public void ListSlice2()
        {
            var l1 = list(15, 16, 17, 18, 19);
            claim.equal(list(19), l1[4,4]);
        }

        [UT.TestMethod]
        public void ListSlice3()
        {
            var l1 = list(15, 16, 17, 18, 19);
            claim.equal(Lst<int>.Empty, l1[50,50]);
        }

        [UT.TestMethod]
        public void ListFold1()
        {
            var input = list(1, 2, 3, 4, 5);
            var output = foldr(operators.add, 0, input);
            var expect = 15;
            claim.equal(expect, output);
        }

        [UT.TestMethod]
        public void ListFold2()
        {
            var input = list(1, 2, 3, 4, 5);
            var output = foldl(operators.add, 0, input);
            var expect = 15;
            claim.equal(expect, output);
        }

        [UT.TestMethod]
        public void ListFold3()
        {
            var items = list(2, 4, 6, 8);
            var f = func((int x, int y) => (x + y) * 2);
            var folded = foldl(f, 1, items);
            claim.equal(120, folded);
        }

        [UT.TestMethod]
        public void ListFold4()
        {
            var input = list(5, 10, 15, 20);
            var lResult = foldl(operators.add, 5, input);
            var rResult = foldr(operators.add, 5, input);
            claim.equal(lResult, rResult);
        }



        [UT.TestMethod]
        public void ListTails()
        {
            var src = list(1, 2, 3, 4, 5);
            var result = Lst.tails(src);
            var expect = list(list(1, 2, 3, 4, 5), list(2, 3, 4, 5), list(3, 4, 5), list(4, 5), list(5), list<int>());
            claim.equal(expect, result);

        }


        [UT.TestMethod]
        public void ListExtend()
        {
            var src = list(1, 2, 3, 4, 5);
            var f = func((Lst<int> x) => Lst.foldl(operators.add,0, x));
            var result = Lst.Extend<int, int>().extend(f)(src);
            var expect = list(15, 14, 12, 9, 5);
            claim.equal(expect, result);
            
        }

        [UT.TestMethod]
        public void ListEq()
        {
            var items = list(2, 4, 6, 8);
            var doubled = map(x => 2 * x, items);
            claim.equal(list(4, 8, 12, 16), doubled);
        }


        [UT.TestMethod]
        public void ListParse()
        {
            var input = list(10, -6, 16, 12, -8, 20, 14, -10, 24, 12, -4, 32, 14, -6, 40, 16, -8, 48, 14, -2, 48, 16, -4, 60, 18, -6, 72);
            var format = input.ToString();
            var output = Lst.parse<int>(format);
            claim.equal(input, output);
        }

        [UT.TestMethod]
        public void ListFoldable()
        {
            var input = list(5, 10, 15, 20);
            var output = foldr((x, y) => x + y, 0, input);
            claim.equal(operators.add(operators.add(operators.add(5, 10), 15), 20), output);
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

            var result = Lst.Apply<int, int>().apply(functions, numbers);
            claim.equal(expect, result);
        }

        [UT.TestMethod]
        public void SumSemigroup()
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
        public void ListBind()
        {
            var input = list(1, 5, 10);
            var f = func((int x) => list(x * 2, x * 4, x * 6));
            var expect = list(2, 4, 6, 10, 20, 30, 20, 40, 60);
            var result = bind(input, f);
            claim.equal(expect, result);

        }

        [UT.TestMethod]
        public void ListMul()
        {
            var l1 = list(1, 2, 3, 4, 5);
            var l2 = 3 * l1;
            var l3 = list(3, 6, 9, 12, 15);
            claim.equal(l3, l2);

        }


    }
}
