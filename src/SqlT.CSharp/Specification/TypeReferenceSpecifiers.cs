//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.SqlSystem;

    using static metacore;
    using static ClrStructureSpec;
    using ClrModel;

    

    static class TypeReferenceSpecifiers
    {
        static readonly Type DefaultCollectionType = typeof(IReadOnlyList<>);

        public static ClrTypeReference SpecifyTypeReference(this ClrType clrType, CodeGenerationProfile gp)
        {
            if (clrType.IsValueType)
            {
                if (clrType.IsNullableType)
                    return new ClrNullableTypeReference(clrType.TypeName);
                else
                    return new ClrTypeReference(new ClrStructName(clrType.Name));
            }
            else
                return new ClrTypeReference(new ClrClassName(clrType.Name));
        }

        public static ClrTypeReference SpecifyTypeReference(this vColumn c, CodeGenerationProfile gp)
        {
            if (string.Compare(c.DataType.ReferencedType.Name, SqlNativeTypes.rowversion.Name.UnquotedLocalName,true) == 0  
                    || string.Compare(c.DataType.ReferencedType.Name, SqlNativeTypes.timestamp.Name.UnquotedLocalName,true) == 0)
                return ClrType.Get<SqlRowVersion>().SpecifyTypeReference(gp);

            var clrType
                = c.DataType.IsPrimitive
                ? c.DataType.UnderlyingPrimitive.Require().SpecifyProxyType(gp)
                : new ClrClass(typeof(object));

            if (c.IsNullable && clrType.IsValueType)
                return new ClrNullableTypeReference(clrType.TypeName);
            else
                return clrType.SpecifyTypeReference(gp);
        }

        public static ClrTypeReference SpecifyOptionReference(this ClrTypeReference subject)
            => new ClrTypeClosure(new ClrClassName("Option"),
                        new TypeArgument(new TypeParameter("P", 0), subject.ReferencedType)
                        );

        public static ClrTypeReference SpecifyOutcomeReference(this ClrTypeReference subject)
            =>new ClrTypeClosure(new ClrClassName(nameof(SqlOutcome)),
                        new TypeArgument(new TypeParameter("P", 0), subject.ReferencedType)
                        );

        static ClrTypeReference SpecifyReturnType(this ClrTypeReference subject, CodeGenerationProfile gp)
        {
            switch(gp.ReturnTypeStyle)
            {
                case MonadicFlavour.Option:
                    return subject.SpecifyOptionReference();
                default:
                    return subject.SpecifyOutcomeReference();
            }
        }

        public static ClrTypeReference SpecifyReturnTypeReference(this vTableFunction f, CodeGenerationProfile gp)
        {
            var name = new ClrInterfaceName(DefaultCollectionType.FormatGenericName(f.GetResultTypeName(gp).SimpleName));
            return new ClrTypeReference(name).SpecifyReturnType(gp);
        }

        public static ClrTypeReference SpecifyReturnTypeReference(this vProcedure p, CodeGenerationProfile gp)
        {
            if (p.ResultContractName)
            {
                var argName = p.ResultContractName.ValueOrDefault().SpecifyClassName().SimpleName;
                var name = new ClrInterfaceName(DefaultCollectionType.FormatGenericName(argName));
                return new ClrTypeReference(name).SpecifyReturnType(gp);
            }
            else
                return ClrType.Reference<int>().SpecifyReturnType(gp);
        }

        public static ClrTypeReference SpecifyTypeReference(this vParameter p, CodeGenerationProfile gp)
        {
            if (p.ParameterType.IsPrimitive)
            {
                var clrType = p.ParameterType.UnderlyingPrimitive.Require().SpecifyProxyType(gp);
                if (p.IsNullable && clrType.IsValueType)
                    return new ClrNullableTypeReference(clrType.TypeName);
                else
                    return clrType.SpecifyTypeReference(gp);
            }
            else if (p.ParameterType.IsRecord)
                return ClrCollectionClosure.Enumerable(new ClrClassName(p.ParameterType.SimpleTypeName));
            else if (p.ParameterType.IsAssemblyType)
                return ClrType.Reference<object>();
            else
                throw new NotSupportedException();
        }


    }
}