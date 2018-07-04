//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;

    public sealed class SqlDomCollectionValue : SqlDomElementValue<SqlDomCollectionValue, SqlDomCollection>
    {

        public SqlDomCollectionValue(SqlDomCollection Member, object ItemSource, IEnumerable<object> Items, SqlDomElementValue ParentElement = null)
            : base(Member, ItemSource, ParentElement)
        {
            this.Items = rolist(Items);
        }


        public IEnumerable ItemSource
            => SourceValue as IEnumerable;
        
        public IReadOnlyList<object> Items { get; }

        public ClrType ItemType
            => Member.ItemType;
        
        public SqlDomCollectionValue WithItems(IEnumerable<object> Items)
            => new SqlDomCollectionValue(Member, ItemSource, Items, ParentElement.ValueOrDefault());

        public override string ToString()
            => $"{Member.MemberName}: seq<{ItemType}>{{...}}";
    }




}