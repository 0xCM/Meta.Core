//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using static AppMessage;

public static class CommonMessages
{

    public static IAppMessage SequencePredicateUnsatisfied()
        => Inform("The sequence has no values that satisfies the predicate");

    public static IAppMessage MoreThanOneSequencePredicate()
        => Inform("The sequence has more than one value that satisfies the predicate");

    public static IAppMessage SequenceIsEmpty()
        => Inform("The sequence has no values");

    public static IAppMessage SequenceIsNotSingleton()
        => Inform("The sequence has more than one value");
}
