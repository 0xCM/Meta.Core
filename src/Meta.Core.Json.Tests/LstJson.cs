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

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;


    [UT.TestClass]
    public class LstJson
    {


        //global::Json ToJson<T>(T value)
        //    => JsonServices.ToJson(value);


        [UT.TestMethod]
        public void LstJson01()
        {
            var input = list(1, 2, 3, 4, 5);
            var json = JsonServices.ToJson(input);
            var output = JsonServices.ToObject<Lst<int>>(json);

            claim.equal(input, output);


        }

        [UT.TestMethod]
        public void LstJson05()
        {
            var syn = Synthetic.Create(RandomSeed.Seed01);
            var input = syn.Next<string>(500);
            var json = JsonServices.ToJson(input);
            var output = JsonServices.ToObject<Lst<string>>(json);
            claim.equal(input, output);

        }


    }



}