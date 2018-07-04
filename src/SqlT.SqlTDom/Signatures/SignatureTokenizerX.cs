//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    using Meta.Core;

    using SqlT.Models;
    using SqlT.Core;
    using SqlT.Services;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    enum SyntaxSuppression
    {
        Show,
        Supress
    }

    static partial class SignatureCalculator
    {
        static IReadOnlyDictionary<Type, object> DefaultTypeValues
            = stream(
                (typeof(int), (object)default(int)),
                (typeof(uint), default(uint)),
                (typeof(long), default(long)),
                (typeof(ulong), default(ulong)),
                (typeof(UIntPtr), default(UIntPtr)),
                (typeof(char), default(char)),
                (typeof(double), default(double)),
                (typeof(float), default(float)),
                (typeof(bool), default(bool)),
                (typeof(byte), default(byte)),
                (typeof(sbyte), default(sbyte)),
                (typeof(short), default(short)),
                (typeof(ushort), default(ushort))
                ).ToReadOnlyDictionary();

        static ConcurrentDictionary<Type, Enum> DefaultEnumValues
            = new ConcurrentDictionary<Type, Enum>();

        static SyntaxSuppression EvaluateSupression(ClrEnum enumType, Enum enumValue)
            => IsAssignedDefaultValue(enumType, enumValue)
                && SupressDefaultValue(enumType)
                ? SyntaxSuppression.Supress
                : SyntaxSuppression.Show;

        public static IReadOnlySet<Enum> EnumValueExclusions
            = roset(box(TSql.UniqueRowFilter.NotSpecified));

        public static IReadOnlySet<string> EnumDefaultValueExclusions
            = roset(
                typeof(TSql.UniqueRowFilter).Name,
                typeof(TSql.ColumnType).Name
                );

        public const string nothing = "<unspecified>";

        public static string getNothing()
            => nothing;

        public static Enum box(Enum input)
            => input;

        public static string Paren(object value)
            => $"({value ?? nothing})";

        public static bool IsAssignedDefaultValue(ClrEnum enumType, Enum value)
            => DefaultEnumValues.GetOrAdd(enumType, t => (Enum)Activator.CreateInstance(t)).Equals(value);

        public static bool SupressDefaultValue(ClrEnum enumType)
            => EnumDefaultValueExclusions.Contains(enumType.Name);


        public static SyntaxSuppression SupressValue(this SignaturePropertyValue eval)
        {
            var propType = eval.Property.PropertyType;

            if (eval.Value == null)
                return SyntaxSuppression.Supress;
            else if (propType.IsEnumType)
                return EvaluateSupression((ClrEnum)propType, (Enum)eval.Value);

            else return
                DefaultTypeValues.TryFind(eval.Property.PropertyType)
                        .Map(val => val == eval.Value
                                  ? SyntaxSuppression.Supress
                                  : SyntaxSuppression.Show,
                            () => SyntaxSuppression.Show);
        }       
    }

}