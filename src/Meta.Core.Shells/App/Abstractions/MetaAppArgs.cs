//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    using static metacore;


    public abstract class MetaAppArgs<A>
        where A : MetaAppArgs<A>, new()
    {
        protected static Option<T> GetParameter<T>(string parameter, T defaultValue, params string[] args)
        {
            var valueMarker = ':';
            try
            {
                args.Where(a => a.StartsWith($"/{parameter}:")).TryGetFirst()
                    .OnSome(x =>
                    {
                        var components = x.Split(valueMarker);
                        if (components.Length == 2)
                        {
                            defaultValue = parse<T>(components[1]);
                        }
                    });
            }
            catch (Exception e)
            {
                return none<T>(e);
            }
            return defaultValue;

        }

        protected MetaAppArgs()
        {
            Diagnostic = false;
        }

        protected MetaAppArgs(params string[] args)
        {
            Diagnostic = GetParameter(nameof(Diagnostic), false, args).Value();
        }

        public bool Diagnostic { get; set; }


    }


}
