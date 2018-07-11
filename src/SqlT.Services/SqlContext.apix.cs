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

    using SqlT.SqlSystem;
    using static metacore;

    public static class SqlContextX
    {

        /// <summary>
        /// Executes a squence of sqlscripts
        /// </summary>
        /// <param name="C">The ambient context</param>
        /// <param name="scripts">The scripts to execute</param>
        /// <param name="Observer"></param>
        /// <returns></returns>
        public static Seq<Option<ISqlScript>> ExecuteBatchScripts(this ISqlContext C, Seq<ISqlScript> scripts)
                => from script in scripts select C.ExecuteBatchScript(script);

        /// <summary>
        /// Executes a script chunked into batches via the GO directive
        /// </summary>
        /// <param name="C">The ambient context</param>
        /// <param name="sql">The script to execute</param>
        /// <returns></returns>
        public static Option<ISqlScript> ExecuteBatchScript(this ISqlContext C, ISqlScript sql)
            => from batches in C.SqlParser().ParseBatches(sql)
               let broker = C.SqlClientBroker()
               let results = map(batches.Segments, seg => broker.ExecuteNonQuery(seg.ScriptText))
               from f in results.TryGetFirst(r => r.IsNone())
               select sql;                            
    }
}