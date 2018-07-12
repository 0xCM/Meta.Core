//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using static metacore;
    using System.Reflection;
    
    static class SqlStatusMessages
    {

        public static IAppMessage Executing(SqlProcedureName procedure)
            => inform($"Executing {procedure}");

        public static IAppMessage Executed(SqlProcedureName procedure)
            => inform($"Excuted {procedure}");

        public static IAppMessage NoBrokerFactoriesExist(Assembly a)
            =>  error( $"The assembly {a} defines no broker factories");

        public static IAppMessage TooManyBrokerFactories(Assembly a)
            => error($"The assembly {a} defines more than one broker factory and there is no means to distinguish which one is needed");

        public static IAppMessage NullTableTypeProxy(string ParameterName)
            => error($"Encountered null table type proxy for {ParameterName} parameter");

    }
}