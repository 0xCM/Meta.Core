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

    using G = ChoiceGrammar;


    public sealed class EnumChoice<E> : Choice<E>
        where E : Enum
    {
    
        public EnumChoice(E Value)
            : base(new ChoiceIdentity($"{Value}", typeof(E).Name), Value)
        {

        }

    }
  
}