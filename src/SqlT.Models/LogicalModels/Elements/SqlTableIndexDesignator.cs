//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;



    public sealed class SqlTableIndexDesignator
    {
        public SqlTableIndexDesignator(SqlTableName ParentTableName, SqlIndexName IndexName)
        {
            this.ParentTableName = ParentTableName;
            this.IndexName = IndexName;
        }

        public SqlTableName ParentTableName { get; }

        public SqlIndexName IndexName { get; }


        public override int GetHashCode()
            => ToString().GetHashCode();

        public override bool Equals(object obj)
            => string.Compare(toString(obj), this.ToString(), true) == 0;

        public override string ToString()
            => concat(ParentTableName.Format(true), 
                    bracket(IndexName.UnquotedLocalName));


    }



}