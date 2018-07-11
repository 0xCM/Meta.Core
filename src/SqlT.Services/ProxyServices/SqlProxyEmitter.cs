//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using System.IO;

    using Meta.Core;
    using SqlT.Core;

    using static metacore;

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


    class SqlProxyEmitter<F, Y> : SqlProxyEmitter, ISqlProxyEmitter<F,Y>
        where F : class, ISqlTableFunctionProxy<F, Y>, new()
        where Y : class, ISqlTabularProxy, new()
    {

        static ISqlProxyBroker broker<T>(SqlConnectionString connector)
            where T : ISqlProxy
                => typeof(T).Assembly.ProxyBroker(connector);

        public SqlProxyEmitter(IApplicationContext C, SqlEmissionConfig<F, Y> ExportConfig)
            : base(C, ExportConfig)
        {

            Broker = broker<F>(Connector);
            Formatter = C.SqlProxyFormatter();
        }

        ISqlProxyBroker Broker { get; }

        ISqlProxyFormatter Formatter { get; }

        Option<FilePath> ISqlProxyEmitter<F,Y>.EmitFile(F proxy, FilePath DstFile)
        {
            int lines = 0;
            try
            {
                DstFile.Folder.CreateIfMissing().Require();

                using (var writer = new StreamWriter(DstFile))
                    iter(Formatter.FormatDelimited(Seq.make(Broker.Stream<F, Y>(proxy))), line =>
                    {

                        writer.WriteLine(line.Target.Data);
                        lines++;
                    });
            }
            catch (Exception e)
            {
                return none<FilePath>(e);
            }

            if (lines != 0)
                Notify(inform($"Emitted {lines} {typeof(Y).Name} records to {DstFile}"));
            else
            {
                Notify(inform($"There were no {typeof(Y).Name} records to emit"));

                DstFile.DeleteIfExists();
            }

            return DstFile;
        }
    }
}