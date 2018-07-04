//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using System.IO;
    using Meta.Core;
    using SqlT.Core;

    using static metacore;
    using static sqlfunc;

    public class SqlEmissionConfig
    {

        public SqlEmissionConfig(SqlConnectionString Connector, SqlFunctionName ExportFunction)
        {

            this.Connector = Connector;
            this.ExportFunction = ExportFunction;
        }

        public SqlFunctionName ExportFunction { get; }

        public object[] ExportFunctionArgs { get; }

        public SqlConnectionString Connector { get; }


        public DelimitedTextDescription Description { get; }
            = new DelimitedTextDescription();

        public int BatchSize { get; }
            = 5000;

        public int StatusFrequency { get; }
            = 1000;

        public override string ToString()
            => ExportFunction;
    }

    public class SqlEmissionConfig<F, TResult> : SqlEmissionConfig
        where F : class, ISqlTableFunctionProxy<F, TResult>, new()
        where TResult : class, ISqlTabularProxy, new()
    {

        public SqlEmissionConfig(SqlConnectionString Connector)
            : base(Connector, PXM.TableFunction<F>().ObjectName)
        {

        }
    }


}