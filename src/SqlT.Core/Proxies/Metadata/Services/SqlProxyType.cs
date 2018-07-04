using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace SqlT.Core
{
    class SqlProxyType
    {
        public static SqlProxyType Create(Type t)
            => new SqlProxyType(t);

        public static implicit operator SqlProxyType(Type t)
            => new SqlProxyType(t);

        public static implicit operator Type(SqlProxyType p)
            => p.ClrType;

        public SqlProxyType(Type ClrType)
        {
            this.ClrType = ClrType;
        }

        public Type ClrType { get; }

        public override string ToString()
            => ClrType.ToString();

        A Attribute<A>()
            where A : Attribute => ClrType.GetCustomAttribute<A>();

        static string ifBlank(string src, string replacement)
            => String.IsNullOrWhiteSpace(src) ? replacement : src;

        static bool isBlank(string src)
            => String.IsNullOrWhiteSpace(src);

        static bool isNotBlank(string src)
            => !String.IsNullOrWhiteSpace(src);

        static string ifBlank(string src, Func<string> replacer)
            => String.IsNullOrWhiteSpace(src) ? replacer() : src;

        public SqlSchemaName InferSchemaName()
        {

            Func<string> LastResort = () =>
            {
                var ns = ClrType.Namespace;
                if (isBlank(ns))
                    return "dbo";

                var components = ns.Split('.');
                if (components.Length == 0)
                    return (ns);
                else
                    return (components.Last());

            };

            var oa = Attribute<SqlObjectAttribute>();
            if (oa != null)
            {
                if (isNotBlank(oa.SchemaName))
                    return oa.SchemaName;
            }
            

            var sa = Attribute<SqlSchemaAttribute>();
            if (sa != null)
                return ifBlank(sa.Value, "dbo");

            return LastResort();
        }


      
        public SqlTableName InferTableName()
        {
            var defaultName = ClrType.Name;
            var tableAttrib = Attribute<SqlTableAttribute>();
            if(tableAttrib != null)
            {
                var tableNamePart = ifBlank(tableAttrib.ObjectName, defaultName);
                var schemaNamePart = ifBlank(tableAttrib.SchemaName, InferSchemaName());
                return new SqlTableName(schemaNamePart, tableNamePart);
            }

            return new SqlTableName(InferSchemaName(), defaultName);
            
        }


        public SqlTableTypeName InferRecordTypeName()
        {
            var defaultName = ClrType.Name;
            var tableAttrib = Attribute<SqlRecordAttribute>();
            if (tableAttrib != null)
            {
                var tableNamePart = ifBlank(tableAttrib.ObjectName, defaultName);
                var schemaNamePart = ifBlank(tableAttrib.SchemaName, InferSchemaName());
                return new SqlTableTypeName(schemaNamePart, tableNamePart);
            }

            return new SqlTableTypeName(InferSchemaName(), defaultName);
        }

        public IDictionary<int, PropertyInfo> GetPropertyIndex()
        {
            var propidx = new    Dictionary<int, PropertyInfo>();
            var idx = 0;
            foreach(var prop in ClrType.GetProperties())
            {
                if (prop.CanWrite && prop.CanWrite)
                    propidx[idx++] = prop;
            }
            return propidx;

        }
        
    }
}
