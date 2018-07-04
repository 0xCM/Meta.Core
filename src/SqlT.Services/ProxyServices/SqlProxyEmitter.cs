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



    class SqlProxyEmitter : ApplicationComponent
    {
        public SqlProxyEmitter(IApplicationContext C, SqlEmissionConfig EmissionConfig)
            : base(C)
        {
            this.EmissionConfig = EmissionConfig;
        }

        public SqlEmissionConfig EmissionConfig { get; }

        public SqlConnectionString Connector
            => EmissionConfig.Connector;    
    }


    class SqlProxyEmitter<F, TResult> : SqlProxyEmitter, ISqlProxyEmitter<F,TResult>
        where F : class, ISqlTableFunctionProxy<F, TResult>, new()
        where TResult : class, ISqlTabularProxy, new()
    {

        static ISqlProxyBroker broker<T>(SqlConnectionString connector)
            where T : ISqlProxy
                => typeof(T).Assembly.ProxyBroker(connector);

        public SqlProxyEmitter(IApplicationContext C, SqlEmissionConfig<F, TResult> ExportConfig)
            : base(C, ExportConfig)
        {

            Broker = broker<F>(Connector);
            Formatter = C.SqlProxyFormatter();
        }

        ISqlProxyBroker Broker { get; }

        ISqlProxyFormatter Formatter { get; }

        IEnumerable<TResult> ResultStream(F proxy)
            => Broker.Stream<F, TResult>(proxy);

        Option<FilePath> ISqlProxyEmitter<F,TResult>.EmitFile(F proxy, FilePath DstFile)
        {
            int lines = 0;
            try
            {
                DstFile.Folder.CreateIfMissing().Require();

                using (var writer = new StreamWriter(DstFile))
                    foreach (var line in Formatter.FormatDelimited(ResultStream(proxy)))
                    {

                        writer.WriteLine(line.Target.Data);
                        lines++;
                    }
            }
            catch (Exception e)
            {
                return none<FilePath>(e);
            }

            if (lines != 0)
                Notify(inform($"Emitted {lines} {typeof(TResult).Name} records to {DstFile}"));
            else
            {
                Notify(inform($"There were no {typeof(TResult).Name} records to emit"));

                DstFile.DeleteIfExists();
            }

            return DstFile;
        }
    }
}