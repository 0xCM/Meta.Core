//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Models;

    using static metacore;
    using kwt = SqlKeywordTypes;
    using sxc = contracts;
    using sx = SqlSyntax;

    partial class SqlSyntax 
    {
        public sealed class augmentation<m> : sxc.augmentation
            where m : IModel
        {

            public static implicit operator m(augmentation<m> augmentation)
                => augmentation.subject;

            public augmentation(m subject, xprop_value_list properties)
            {
                this.properties = properties;
                this.subject = subject;
            }

            public m subject { get; }

            public xprop_value_list properties { get; }

            IModelType IModel.ModelType
                => subject.ModelType;


            IModel sxc.augmentation.subject
                => subject;

            IEnumerable<IModel> sxc.augmentation.additions
                => properties;

            public override string ToString()
                => subject.ToString();
        }

        public static augmentation<m> augment<m>(this m model, params xprop_value[] properties)
            where m : IModel => new augmentation<m>(model, properties);

    }

}