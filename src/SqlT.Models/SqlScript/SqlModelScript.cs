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

    using static metacore;
    using sxc = Syntax.contracts;

    public class SqlModelScript<M> : SqlScript<SqlModelScript<M>>, ISqlModelScript , ISqlElement
        where M : class, ISqlElement
    {

        public static implicit operator SqlScript(SqlModelScript<M> x)
            => new SqlScript(x.ScriptName, x.ScriptId, x.ScriptText, x.ParameterNames.ToList());

        static readonly SqlIdentifier _ScriptIdentifier
            = SqlScriptAttribute.GetScriptIdentifier(typeof(M)).ValueOrDefault(SqlIdentifier.empty);

        static readonly SqlScriptName _ScriptName
            = isBlank(_ScriptIdentifier.IdentifierText) 
            ? SqlScriptName.Empty 
            : SqlScriptName.Parse(_ScriptIdentifier.IdentifierText);

        SqlElementType _ElementType;

        public SqlModelScript(IModelType Classification, string ScriptText, params SqlParameterName[] ParameterNames)
            : base(new SqlScriptName(Classification.ModelTypeId), Classification.ModelTypeId, ScriptText,ParameterNames)
        {
            this.ModelType = Classification;
            _ElementType = SqlElementType.Create<M>(new SqlIdentifier(typeof(M).Name, false));
        }

        public SqlModelScript(string ScriptText, IEnumerable<SqlParameterName> ParameterNames)
            : base(_ScriptName, _ScriptIdentifier, ScriptText, ParameterNames)
        {
            this.ModelType = new SqlModelType(GetType().ClrType().Require());
        }

        public IModelType ModelType { get; }

        Option<SqlElementDescription> ISqlElement.Documentation
            => none<SqlElementDescription>();

        IReadOnlyList<SqlPropertyAttachment> ISqlElement.Properties
            => rolist<SqlPropertyAttachment>();

        bool ISqlElement.IsSchemaObject
            => false;


        IName sxc.element.ElementName
            => (this as ISqlScript).ScriptName;
    }

    public sealed class SqlModelScript : SqlModel<SqlModelScript>,  ISqlModelScript , ISqlElement
    {
        public static implicit operator SqlScript(SqlModelScript src)
            => new SqlScript(new SqlScriptName(src.ScriptName), src.ScriptText);


        public SqlModelScript(ISqlModelScript src)
            : this(src.ScriptName, src.ModelType, src.ScriptText, src.ParameterNames)
                { }


        public SqlModelScript(IName ScriptName, IModelType ModelType, string ScriptText, params SqlParameterName[] ParameterNames)
        {
            this.ScriptName = ScriptName;
            this.ScriptId = new SqlIdentifier(ScriptName.ToString(),false);
            this.ScriptText = ScriptText;
            this.ParameterNames = ParameterNames.ToReadOnlyList();
            this.ModelType = ModelType;
        }

        public SqlModelScript(IName ScriptName, IModelType TargetType, string ScriptText, IEnumerable<SqlParameterName> ParameterNames)
        {
            this.ScriptName = ScriptName;
            this.ScriptId = new SqlIdentifier(ScriptName.ToString(),false);
            this.ScriptText = ScriptText;
            this.ParameterNames = ParameterNames.ToReadOnlyList();
            this.ModelType = ModelType;

        }

        public IName ScriptName { get; }

        public override IModelType ModelType { get; }

        public string ScriptId { get; }

        public string ScriptText { get; }

        public IReadOnlyList<SqlParameterName> ParameterNames { get; }

        SqlScriptName ISqlScript.ScriptName
            => new SqlScriptName(ScriptName);

        Option<SqlElementDescription> ISqlElement.Documentation
            => none<SqlElementDescription>();

        IReadOnlyList<SqlPropertyAttachment> ISqlElement.Properties
            => rolist<SqlPropertyAttachment>();

        bool ISqlElement.IsSchemaObject
            => false;

        IName sxc.element.ElementName
            => (this as ISqlScript).ScriptName;

        public override string ToString()
            => ScriptText ?? string.Empty;
    }
}
