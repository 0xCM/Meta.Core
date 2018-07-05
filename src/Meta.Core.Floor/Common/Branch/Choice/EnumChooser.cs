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

  

    public class EnumChooser<E>
       where E : Enum
    {
        
        public EnumChooser(Func<E, Option<E>> Next)
        {
            var choices = Choices.FromEnum<E>();
            this.Next = Next;
        }

        Func<E, Option<E>> Next { get; }

        IEnumerable<EnumChoice<E>> _Execute(EnumChoice<E> s0)
        {
            var result = Next(s0.Value);
            while (result)
            {
                var choice = result.Require();
                yield return new EnumChoice<E>(choice);
                result = Next(choice);
            }
        }

        public Lst<EnumChoice<E>> Execute(EnumChoice<E> s0)
            => Lst.make(_Execute(s0));

        public Lst<EnumChoice<E>> Execute(E s0)
            => Execute(new EnumChoice<E>(s0));


    }
}