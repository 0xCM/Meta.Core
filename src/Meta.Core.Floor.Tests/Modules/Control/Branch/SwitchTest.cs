//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;

    using Modules;

    using static metacore;
    using static operators;
    using static etude;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;


    [UT.TestClass, UT.TestCategory(nameof(metacore) + "/api")]
    public class ApiTest
    {
        [UT.TestMethod]
        public void Test01()
        {
            var input = Lst.intersperse("+", Lst.fuse("One", "Two", "Three"));
            var output = combine(input.Contained());
            claim.equal("One+Two+Three", output);

            
        }

        [UT.TestMethod]
        public void Test05()
        {
            var input = Lst.fuse(uint8(5), uint8(10), uint8(15));
            var output = combine<byte>(input);
            claim.equal(uint8(30), output);


        }

        [UT.TestMethod]
        public void Test10()
        {
            var input = list(int32(5), int32(10), int32(15));
            var expect = list(int32(-5), int32(-10), int32(-15));
            var output =  Lst.map(neg, input);
            claim.equal(expect, output);
        }


        [UT.TestMethod]
        public void Test15()
        {            
            var f = func((int x) => 3 * x);
            var g = func((int x) => 2 * x);
            var list1 = list(1, 2, 3, 4);
            var list2 = list(5, 6, 7, 8);

            //custom LINQ over custom list where
            //functions evaulate over custom list instances
            var result1 = from x in f[list1]
                          from y in g[list2]
                          select $"{x}{y}";

            //standard LINQ over IEnumerable where
            //functions evaluate point-wise as usual
            var result2 = list(from x in list1.Stream()
                               from y in list2.Stream()
                               select $"{f.Eval(x)}{g.Eval(y)}"
                               );

            //custom LINQ over custom list where
            //functions evaluate point-wise via custom 'pipe' operator
            var result3 = from x in list1
                          from y in list2                          
                          select $"{x > f}{y > g}";


            //qed
            claim.allEqual(result1, result2, result3);
            
            //heh. 

        }


        public enum Choice
        {
            ChoiceA,
            ChoiceB,
            ChoiceC,
            ChoiceD
        }


        Func<Choice, string> Switch1
            => from s in Switch.build<Choice, string>()
               from case1 in s.Case(x => x == Choice.ChoiceA, x => "Choice-A")
               from case2 in s.Case(x => x == Choice.ChoiceB, x => "Choice-B")
               from case3 in s.Case(x => x == Choice.ChoiceC, x => "Choice-C")               
               select s.Evaluator(_ => "Not Supported");

        Func<Choice, string> Switch2
            => from s in Switch.build<Choice, string>()
               let f0 = Function.make<Choice, string>(x => "")
               let f1 = f0.Redefine(x => $"f1-{x}")
               from case1 in s.Case(x => x == Choice.ChoiceA, f1)
               let f2 = f0.Redefine(x => $"f2-{x}")
               from case2 in s.Case(x => x == Choice.ChoiceB, f2) 
               let f3 = f0.Redefine(x => $"f3-{x}")
               from case3 in s.Case(x => x == Choice.ChoiceC, f3)
               select s.Evaluator(_ => "Not Supported");



        //[UT.TestMethod]
        public void SwitchTest01()
        {            
            claim.equal("Choice-A", Switch1(Choice.ChoiceA));
            claim.equal("Not Supported", Switch1(Choice.ChoiceD));

        }

        [UT.TestMethod]
        public void SwitchTest02()
        {
            claim.equal("f1-ChoiceA", Switch2(Choice.ChoiceA));
            claim.equal("f2-ChoiceB", Switch2(Choice.ChoiceB));
            claim.equal("Not Supported", Switch2(Choice.ChoiceD));
        }




    }

}