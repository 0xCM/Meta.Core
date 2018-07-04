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

    using Meta.Models;
    using Meta.Syntax;

    using SqlT.Core;
    using SqlT.Syntax;
    using sxc = SqlT.Syntax.contracts;

    using static metacore;


    /// <summary>
    /// Represents an action specification script
    /// </summary>
    /// <typeparam name="M">The action subtype</typeparam>
    public abstract class SqlCommandScript<M> : SqlCommandAction<M>, ISqlModelScript , ISqlElement
        where M :  SqlCommandScript<M> 
    {
        readonly SqlModelScript<M> ModelScript;


        protected SqlCommandScript(IModelType TargetType, string ScriptText, params SqlRoutineParameter[] Parameters)
            : base(TargetType.ModelTypeId, Parameters)
        {
            this.TargetType = TargetType;
            this.ModelScript = new SqlModelScript<M>(ScriptText, map(Parameters, p => p.ParameterName));

        }


        public IModelType TargetType { get; }

        SqlScriptName ISqlScript.ScriptName
            => ModelScript.ScriptName;

        public IReadOnlyList<SqlParameterName> ParameterNames
            => ModelScript.ParameterNames;


        public SqlScript Script
            => ModelScript;


        public string ScriptId
            => ModelScript.ScriptId;

        public string ScriptText
            => ModelScript.ScriptText;


        public override bool RequiresScript
            => true;


        public Option<SqlElementDescription> Documentation 
            => ((ISqlElement)ModelScript).Documentation;

        public IReadOnlyList<SqlPropertyAttachment> Properties 
            => ((ISqlElement)ModelScript).Properties;

        public bool IsSchemaObject 
            => ((ISqlElement)ModelScript).IsSchemaObject;

        public IName ElementName 
            => ((ISqlElement)ModelScript).ElementName;
    }

    /// <summary>
    /// Represents a script that specifies a command
    /// </summary>
    public sealed class SqlCommandScript : SqlCommandScript<SqlCommandScript>
    {
        public SqlCommandScript(IModelType SpecificationType, string ScriptText)
            : base(SpecificationType, ScriptText)

        { }

        public SqlCommandScript(IModel Specification, string ScriptText)
            : this(Specification.ModelType, ScriptText)

        { }


    }

}
