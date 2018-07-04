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

    public abstract class SqlElement<M> : SqlModel<M>, ISqlElement
        where M : SqlElement<M>
    {
                  
        protected SqlElement(IName ElementName,SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null) 
        {
            this.ElementName = ElementName;
            if (Documentation != null && isNotBlank(Documentation.Text))
                this.Documentation = Documentation;
            else
                this.Documentation = none<SqlElementDescription>();
            this.Properties = rolist(Properties ?? rolist<SqlPropertyAttachment>());

        }

        public IName ElementName { get; }

        public virtual Option<SqlElementDescription> Documentation { get; }

        public virtual IReadOnlyList<SqlPropertyAttachment> Properties { get; }

        public Option<SqlPropertyAttachment> GetProperty(string propertyName)
            => Properties.FirstOrDefault(x => x.PropertyName == propertyName);

        public bool HasProperty(string propertyName)
            => Properties.Exists(x => x.PropertyName == propertyName);

        public bool HasPropertyValue(string propertyName, string propertyValue)
        {
            var property = GetProperty(propertyName);
            return property ? (~property).PropertyValue.ToString() == propertyValue : false;            
        }

        public virtual bool IsSchemaObject
            => false;

        IName sxc.element.ElementName
            => ElementName;

        public override string ToString()
            => toString(ElementName);
    }

    public sealed class SqlElement : SqlElement<SqlElement>
    {
        public SqlElement(ISqlElement E)
            : base(E.ElementName, E.Documentation.ValueOrDefault(), E.Properties)
        {

        }
    }

    public abstract class SqlElement<M, N> : SqlElement<M>, ISqlElement<N>
        where M : SqlElement<M, N>
        where N : SqlName<N>, new()

    {
        protected SqlElement
        (
            N Name,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            bool IsIntrinsic = false
        )
            : base(Name, Documentation, Properties)
        {
            this.Name = Name;
        
        }

        public N Name { get; }        

    }

    public abstract class SqlElement<M, N, X, Y> : SqlElement<M, N>
            where M : SqlElement<M, N, X, Y>
            where N : SqlName<N>, new()
    {
        protected SqlElement
        (
            N Name,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            bool IsIntrinsic = false
        ) : base(Name, Documentation, Properties, IsIntrinsic)
        {

        }
    }
}
