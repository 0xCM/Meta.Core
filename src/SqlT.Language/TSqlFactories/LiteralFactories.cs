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
    using SqlT.Services;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;
    
    partial class TSqlFactory
    {
        public static TSql.IntegerLiteral TSqlIntegerLiteral(this string value) 
            => new TSql.IntegerLiteral
            {
                Value = value
            };

        public static TSql.StringLiteral TSqlStringLiteral(this string value)
           => new TSql.StringLiteral
           {
               Value = value.ToString()
           };

        public static TSql.StringLiteral TSqlStringLiteral(this Enum value)
           => new TSql.StringLiteral
           {
               Value = value.ToString()
           };

        public static TSql.IntegerLiteral TSqlIntegerLiteral(this Enum value)
           => new TSql.IntegerLiteral
           {
               Value = Convert.ToInt32(value).ToString()
           };

        public static TSql.IntegerLiteral TSqlIntegerLiteral(this int value)
           => new TSql.IntegerLiteral
           {
               Value = value.ToString()
           };

        public static TSql.StringLiteral TSqlStringLiteral(this FilePath path)
            => new TSql.StringLiteral
            {
                Value = path.Value
            };

        public static TSql.StringLiteral TSqlStringLiteral(this SqlName name)
            => new TSql.StringLiteral
            {
                Value = name.FullName
            };

        public static TSql.Literal TSqlLiteral(this CoreDataValue value)
        {
            if(value.ValueAsText == null)
                return new TSql.NullLiteral();
            else if(value.DataType.ReferencedType.IsInteger)
                return value.ValueAsText.TSqlIntegerLiteral();
            else if(value.DataType.ReferencedType.IsText)
                return new TSql.StringLiteral
                {
                    Value = value.ValueAsText
                };
            else if(value.DataType.ReferencedType is CoreMoneyType)
                return new TSql.MoneyLiteral
                {
                    Value = value.ValueAsText
                };
            else
                throw new NotImplementedException();
        }
    }
}
