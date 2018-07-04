//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;

    using static contracts;
    using static metacore;

    using sxc = contracts;


    /// <summary>
    /// Abstract base type for native scalar functions
    /// </summary>
    /// <typeparam name="f">The derived subtype</typeparam>
    public abstract class native_scalar_function<f> : scalar_function<f>, sxc.native_scalar_function
        where f : native_scalar_function<f>
    {
        protected static readonly f instance;

        public static f get()
            => instance;

        static native_scalar_function()
        {
            try
            {

                instance =
                    (from ctor in typeof(f).TryGetDefaultPrivateConstructor()
                     let v = (f)ctor.Invoke(array<object>())
                     select v).ValueOrDefault();
            }
            catch (Exception e)
            {
                SystemConsole.Get().Write(error($"Trapped an exception in native_scalar_function static constructor: {e}"));
            }
        }

        static SqlFunctionName normalize(SqlFunctionName name)
            => new SqlFunctionName("sys", name.UnquotedLocalName.text.ToLower(), false);

        protected native_scalar_function(SqlFunctionName name)
            : base(normalize(name))
        { }

        protected native_scalar_function()
            : base(typeof(f).Name.ToLower())
        {

        }
    }

    /// <summary>
    /// Abstract base type for native scalar functions for which a return type has been specified
    /// </summary>
    /// <typeparam name="f">The derived subtype</typeparam>
    /// <typeparam name="r">The function return type</typeparam>
    public abstract class native_scalar_function<f, r> : native_scalar_function<f>, sxc.native_scalar_function<r>
        where f : native_scalar_function<f, r>
        where r : sxc.scalar_type
    {

        protected native_scalar_function(SqlFunctionName name)
            : base(name)
        { }

        protected native_scalar_function()
            : base(typeof(f).Name)
        {


        }
    }
}