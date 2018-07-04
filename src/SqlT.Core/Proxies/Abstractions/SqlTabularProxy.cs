//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using static metacore;

    public abstract class SqlTabularProxy : SqlObjectProxy, ISqlTabularProxy
    {

    }

    public abstract class SqlTabularProxy<T> : SqlObjectProxy<T>, ISqlTabularProxy<T>
        where T : SqlTabularProxy<T>, new()
    {

        public static IReadOnlyList<SqlColumnProxyInfo> Columns { get; }
            = rolist(PXM.Columns<T>());

        static PropertyInfo ColumnProperty(int position)
            => Columns[position].ClrElement as PropertyInfo;

        public override object[] GetItemArray()
            => array(Columns.Select(p => (p.ClrElement as PropertyInfo).GetValue(this)));

        public override void SetItemArray(object[] items)
            => iteri(Columns,
                    (i, c) => ColumnProperty(i).SetValue(this, items[i]));

    }


}