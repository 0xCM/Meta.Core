//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;        

    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Specifies object definitions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="B"></typeparam>
    public abstract class SqlObjectBuilder<T, B> : SqlElementBuilder<T, B>
        where T : SqlObject<T>
        where B : SqlObjectBuilder<T, B>
    {
        protected sxc.ISqlObjectName ObjectName { get; }

        protected SqlObjectBuilder(sxc.ISqlObjectName ObjectName)
        {
            this.ObjectName = ObjectName;
        }

    }
}
