//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Syntax;
    using sxc = SqlT.Syntax.contracts;
    using static Syntax.SqlSyntax;

    /// <summary>
    /// Defines a model classifier
    /// </summary>
    public sealed class SqlModelType : IEquatable<SqlModelType>, IModelType
    {
        public SqlModelType(ClrType SpecifyingType)
        {
            this.SpecifyingType = SpecifyingType;            
            this.Identifier 
                = SpecifyingType.TryGetCustomAttribute<SqlElementTypeAttribute>()
                                .Map(x => x.ModelTypeId, 
                                    () => SpecifyingType.Name);
        }


        string IModelType.ModelTypeId
            => Identifier;

        Type IModelType.SpecifyingType
            => SpecifyingType;

        bool IModelType.IsSameAs(IModelType candiate)
            => candiate.ModelTypeId == Identifier;

        public string Identifier { get; }

        public Type SpecifyingType { get; }

        public override string ToString()
            => Identifier;

        public override bool Equals(object obj)
            => Equals(obj as SqlModelType);

        public override int GetHashCode()
            => SpecifyingType.GetHashCode();

        public bool Equals(SqlModelType other)
            => SpecifyingType.Equals(other?.SpecifyingType);

    }
}
