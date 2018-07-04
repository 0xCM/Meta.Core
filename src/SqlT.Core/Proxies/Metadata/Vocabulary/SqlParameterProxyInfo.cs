//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Reflection;

    public class SqlParameterProxyInfo : SqlProxyInfo
    {
        public SqlParameterProxyInfo(
            object ClrElement, 
            SqlParameterName ParameterName, 
            int Position, 
            bool IsStructured, 
            bool IsOutput,
            SqlParameterDocumentation Documentation = null
            )
            : base(SqlProxyKind.Parameter, ClrElement, Documentation)
        {
            this.ParameterName = ParameterName;
            this.Position = Position;
            this.IsStructured = IsStructured;
        }

        public SqlParameterName ParameterName { get; }

        public int Position { get; }

        public bool IsStructured { get; }

        public bool IsOutput { get; }

        public override Type RuntimeType 
            => (ClrElement as PropertyInfo)?.PropertyType
            ?? (ClrElement as ParameterInfo)?.ParameterType
            ?? (ClrElement as FieldInfo)?.FieldType;
    }

}