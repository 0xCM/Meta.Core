//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class SqlTFactory
    {
        static string GetOptionValue(this TSql.CreateSequenceStatement src, TSql.SequenceOptionKind optionKind)
        {
            var option = src.SequenceOptions.OfType<TSql.ScalarExpressionSequenceOption>().FirstOrDefault(x => x.OptionKind == optionKind);
            if (option != null)
                return (option.OptionValue as TSql.Literal).Value;
            else
                return null;
        }

        [SqlTBuilder]
        public static SqlSequence Model(this TSql.CreateSequenceStatement src)
        {

            return new SqlSequence
                (
                    SequenceName: src.Name.ToSequenceName(),
                    CacheSize: src.GetOptionValue(TSql.SequenceOptionKind.Cache),
                    SequenceDataType: src.ModelSequenceDataType(),
                    Increment: src.GetOptionValue(TSql.SequenceOptionKind.Increment),
                    InitialValue: src.GetOptionValue(TSql.SequenceOptionKind.Start),
                    MaxValue: src.GetOptionValue(TSql.SequenceOptionKind.MaxValue)
                );
        }

    }
}