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
    using sx = SqlT.Syntax.SqlSyntax;

    using static metacore;

    /// <summary>
    /// Represents an action specification script
    /// </summary>
    /// <typeparam name="M">The action subtype</typeparam>
    public abstract class SqlQueryScript<M> : SqlQueryAction<M>, ISqlModelScript, ISqlObjectQueryScript, ISqlElement
        where M : SqlQueryScript<M>
    {
        readonly SqlModelScript<M> ModelScript;

        protected SqlQueryScript(string ScriptText, sxc.ISqlObjectName SourceObject, params SqlRoutineParameter[] Parameters)
            : base(Parameters)
        {
            this.TargetType = new SqlModelType(ClrClass.Get<M>());
            this.SourceObject = some(SourceObject);
            this.SourceDatabase = SourceObject.GetDatabaseName();
            this.ModelScript = new SqlModelScript<M>(ScriptText, map(Parameters, p => p.ParameterName));
        }


        protected SqlQueryScript(ICompositeSqlName name, IModelType SpecType, string ScriptText, params SqlRoutineParameter[] Parameters)
            : base(name, Parameters)
        {
            this.TargetType = SpecType;
            this.ModelScript = new SqlModelScript<M>(SpecType, ScriptText,
                Parameters.Select(p => new SqlParameterName(p.ElementName)).ToArray());
        }

        public override bool RequiresScript
            => true;

        public Option<SqlDatabaseName> SourceDatabase { get; }

        public Option<sxc.ISqlObjectName> SourceObject { get; }

        public IModelType TargetType { get; }

        public SqlScriptName ScriptName
            => ModelScript.ScriptName;

        public IReadOnlyList<SqlParameterName> ParameterNames
            => ModelScript.ParameterNames;

        public string ScriptText
            => ModelScript.ScriptText;

        public string ScriptId
            => ModelScript.ScriptId;


        public Option<SqlElementDescription> Documentation 
            => ((ISqlElement)ModelScript).Documentation;

        IReadOnlyList<SqlPropertyAttachment> ISqlElement.Properties 
            => ((ISqlElement)ModelScript).Properties;

         bool ISqlElement.IsSchemaObject 
            => ((ISqlElement)ModelScript).IsSchemaObject;

        IName sxc.element.ElementName 
            => ((ISqlElement)ModelScript).ElementName;
    }

    public sealed class SqlQueryScript : SqlQueryScript<SqlQueryScript>
    {

        public SqlQueryScript(IModelType SpecType, string ScriptText, params SqlRoutineParameter[] Parameters)
            : base(new SqlName("Anonymous"), SpecType, ScriptText, Parameters.ToArray())

        { }

        public SqlQueryScript(ICompositeSqlName name, IModelType SpecType, string ScriptText, params SqlRoutineParameter[] Parameters)
            : base(name,  SpecType, ScriptText, Parameters.ToArray())

        { }



    }
}
