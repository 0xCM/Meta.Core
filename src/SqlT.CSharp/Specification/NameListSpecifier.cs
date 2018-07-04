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

    using sxc = SqlT.Syntax.contracts;

    static class NameListSpecifiers

    {
        public static ClassSpec SpecifyNameLiteralClass(ClrClassName ClassName, IReadOnlyList<sxc.ISqlObjectName> ObjectNames)
            => new ClassSpec
                (
                    Name: ClassName,
                    Members: map(ObjectNames.OrderBy(x => x.UnqualifiedName), n => n.SpecifyLiteralField(ClassName)),
                    IsPartial: false,
                    IsSealed: true
                );

        public static FieldSpec SpecifyTypedNameField(this SqlMessageTypeName MessageTypeName, ClrClassName DeclaringTypeName)
            => new FieldSpec
            (

                 DeclaringTypeName,
                 Name: MessageTypeName.UnqualifiedName.ToLegalIdentifier(),
                 FieldType: ClrType.Get(MessageTypeName.GetType()).GetReference(),
                 AccessLevel: ClrAccessKind.Public,
                 IsConst: false,
                 IsStatic: true,
                 IsReadOnly: true,
                 Initializer: new ClrBehaviorSpec.LiteralValueSpec(toString(MessageTypeName))

            );

        public static FieldSpec SpecifyTypedNameField(this SqlIndexName Name, ClrClassName DeclaringTypeName)
            => new FieldSpec
            (

                 DeclaringTypeName,
                 Name: Name.UnqualifiedName.ToLegalIdentifier(),
                 FieldType: ClrType.Get(Name.GetType()).GetReference(),
                 AccessLevel: ClrAccessKind.Public,
                 IsConst: false,
                 IsStatic: true,
                 IsReadOnly: true,
                 Initializer: new ClrBehaviorSpec.LiteralValueSpec(toString(Name))

            );


        public static FieldSpec SpecifyTypedNameField(this sxc.ISqlObjectName FieldName, ClrClassName DeclaringTypeName)
            => new FieldSpec
            (

                 DeclaringTypeName,
                 Name: FieldName.ToLegalIdentifier(),
                 FieldType: ClrType.Get(FieldName.GetType()).GetReference(),
                 AccessLevel: ClrAccessKind.Public,
                 IsConst: false,
                 IsStatic: true,
                 IsReadOnly: true,
                 Initializer: new ClrBehaviorSpec.LiteralValueSpec(toString(FieldName))

            );

        public static ClassSpec SpecifySqlNameList(ClrClassName ClassName, SqlProxyGenerationProfile gp,
                IReadOnlyList<NamedValue> NamedLiterals)
             => new ClassSpec
                (
                    Name: ClassName,
                    AccessLevel: gp.SpecifyEffectiveAccessLevel(),
                    Members: map(NamedLiterals.OrderBy(x => x.Name), n => n.SpecifyLiteralField(ClassName)),
                    IsPartial: false,
                    IsSealed: true
                );

        public static ClassSpec SpecifySqlNameList(this vServiceMessageType t,
                SqlProxyGenerationProfile gp, IReadOnlyList<vServiceMessageType> types)
            => new ClassSpec
                (
                    Name: t.SpecifyNameListClassName(gp),
                    AccessLevel: gp.SpecifyEffectiveAccessLevel(),
                    Members: map(types.OrderBy(x => x.Name),
                        type => new SqlMessageTypeName(type.Name).SpecifyTypedNameField(t.SpecifyNameListClassName(gp))),
                    IsPartial: false,
                    IsSealed: true            
                );

        public static ClassSpec SpecifySqlNameList(this vIndex prototype,
                SqlProxyGenerationProfile gp, IReadOnlyList<vIndex> indexes)
            => new ClassSpec
                (
                    Name: prototype.SpecifyNameListClassName(gp),
                    AccessLevel: gp.SpecifyEffectiveAccessLevel(),
                    Members: map(indexes.OrderBy(x => x.Name),
                        index => new SqlIndexName(index.Name).SpecifyTypedNameField(prototype.SpecifyNameListClassName(gp))),
                    IsPartial: false,
                    IsSealed: true
                );


        public static ClassSpec SpecifySqlNameList<V>(this vObject o,
                SqlProxyGenerationProfile gp, IReadOnlyList<V> ObjectNames) where V : vObject
            => new ClassSpec
                (
                    Name: o.SpecifyNameListClassName(gp),
                    AccessLevel: gp.SpecifyEffectiveAccessLevel(),
                    Members: map(ObjectNames.OrderBy(x => x.ObjectName.UnqualifiedName),
                        n => n.ObjectName.SpecifyTypedNameField(o.SpecifyNameListClassName(gp))),
                    IsPartial: false,
                    IsSealed: true
                );

        public static ClassSpec SpecifySqlNameList(this vType t, SqlProxyGenerationProfile gp,
                IReadOnlyList<sxc.ISqlObjectName> ObjectNames)
            => new ClassSpec
                (
                    Name: t.SpecifyNameListClassName(gp),
                    AccessLevel: gp.SpecifyEffectiveAccessLevel(),
                    Members: map(ObjectNames.OrderBy(x => x.UnqualifiedName),
                        n => n.SpecifyTypedNameField(t.SpecifyNameListClassName(gp))),
                    IsPartial: false,
                    IsSealed: true
                );
    }

}