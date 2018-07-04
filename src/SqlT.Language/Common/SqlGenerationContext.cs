//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using SqlT.Models;

    using SqlT.Services;

    using static metacore;

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
