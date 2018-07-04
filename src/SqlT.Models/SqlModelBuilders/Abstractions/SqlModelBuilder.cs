//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using SqlT.Core;
    using SqlT.Models;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Core;
    using Meta.Models;

    public abstract class SqlModelBuilder<M> : ISqlModelBuilder<M>
        where M : IModel
    {        

        public static implicit operator M(SqlModelBuilder<M> x)
            => x.Complete();

        public abstract M Complete();

        IModel ISqlModelBuilder.Complete()
            => Complete();
    }

    public abstract class SqlModelBuilder<B, M> : SqlModelBuilder<M>
        where B : SqlModelBuilder<B, M>
        where M : SqlModel<M>
    {

        protected Builder<B> Step(Action a)
        {
            a.Invoke();
            return (B)this;
        }

        protected MutableList<SqlPropertyAttachment> Properties
            = MutableList.Create<SqlPropertyAttachment>();

        protected SqlElementDescription Description { get; set; }

        public Builder<B> WithDescription(SqlElementDescription Description)
        {
            this.Description = Description;
            return (B)this;
        }

        public Builder<B> WithProperties(params SqlPropertyAttachment[] Properties)
        {
            this.Properties.AddRange(this.Properties);
            return (B)this;
        }

    }

    public static class ModelBuilderExtensions
    {
        public static M complete<B, M>(Builder<B> b)
            where B : SqlModelBuilder<M>
            where M : IModel
                => (B)b;


    }

}
