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

    using Meta.Core;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;    
    using SqlT.SqlSystem;

    using static metacore;
    using static ClrStructureSpec;

    using sxc = SqlT.Syntax.contracts;

    static class NameSpecifiers
    {
        static readonly IReadOnlyDictionary<char, char> CharacterReplacements
           = new Dictionary<char, char>
           {
               [' '] = '_',
               ['#'] = 'Ʌ',
               ['!'] = 'ȼ',
               ['$'] = 'ʂ',
               ['+'] = Symbol.ᕀ,
               ['-'] = Symbol.ᐨ,
               ['.'] = '_',
               ['/'] = '_',
                ['\\'] = Symbol.ノ,
               ['%'] = Symbol.ተ,
               ['|'] = Symbol.ǀ,
               ['?'] = Symbol.ॽ,
               ['='] = Symbol.ᛏ,
               ['('] = Symbol.ᐸ,
               [')'] = Symbol.ᐳ

           };

        static readonly IReadOnlyDictionary<string, string> StringReplacements
            = new Dictionary<string, string>
            {
                ["internal"] = "@internal",
                ["object"] = "@object",
                ["override"] = "@override",
                ["default"] = "@default",
                ["new"] = "@new",
                ["event"] = "@event",
                ["class"] = "@class",
                ["operator"] = "@class",
                ["readonly"] = "@readonly"

            };


        static readonly ReadOnlySet<char> CharacterRemovals
            = new ReadOnlySet<char>(stream('[', ']', '&'));

        static string GetLiteralClassNamePrefix(this SqlProxyGenerationProfile gp, string SchemaName)
        {
            var defaultName = SchemaName;
            var profileName = gp.Schemas.Single(s => s.SchemaName == SchemaName).LiteralClassNamePrefix;
            return String.IsNullOrWhiteSpace(profileName) ? SchemaName : profileName;
        }

        public static string ToLegalIdentifier(this string input)
            => input.RemoveAny(CharacterRemovals)
                    .ReplaceAny(CharacterReplacements)
                    .ReplaceExact(StringReplacements);

        public static string ToLegalIdentifier(this sxc.ISqlObjectName subject)
            => subject.UnqualifiedName.ToLegalIdentifier();

        static IReadOnlyDictionary<ObjectType, string> NameListRootNames = new Dictionary<ObjectType, string>
        {
            [SqlObjectTypeCodes.F] = "ForeignKey",
            [SqlObjectTypeCodes.FN] = "ScalarFunction",
            [SqlObjectTypeCodes.IF] = "TableFunction",
            [SqlObjectTypeCodes.P] = "Procedure",
            [SqlObjectTypeCodes.PK] = "PrimaryKey",
            [SqlObjectTypeCodes.S] = "SystemTable",
            [SqlObjectTypeCodes.SN] = "Synonym",
            [SqlObjectTypeCodes.SO] = "Sequence",
            [SqlObjectTypeCodes.SQ] = "ServiceQueue",
            [SqlObjectTypeCodes.TR] = "Trigger",
            [SqlObjectTypeCodes.TT] = "TableType",
            [SqlObjectTypeCodes.TF] = "TableFunction",
            [SqlObjectTypeCodes.UQ] = "UniqueConstraint",
            [SqlObjectTypeCodes.U] = "Table",
            [SqlObjectTypeCodes.V] = "View"

        };

        public static FieldSpec SpecifyLiteralField(this NamedValue subject, ClrClassName DeclaringTypeName)
            => new FieldSpec
            (
                 DeclaringTypeName,
                 Name: subject.Name,
                 FieldType: ClrType.Reference<string>(),
                 AccessLevel: ClrAccessKind.Public,
                 IsConst: true,
                 Initializer: new ClrBehaviorSpec.LiteralValueSpec(toString(subject.Value))
            );


        public static FieldSpec SpecifyLiteralField(this sxc.ISqlObjectName FieldName, ClrClassName DeclaringTypeName)
            => new FieldSpec
            (
                 DeclaringTypeName,
                 Name: FieldName.ToLegalIdentifier(),
                 FieldType: ClrType.Reference<string>(),
                 AccessLevel: ClrAccessKind.Public,
                 IsConst: true,
                 Initializer: new ClrBehaviorSpec.LiteralValueSpec(toString(FieldName))
            );

        public static ClrMethodParameterName SpecifyMethodParameterName(this vParameter subject)
            => remove(subject.Name, "@").ToLegalIdentifier();

        public static ClrPropertyName SpecifyPropertyName(this vColumn subject)
            => (subject.Name == subject.ParentName.UnqualifiedName ? $"{subject.Name}Column" : subject.Name).ToLegalIdentifier();

        public static ClrPropertyName SpecifyPropertyName(this vIndexColumn subject)
            => (subject.Name == subject.IndexName.UnqualifiedName 
                    ? $"{subject.IndexName}Column" 
                    : subject.Name).ToLegalIdentifier();

        public static ClrPropertyName SpecifyPropertyName(this vPrimaryKeyColumn subject)
            => (subject.Name == subject.PrimaryKeyName.UnqualifiedName 
                ? $"{subject.PrimaryKeyName}Column" 
                : subject.Name).ToLegalIdentifier();

        public static ClrPropertyName SpecifyPropertyName(this vParameter subject)
            => remove(subject.Name, "@").ToLegalIdentifier();

        public static ClrClassName SpecifyClassName(this sxc.ISqlObjectName subject)
            => new ClrClassName(subject.UnqualifiedName.ToLegalIdentifier());

        public static ClrEnumName SpecifyEnumName(this vTable subject, SqlEnumProviderProperty enumProvider)
            => enumProvider.PropertyValue.IsAnonymous ?
            (
                subject.Name.EndsWith("Type")
            ? new ClrEnumName(subject.Name.Replace("Type", "Kind"))
            : new ClrEnumName(concat(subject.Name, "Kind").ToLegalIdentifier())
            ) : enumProvider.PropertyValue;

        public static ClrClassName SpecifyClassName(this vObject subject)
            => subject.ObjectName.SpecifyClassName();

        public static ClrClassName SpecifyClassName<T>(this SqlObjectName<T> name)
            where T : SqlObjectName<T>, new()
                => new ClrClassName(name.UnqualifiedName.ToLegalIdentifier());

        public static ClrClassName SpecifyClassName(this vTable subject)
            => subject.Name.ToLegalIdentifier();

        public static ClrClassName SpecifyClassName(this vView subject)
            => subject.Name.ToLegalIdentifier();

        public static ClrClassName SpecifyClassName(this vTableType subject)
            => subject.Name.ToLegalIdentifier();

        public static ClrClassName SpecifyClassName(this vTableFunction subject)
            => subject.Name.ToLegalIdentifier();

        public static ClrClassName SpecifyClassName(this vProcedure subject)
            => subject.Name.ToLegalIdentifier();

        public static ClrClassName SpecifyClassName(this vIndex subject)
            => subject.Name.ToLegalIdentifier();

        public static ClrClassName SpecifyNameListClassName(this vType t, SqlProxyGenerationProfile gp)
        {
            var prefix = gp.GetLiteralClassNamePrefix(t.SchemaName);
            var middle = t.IsTableType ? "Table" : t.IsUserPrimitive
                                    ? "Data" : t.IsAssemblyType
                                    ? "Assembly" : String.Empty;
            var suffix = "TypeNames";
            return prefix + middle + suffix;
        }

        public static ClrClassName SpecifyFormatStringListName(this vSchema s)
            => $"{s.Name.ToLegalIdentifier()}FormatStrings";

        public static ClrClassName SpecifyNameListClassName(this vObject o, SqlProxyGenerationProfile gp)
        {
            var prefix = gp.GetLiteralClassNamePrefix(o.SchemaName);
            return NameListRootNames.Where(x => x.Key.TypeCode == o.ObjectType).TryGetSingle()
                        .Map(
                            code => $"{prefix}{code.Value}Names",
                            () => $"{prefix}{o.ObjectType}Names");
        }
    
        public static ClrClassName SpecifyNameListClassName(this vServiceMessageType t, SqlProxyGenerationProfile gp)
            => "SqlServiceMessageTypeNames";

        public static ClrClassName SpecifyNameListClassName(this vIndex t, SqlProxyGenerationProfile gp)
            => $"{t.ParentName.SchemaNamePart}IndexNames";

    }
}