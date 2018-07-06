//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;    
    using ETN = Syntax.SqlElementTypeNames;
    using I = Syntax.SqlIdentifier;
    
    
    /// <summary>
    /// Declares supported element types
    /// </summary>
    public class SqlElementTypes : ISqlElementTypeLookup
    {
        static object locker = new object();
        static ISqlElementTypeLookup lookup;

        public static ISqlElementTypeLookup GetLookup()
        {
            lock(locker)
            {
                if (lookup == null)
                    lookup = new SqlElementTypes();
            }

            return lookup;
        }

        IReadOnlyDictionary<Type, SqlElementType> elements;

        public SqlElementType Find(string Identifier)
            => isNull(elements)  
               ? null 
               : elements.Values.First(x => x.ModelTypeId == Identifier);

        public  Option<SqlElementType> TryFind(Type ModelType)
            => isNull(elements) 
            ? null 
            :  elements.TryFind(ModelType);

        class SqlAnonymousElement : SqlElement<SqlAnonymousElement>
        {
            public SqlAnonymousElement()
                : base(new SqlColumnName())
            { }
        }

        SqlElementTypes()
        {
            try
            {
                elements = dict(from t in GetType().Assembly.ClrAssembly().Types
                                let a = t.TryGetCustomAttribute<SqlElementTypeAttribute>()
                                where a.IsSome()
                                let identifier = a.MapRequired(x => x.ModelTypeId)
                                let et = new SqlElementType(t, new I(identifier, false))
                                select (t.ReflectedElement, et));

            }
            catch (Exception e)
            {
                SystemConsole.Get().Write(error(e));
                throw;
            }
        }
    }

}
