//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class App
    {
        static void Test1()
        {

            var context = new GenContext("", "", "Meta.Core");
            var spec = new NewTypeSpec("ZipCode", "string");
            var emit = Emission.Emit(context, spec);
        }


        public static void Main(params string[] args)
        {
            Test1();
        }
    }
}