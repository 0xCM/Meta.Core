//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;
    using sxc = Syntax.contracts;

    public interface ISqlProxyProcedureCall<P> : sxc.procedure_call<P>, sxc.proxy_expression
        where P : sxc.procedure
    {


    }

    public interface ISqlProxyProcedureCall<P, R> : ISqlProxyProcedureCall<P>, sxc.procedure_call<P, R>, sxc.proxy_expression<R>
        where P : sxc.procedure<R>
        where R : ISqlTabularProxy
    {


    }




}