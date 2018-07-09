//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;    

    using Meta.Models;
    using Meta.Core;
    using SqlT.Models;

    /// <summary>
    /// Defines a context for SQL generation, in lieu of a full <see cref="IApplicationContext"/>
    /// </summary>
    public interface ISqlGenerationContext
    {
        Lst<SqlOptionValue> Options { get; }

        ISqlScriptProvider ScriptProvider { get; }

        Option<SqlElementType> TryFindElementType(Type ModelType);

        SqlElementType FindElementType(string Identifier);
    }

    public delegate ISqlModelScript SqlGeneratorFunction(ISqlGenerationContext context, IModel spec);
}
