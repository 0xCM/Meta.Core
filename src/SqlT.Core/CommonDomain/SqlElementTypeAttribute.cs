//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
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
