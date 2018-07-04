//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using SqlT.Syntax;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;
    
    using static Syntax.SqlSyntax;

    /// <summary>
    /// Defines an element classifier
    /// </summary>
    public sealed class SqlElementType  : IModelType 
    {
        internal static SqlElementType Create<M>(SqlIdentifier Identifier) 
                    where M :class,  ISqlElement
                        => new SqlElementType(typeof(M), Identifier);

        internal SqlElementType(Type ModelElementType, SqlIdentifier Identifier                ) 
        {
            this.SpecifyingType = ModelElementType;
            this.ModelTypeId = Identifier;
        }


        public Type SpecifyingType { get; }

        public string ModelTypeId { get; }

        public override string ToString()
            => ModelTypeId.ToString();

        public bool IsSameAs(IModelType candiate)
            => this.ModelTypeId == candiate?.ModelTypeId;
    }
}
