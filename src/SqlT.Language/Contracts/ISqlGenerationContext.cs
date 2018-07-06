//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;

    using Meta.Models;
    using SqlT.Models;

    /// <summary>
    /// Defines a context for SQL generation, in lieu of a full <see cref="IApplicationContext"/>
    /// </summary>
    public interface ISqlGenerationContext
    {
        IReadOnlyList<SqlOptionValue> Options { get; }

        ISqlScriptProvider ScriptProvider { get; }

        Option<SqlElementType> TryFindElementType(Type ModelType);

        SqlElementType FindElementType(string Identifier);
    }

    public delegate ISqlModelScript SqlGeneratorFunction(ISqlGenerationContext context, IModel spec);
}
