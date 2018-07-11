//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using Meta.Core;
    using SqlT.Core;

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