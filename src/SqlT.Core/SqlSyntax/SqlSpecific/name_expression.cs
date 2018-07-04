//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.Collections.Generic;

    using sxc = contracts;

    using SqlT.Core;
    using System;

    using Meta.Syntax;
    using Meta.Models;

    public class name_expression : Model<name_expression>, INameExpression
    {
        public name_expression(IName name)
        {
            this.ExpressedName = name;
        }
                
        public IName ExpressedName { get; }

        public override string ToString()
            => ExpressedName.ToString();
    }

    public sealed class name_expression<n> : name_expression ,  INameExpression<n>
        where n : IName, new()
    {
        public static implicit operator name_expression<n>(n Name)
            => new name_expression<n>(Name);


        public name_expression(n Name)
            : base(Name)
        {
            this.ExpressedName = Name;
        }

        public new n ExpressedName { get; }


        IName INameExpression.ExpressedName
            => ExpressedName;

        public override string ToString()
            => ExpressedName.ToString();
    }



}