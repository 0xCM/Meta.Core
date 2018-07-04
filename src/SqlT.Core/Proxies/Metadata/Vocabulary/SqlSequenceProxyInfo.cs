//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    public class SqlSequenceProxyInfo : SqlObjectProxyInfo
    {
        public SqlSequenceProxyInfo(object ClrElement, SqlSequenceName ObjectName)
            : base(SqlProxyKind.Sequence, ClrElement, ObjectName)
        {
            this.ObjectName = ObjectName;
        }

        public override Type RuntimeType 
            => ClrElement as Type;

        public new SqlSequenceName ObjectName { get; }

    }
}