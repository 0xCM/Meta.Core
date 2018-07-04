//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using SqlT.Syntax;

    using static metacore;

    /// <summary>
    /// Associates one or more SQL Element Type with a CLR Class Type
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SqlElementTypeAttribute : Attribute
    {
        public SqlElementTypeAttribute(string ModelTypeId)
        {
            this.ModelTypeId = ModelTypeId;
        }

        public string ModelTypeId { get; }

        public override string ToString()
            => ModelTypeId;
    }

}
