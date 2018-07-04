//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    public static class ServiceFactory
    {

        public static ISqlStructureGenerator CSharpStructureGenerator(this IApplicationContext C)
            => C.Service<ISqlStructureGenerator>();

        public static ICSharpSnippetGenerator CSharpSnippetGenerator(this IApplicationContext C)
            => C.Service<ICSharpSnippetGenerator>();

        public static ISqlProxyGenerator CSharpProxyGenerator(this IApplicationContext C)
            => C.Service<ISqlProxyGenerator>();

        public static ISqlFieldListGenerator CSharpFieldListGenerator(this IApplicationContext C)
            => C.Service<ISqlFieldListGenerator>();

        public static ICSharpEnumGenerator CSharpEnumGenerator(this IApplicationContext C)
            => C.Service<ICSharpEnumGenerator>();

        public static ICSharpProjectGenerator CSharpProjectGenerator(this IApplicationContext C)
            => C.Service<ICSharpProjectGenerator>();

        public static ICSharpScriptExecutor<TOut> CSharpScriptExecutor<TOut>(this IApplicationContext C)
            => new CSharpScriptExecutor<TOut>(C);

        public static ISqlProxyProfileManager SqlProxyProfileManager(this IApplicationContext C)
            => C.Service<ISqlProxyProfileManager>();

    }
}