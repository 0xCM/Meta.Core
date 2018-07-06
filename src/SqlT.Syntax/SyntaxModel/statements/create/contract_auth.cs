//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Models;

    partial class SqlSyntax
    {
        public sealed class contract_auth : Model<contract_auth>
        {
            public contract_auth(owner_name owner_name)
            {
                this.owner_name = owner_name;
            }

            public owner_name owner_name {get;}

            public override string ToString()
                => owner_name.ToString();            
        }
    }
}