//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Language;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;


    public static partial class TSqlFactory
    {
        public static TSql.CreateSequenceStatement TSqlCreate(this SqlSequence src)
        {
            var tsql = new TSql.CreateSequenceStatement
            {
                Name = src.TSqlSchemaObjectName()
            };

            tsql.SequenceOptions.Add(new TSql.DataTypeSequenceOption
            {
                DataType = src.SequenceDataType.TSqlReference()
            });

            if (isNotBlank(src.InitialValue))
            {
                tsql.SequenceOptions.Add(new TSql.ScalarExpressionSequenceOption
                {
                    OptionKind = TSql.SequenceOptionKind.Start,
                    OptionValue = src.InitialValue.TSqlIntegerLiteral()
                });
            }

            if (isNotBlank(src.Increment))
            {
                tsql.SequenceOptions.Add(new TSql.ScalarExpressionSequenceOption
                {
                    OptionKind = TSql.SequenceOptionKind.Increment,
                    OptionValue = src.Increment.TSqlIntegerLiteral()

                });
            }

            if (isNotBlank(src.CacheSize))
            {
                tsql.SequenceOptions.Add(new TSql.ScalarExpressionSequenceOption
                {
                    OptionKind = TSql.SequenceOptionKind.Cache,
                    OptionValue = src.CacheSize.TSqlIntegerLiteral()

                });

            }
            return tsql;
        }


    }
}