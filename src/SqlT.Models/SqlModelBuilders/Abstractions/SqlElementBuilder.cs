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

    using Meta.Core;
    using Meta.Models;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;

    using static metacore;

    public abstract class SqlElementBuilder<M,B> : SqlModelBuilder<M>, ISqlElementBuilder<M>
        where M : SqlElement<M>
        where B : SqlElementBuilder<M,B>
    {
        protected Builder<B> Step(Action a)
        {
            a.Invoke();
            return (B)this;
        }


        protected Option<SqlElementDescription> documentation;
        protected MutableList<SqlPropertyAttachment> properties = MutableList.Create<SqlPropertyAttachment>();

        public B WithDocumentation(SqlElementDescription documentation)
        {
            this.documentation = documentation;
            return (B)this;
        }

        public B WithProperties(params SqlPropertyAttachment[] properties)
        {
            this.properties.AddRange(properties);

            return (B)this;
        }

        ISqlElementBuilder ISqlElementBuilder.WithDocumentation(SqlElementDescription documentation)
            => WithDocumentation(documentation);

        ISqlElementBuilder<M> ISqlElementBuilder<M>.WithDocumentation(SqlElementDescription documentation)
            => WithDocumentation(documentation);
    }
}
