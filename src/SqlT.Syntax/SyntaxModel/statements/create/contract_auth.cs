//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;

    using Meta.Models;
    using SqlT.Core;

    using static metacore;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;

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