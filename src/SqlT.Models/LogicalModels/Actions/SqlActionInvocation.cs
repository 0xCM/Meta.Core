//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Syntax;
    using SqlT.Core;

    using static metacore;

    using sxc = SqlT.Syntax.contracts;

    public static class SqlActionInvocation
    {
        static CoreTypeReference CreateCoreRef(ICoreType coreType, sxc.type_ref typeref)
        {
            switch(typeref)
            {
                case sxc.data_type_ref dt:
                    return coreType.CreateReference(not(dt.nullable), dt.length, dt.precision, dt.scale);
                default:
                    return coreType.CreateReference(not(typeref.nullable));
            }
        }

        public static IEnumerable<SqlParameterValue> ComputeArguments(ISqlAction Action, IReadOnlyDictionary<string, object> ArgumentIndex)
        {
            foreach (var arg in ArgumentIndex)
            {
                var paramValue = Action[arg.Key].Map(parameter =>
                {
                    var coreType = parameter.ReferencedType.MapToCoreType();
                    var sqlRef = parameter.TypeReference;
                    var coreRef = CreateCoreRef(coreType, parameter.TypeReference);                    
                    var parameterName = parameter.ParameterName;
                    var coreValue = coreRef.CreateValue(arg.Value);
                    return new SqlParameterValue(parameterName, coreValue);
                });
                if (paramValue)
                    yield return paramValue.Require();
            }
        }

        public static SqlProcedureInvocation<T> CreateInvocation<T>(this SqlProcedureCall<T> Action, 
            IReadOnlyDictionary<string, object> ArgumentIndex)
                where T : SqlProcedureCall<T>
                    => new SqlProcedureInvocation<T>(ArgumentIndex, Action);

        public static SqlScriptInvocation<T> CreateInvocation<T>(this SqlQueryScript<T> Action, 
            IReadOnlyDictionary<string, object> ArgumentIndex)
                where T : SqlQueryScript<T>
                    => new SqlScriptInvocation<T>(ArgumentIndex, Action);
    }

    /// <summary>
    /// Represents the invocation of a <see cref="SqlAction{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SqlActionInvocation<T> : ISqlActionInvocation
        where T : SqlAction<T>
    {

        ISqlAction ISqlActionInvocation.Action
            => Action;

        IReadOnlyList<SqlParameterValue> ISqlActionInvocation.Arguments
            => Arguments;

        public SqlActionInvocation(IReadOnlyDictionary<string, object> ArgumentIndex, SqlAction<T> Action)
        {
            this.Action = Action;
            this.Arguments = SqlActionInvocation.ComputeArguments(Action, ArgumentIndex).ToList();
        }

        public IReadOnlyList<SqlParameterValue> Arguments { get; }

        public SqlAction<T> Action { get; }
    }
}

