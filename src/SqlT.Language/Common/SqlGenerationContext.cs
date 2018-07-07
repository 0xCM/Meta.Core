//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using SqlT.Models;

    using SqlT.Services;

    using static metacore;

    /// <summary>
    /// Defines a component-based generation context in lieu of a full 
    /// <see cref="IApplicationContext"/>
    /// </summary>
    public class SqlGenerationContext : ApplicationComponent, ISqlGenerationContext
    {
        public static SqlGenerationContext GetDefault(IApplicationContext C) 
            => new SqlGenerationContext(C);

        public Option<SqlElementType> TryFindElementType(Type ModelType)
            => ElementTypeLookup.TryFind(ModelType);

        public SqlElementType FindElementType(string Identifier)
            => ElementTypeLookup.Find(Identifier);

        ISqlElementTypeLookup ElementTypeLookup { get; }

        public SqlGenerationContext(IApplicationContext C, params SqlOptionValue[] options)
            : base(C)
        {
            Options = rolist(options);
            ElementTypeLookup = SqlElementTypes.GetLookup();
        }

        public ISqlScriptProvider ScriptProvider 
            => C.Service<ISqlScriptProvider>();

        public IReadOnlyList<SqlOptionValue> Options { get; }

    }


}
