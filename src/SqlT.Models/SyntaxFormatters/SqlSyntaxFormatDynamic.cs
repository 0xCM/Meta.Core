//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax.Formatting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using Meta.Core;
    using SqlT.Core;

    using static SqlSyntax;
    using static metacore;

    using sxc = contracts;

    static class SqlSyntaxFormatDynamic
    {
        static IConversionSuite formatters;

        static SqlSyntaxFormatDynamic()
            => formatters = ConversionSuite.FromTypes(typeof(SqlSyntaxFormatters));

        public static string FormatDynamic(this IModel m)
        {
            if (m == null)
                return NULL;
            return $"{formatters.Convert(m, o => o.ToString())}";
        }

        public static string FormatDynamic(this object o)
            => SqlClrValueFormatters.FormatClrValue(o);

        internal static IEnumerable<IModel> Filter(this IEnumerable<IModel> models)
        {
            foreach (var model in models)
            {
                if (model is IModelOption o)
                {
                    if (o.exists)
                        yield return o.value;
                    else
                        yield return model;
                }
                else
                    yield return model;
            }
        }
        internal static IReadOnlyList<IModel> Normalize(this IEnumerable<IModel> models)
            => Filter(models).ToReadOnlyList();
    }

}