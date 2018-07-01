//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using static ApplicationMessage;

public static class CommonMessages
{

    public static IApplicationMessage SequencePredicateUnsatisfied()
        => Inform("The sequence has no values that satisfies the predicate");

    public static IApplicationMessage MoreThanOneSequencePredicate()
        => Inform("The sequence has more than one value that satisfies the predicate");

    public static IApplicationMessage SequenceIsEmpty()
        => Inform("The sequence has no values");

    public static IApplicationMessage SequenceIsNotSingleton()
        => Inform("The sequence has more than one value");
}
