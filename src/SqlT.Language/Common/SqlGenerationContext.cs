//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using SqlT.Models;

    using Meta.Core;
    using SqlT.Services;

    using static metacore;

    /// <summary>
    /// Defines a component-based generation context
    /// </summary>
    public class SqlGenerationContext : ApplicationComponent, ISqlGenerationContext
    {
        public static SqlGenerationContext GetDefault(IApplicationContext C) 
            => new SqlGenerationContext(C);


        public SqlGenerationContext(IApplicationContext C, params SqlOptionValue[] options)
            : base(C)
        {
            Options = options;
            ElementTypeLookup = SqlElementTypes.GetLookup();
        }

        ISqlElementTypeLookup ElementTypeLookup { get; }

        public Option<SqlElementType> TryFindElementType(Type ModelType)
            => ElementTypeLookup.TryFind(ModelType);

        public SqlElementType FindElementType(string Identifier)
            => ElementTypeLookup.Find(Identifier);

        public ISqlScriptProvider ScriptProvider 
            => C.Service<ISqlScriptProvider>();

        /// <summary>
        /// The options applied during generation processes
        /// </summary>
        public Lst<SqlOptionValue> Options { get; }

    }
}
