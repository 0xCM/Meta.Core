//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;

    using SqlT.Core;
    
    using static metacore;

    using sxc = contracts;

    public abstract class scalar_function<f> : function<f>, sxc.scalar_function
        where f : function<f>
       
    {
        public scalar_function(SqlFunctionName name)
            : base(name)
        {

        }
    }

    /// <summary>
    /// Abstract base type for scalar function syntax representations
    /// </summary>
    /// <typeparam name="f">The derived subtype</typeparam>
    /// <typeparam name="r">The return type</typeparam>
    public abstract class scalar_function<f, r> : scalar_function<f>, sxc.scalar_function<r>
        where f : scalar_function<f, r>
        where r : sxc.scalar_type
    {

        protected scalar_function(SqlFunctionName name)
            : base(name)
        {

        }
    }

    /// <summary>
    /// Base type for user-defined scalar functions
    /// </summary>
    /// <typeparam name="f"></typeparam>
    /// <typeparam name="r"></typeparam>
    public abstract class udf<f,r> : scalar_function<f,r>
        where f : scalar_function<f, r>
        where r : sxc.scalar_type
    {

        protected udf(SqlFunctionName name)
            : base(name)
        { }

    }
}