//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

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
