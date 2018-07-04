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
    using System.Collections.Concurrent;

    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Core;
    using sxc = SqlT.Syntax.contracts;
    using SqlT.Syntax;

    /// <summary>
    /// Represents a SQL specification script
    /// </summary>
    public abstract class SqlSpecScript<T> : SqlModelScript<T>, IModel
        where T : SqlSpecScript<T>
    {
        protected SqlSpecScript(IName ElementName, IModelType SpecificationType, string ScriptText, IEnumerable<SqlParameterName> Parameters)
            : base(SpecificationType, ScriptText, Parameters.ToArray())
        {
            this.ElementName = ElementName;
            this.SpecificationType = SpecificationType;
        }

        public IName ElementName { get; }

        public IModelType SpecificationType { get; }



    }

    public sealed class SqlSpecScript : SqlSpecScript<SqlSpecScript>
    {
        public static implicit operator SqlScript(SqlSpecScript src)
            => new SqlScript(src.ScriptName,src.ScriptText);

        public static implicit operator SqlModelScript(SqlSpecScript src)
            => new SqlModelScript(src.ScriptName, src.ModelType, src.ScriptText, src.ParameterNames);

        public SqlSpecScript(IName ElementName, IModelType SpecificationType, string ScriptText, params SqlParameterName[] Parameters)
            : base(ElementName, SpecificationType, ScriptText, Parameters)
        {

        }

        public SqlSpecScript(ISqlModelScript src, params SqlParameterName[] Parameters)
            : base(src.ScriptName, src.ModelType, src.ScriptText, Parameters)
        {


        }

        public SqlModelScript ToModelScript()
            => this;

    }


    public sealed class SqlElementSpecScript : SqlSpecScript<SqlElementSpecScript>, ISqlElementSpecScript 
    {
        public static implicit operator SqlModelScript(SqlElementSpecScript src)
            => new SqlModelScript(src.ElementName, src.ModelType, src.ScriptText, src.ParameterNames);

        readonly static Type ParametrizedType 
            = typeof(SqlElementSpecScript<>);

        readonly static ConcurrentDictionary<string, Type> ScriptTypes 
            = new ConcurrentDictionary<string, Type>();


        public static SqlElementSpecScript Create(IName ElementName, IModelType ModelType,  string ScriptText, params SqlParameterName[] Parameters)
            => new SqlElementSpecScript(ElementName, ModelType, ScriptText, Parameters);

        SqlElementSpecScript(IName ElementName, IModelType ModelType, string ScriptText, params SqlParameterName[] Parameters)
            : base(ElementName, ModelType, ScriptText, Parameters)
        {
            this.ModelTypeIdentifer = ModelType.ModelTypeId;
            
        }
        

        public string ModelTypeIdentifer { get; }

    }

    /// <summary>
    /// Represents an element specification script
    /// </summary>
    public class SqlElementSpecScript<E> : SqlSpecScript<SqlElementSpecScript<E>>, ISqlElementSpecScript
        where E : SqlElement<E>
    {
        public static implicit operator string(SqlElementSpecScript<E> s) 
            => s.ScriptText;


        public SqlElementSpecScript(IName ElementName, IModelType ElementType, string ScriptText, params SqlParameterName[] Parameters)
            : base(ElementName, ElementType, ScriptText, Parameters)
        {
            
        }

        string ISqlElementSpecScript.ModelTypeIdentifer
            => SpecificationType.ModelTypeId;


    }
}
