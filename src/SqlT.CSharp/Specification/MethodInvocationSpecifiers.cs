//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.SqlSystem;

    using static metacore;
    using static ClrStructureSpec;
    using static ClrBehaviorSpec;
    using ClrModel;

    /// <summary>
    /// Defines factory methods for <see cref="MethodInvocationSpec"/> and <see cref="ConstructorInvocationSpec"/> 
    /// </summary>
    static class MethodInvocationSpecifiers
    {

        public static MethodInvocationSpec SpecifyInvocation(this MethodSpec method, IEnumerable<MethodArgumentValueSpec> args, CodeGenerationProfile gp)
                => new MethodInvocationSpec(method.DeclaringTypeName, (ClrMethodName)method.Name, false, args.ToArray());


        public static ConstructorInvocationSpec SpecifyConstructorInvocation(this SqlTableName subject)
            => new ConstructorInvocationSpec(ClrType.Reference<SqlTableName>(),
                    new MethodArgumentValueSpec(0, subject.UnqualifiedName.SpecifyLiteralValue()),
                    new MethodArgumentValueSpec(1, subject.UnqualifiedName.SpecifyLiteralValue()),
                    new MethodArgumentValueSpec(2, subject.SchemaName.UnqualifiedName.SpecifyLiteralValue()),
                    new MethodArgumentValueSpec(3, subject.UnqualifiedName.SpecifyLiteralValue()));

        public static ConstructorInvocationSpec SpecifyConstructorInvocation(this SqlDatabaseName subject)
            => new ConstructorInvocationSpec(ClrType.Reference<SqlDatabaseName>(),
                    new MethodArgumentValueSpec(0, new LiteralValueSpec(subject.ServerName.UnqualifiedName)),
                    new MethodArgumentValueSpec(1, new LiteralValueSpec(subject.UnqualifiedName)));


    }

}