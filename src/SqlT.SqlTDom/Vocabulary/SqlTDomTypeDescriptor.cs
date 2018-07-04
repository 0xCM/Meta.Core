//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Services;
    using SqlT.SqlTDom;
    using SqlT.Types.SqlDom;

    using static ClrInterface;
    using static metacore;
    

    /// <summary>
    /// Describes a type defined by the T-SQL DOM
    /// </summary>
    class SqlTDomTypeDescriptor
    {
        static IEnumerable<ClrInterface> GetClassifyingInterfaces(SqlDomTypeDescriptor TypeDescriptor)
        {
            switch (TypeDescriptor.DomElementKind)
            {
                case ElementKind.NonscalarExpression:
                    yield return Get<ISqlTDomExpression>();
                    break;
                case ElementKind.ScalarExpression:
                    yield return Get<ISqlTDomScalarExpression>();
                    break;
                case ElementKind.Infrastructure:
                    yield return Get<ISqlTDomInfrastructure>();
                    break;
                case ElementKind.Literal:
                    yield return Get<ISqlTDomLiteral>();
                    break;
                case ElementKind.Option:
                    yield return Get<ISqlTDomOption>();
                    break;
                case ElementKind.AlterStatement:
                    yield return Get<ISqlTDomAlterStatement>();
                    break;

                case ElementKind.CreateStatement:
                    yield return Get<ISqlTDomCreateStatement>();
                    break;
                case ElementKind.DropStatement:
                    yield return Get<ISqlTDomDropStatement>();
                    break;
                default:
                    yield return Get<ISqlTDomElement>();
                    break;
            }
        }

        public SqlTDomTypeDescriptor(SqlDomTypeDescriptor TypeDescriptor)
        {
            var type = (ClrClass)TypeDescriptor.SqlDomType;
            this.TypeDescriptor = TypeDescriptor;
            this.ClassifyingInterfaces = GetClassifyingInterfaces(TypeDescriptor).ToReadOnlySet();
            this.TypeHasBaseType = isNotNull(type.BaseType);
            this.BaseType = type.BaseType;

        }


        public SqlDomTypeDescriptor TypeDescriptor { get;  }

        public IReadOnlySet<ClrInterface> ClassifyingInterfaces { get; }

        public bool TypeHasBaseType { get; }

        public bool TypeIsModeled { get; set; }

        public bool TypeIsSpecified { get; set; }

        public ClrClass BaseType { get; }

        public bool BaseTypeIsModeled { get; set; }
        public bool BaseTypeIsSpecified { get; set; }
    
        public bool ShouldSpecifyBaseType
            => TypeHasBaseType && BaseTypeIsModeled && not(BaseTypeIsSpecified);


    }

}
