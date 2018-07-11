﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;


    using static metacore;
    using static etude;


    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

    [UT.TestClass, UT.TestCategory("metacore/etude/data")]
    public class UnionTest
    {


        public enum Label
        {
            Label1,
            Label2,
            Label3,
            Label4
        }


       


        [UT.TestMethod]
        public void Test01()
        {
            var lu2 = ldu(Label.Label1, 15).WithType<decimal>();
        }


    }

}