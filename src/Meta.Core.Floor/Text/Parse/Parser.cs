﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{

    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Concurrent;

    using Modules;

    using static metacore;

    public static class Parser
    {
        
        static IConversionSuite Projector { get; }


        static Parser()
        {
            var closedMethods = new ConcurrentBag<MethodInfo>();
            var traverser = TypeClass.traverser(t =>
            {
                var parsers = from m in t.GetDeclaredMethods(MemberInstanceType.Static)
                              where m.HasAttribute<ParserAttribute>()
                              select m;
                closedMethods.AddRange(parsers.Where(p => not(p.IsGenericMethod)));
            });

            traverser.Traverse(MetaFloor.Assembly);
            Projector = ConversionSuite.FromMethods(closedMethods.ToArray());
        }

        public static Option<Func<string, Option<X>>> find<X>()
        {
            if (Projector.CanConvert(typeof(string), typeof(X)))
                return Try((string s) => Projector.Convert<X>(s));
            else if (Projector.CanConvert(typeof(string), typeof(Option<X>)))
                return Function.value(function((string s) => Projector.Convert<Option<X>>(s)));
                return default;                                                               
        }
    }

    public abstract class Parser<X>
    {
        protected Parser()
        { }


        public abstract Option<X> Parse(string input);

    }
}
