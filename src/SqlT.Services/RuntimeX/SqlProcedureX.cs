//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

    using SqlT.Core;

    public static partial class SqlBrokerExtensions
    {

        internal static Option<int> exec(ISqlProcedureHandle h, params (string, object)[] parameters)
            => h.Broker.ExecuteProcedure(h.ElementName, parameters);

        static (string, object)[] zip(string[] paramNames, params object[] paramValues)
        {
            var zipped = new (string, object)[paramNames.Length];
            for (int i = 0; i < paramNames.Length; i++)
                zipped[i] = (paramNames[i], paramValues[i]);
            return zipped;
        }

        public static Func<SqlConnectionString, Option<int>> Prepare(this ISqlProcedureHandle p)
            => cs => exec(p);

        public static Func<SqlConnectionString, P0, Option<int>> Prepare<P0>(this ISqlProcedureHandle p, params string[] paramNames)
            => (cs, p0) => exec(p, zip(paramNames, p0));

        public static Func<SqlConnectionString, P0, P1, Option<int>> Prepare<P0, P1>(this ISqlProcedureHandle p, params string[] paramNames)
            => (cs, p0, p1) => exec(p, zip(paramNames, p0, p1));

        public static Func<SqlConnectionString, P0, P1, P2, Option<int>> Prepare<P0, P1, P2>(this ISqlProcedureHandle p, params string[] paramNames)
            => (cs, p0, p1, p2) => exec(p, zip(paramNames, p0, p2, p2));
    }
}
