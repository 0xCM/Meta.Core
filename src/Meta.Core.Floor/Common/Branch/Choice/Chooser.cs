//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    using Modules;
    public class Chooser
    {

        public Chooser(Func<Choice, Option<Choice>> Next)
        {
            this.Next = Next;
        }

        MutableList<Choice> Transitions { get; }
           = MutableList.Create<Choice>();

        Func<Choice, Option<Choice>> Next { get; }


        IEnumerable<Choice> _Execute(Choice s0)
        {
            var result = Next(s0);
            while (result)
            {
                var choice = result.Require();
                yield return choice;
                result = Next(choice);
            }

        }
        public Seq<Choice> Execute(Choice s0)
            => Seq.make(_Execute(s0));


    }




}