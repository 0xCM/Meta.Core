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
    using sxc = Syntax.contracts;

    using static metacore;

    using SqlT.Syntax;

    /// <summary>
    /// Specifies the name of a schema-scoped object
    /// </summary>
    public class SqlObjectName : SqlName, sxc.ISqlObjectName
    {
        SqlObjectName()
        { }

        public SqlObjectName(sxc.ISqlObjectName src, bool quoted = false)
            : base(src, quoted)
        {
                   
        }

        public SqlObjectName(string ServerNamePart, string CatalogNamePart, string SchemaNamePart, string UnquotedLocalName)
            : base(ServerNamePart, CatalogNamePart, SchemaNamePart, UnquotedLocalName)
        {
        }

        public SqlObjectName(string DatabaseNamePart, string SchemaNamePart, string UnquotedLocalName)
            : base(DatabaseNamePart, SchemaNamePart, UnquotedLocalName)
        {

        }

        public SqlObjectName(string SchemaNamePart, string UnquotedLocalName)
            : base(SchemaNamePart, UnquotedLocalName)
        {

        }

        public SqlObjectName(string UnquotedLocalName)
            : base(UnquotedLocalName)
        {

        }

        /// <summary>
        /// Creates a database-qualified (and pontentially server-qualified) name for the supplied object name
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static SqlObjectName operator + (SqlDatabaseName n1, SqlObjectName n2)
            => n2.Qualify(n1);

        public static implicit operator string(SqlObjectName name)
            => name != null ? name.FullName : String.Empty;

        /// <summary>
        /// Converts a textual name representation to a <see cref="SqlObjectName"/> reference
        /// </summary>
        /// <param name="s"></param>
        public static implicit operator SqlObjectName(string s) => Parse(s);

        public new static SqlObjectName Empty
            => new SqlObjectName(String.Empty);


        public static SqlObjectName Parse(string s)
        {
            var components = Componetize(s);
            switch (components.Length)
            {
                case 0:
                    return Empty;
                case 1:
                    return new SqlObjectName(components[0]);
                case 2:
                    return new SqlObjectName(components[0], components[1]);
                case 3:
                    return new SqlObjectName(components[0], components[1], components[2]);
                case 4:
                    return new SqlObjectName(components[0], components[1], components[2], components[3]);
                default:
                    throw new ArgumentException();
            }
        }


        public string ServerNamePart
            => NameComponents.Count == 4 ? NameComponents.First() : String.Empty;

        public string DatabaseNamePart
        {
            get
            {
                var StandardPosition = 3;
                var count = NameComponents.Count;
                if (count >= StandardPosition)
                    return GetComponent(count - StandardPosition);
                else
                    return String.Empty;
            }

        }

        public string SchemaNamePart
        {
            get
            {
                var StandardPosition = 2;
                var count = NameComponents.Count;
                if (count >= StandardPosition)
                {
                    return GetComponent(count - StandardPosition);
                }
                else
                {
                    return String.Empty;
                }

            }
        }


        public SqlSchemaName SchemaName
            => ifBlank(SchemaNamePart, "dbo");

        public bool IsSystemObject
            => SchemaName.IsSystemSchema;

        public SqlObjectName Qualify(SqlDatabaseName DatabaseName)
            => new SqlObjectName(DatabaseName.ServerName, DatabaseName.UnquotedLocalName, SchemaNamePart, UnquotedLocalName);

        public SqlObjectName Qualify(SqlServerName ServerName, SqlDatabaseName DatabaseName)
            => new SqlObjectName(ServerName, DatabaseName, SchemaNamePart, UnquotedLocalName);

        public sxc.ISqlObjectName TrimServer()
            => new SqlObjectName(DatabaseNamePart, SchemaNamePart, UnquotedLocalName);

        public sxc.ISqlObjectName TrimCatalog()
            => new SqlObjectName(SchemaNamePart, UnquotedLocalName);

        public sxc.ISqlObjectName TrimSchema()
            => new SqlObjectName(UnquotedLocalName);

        public string SchemaQualifiedName
            => $"[{SchemaNamePart}].[{UnquotedLocalName}]";

        public bool IsSchemaQualified
            => NameComponents.Count >= 2;

        public bool IsDatabaseQualified
            => NameComponents.Count >= 3;

        public bool IsServerQualified
            => NameComponents.Count >= 4;


        public override sealed string ToString()
            => (IsSystemObject && not(this.IsDatabaseQualified())) ?
                UnqualifiedName : base.ToString();

    }



    public abstract class SqlObjectName<T> : SqlName<T>, sxc.ISqlObjectName 
        where T : SqlObjectName<T>, new()
    {
        
        
        
        public new static readonly T Empty
            = Construct(string.Empty);

        protected SqlObjectName()
        { }

        protected SqlObjectName(bool quoted, params string[] parts)
            : base(quoted, parts)
        { }


        protected SqlObjectName(params string[] parts)
            : base(parts)
        { }



        public SqlObjectName(ICompositeSqlName SqlName, bool quoted = true)
            : base(SqlName, quoted)
        { }

        public SqlObjectName(SqlIdentifier LocalName)
            : base(LocalName)
        { }

        public SqlObjectName(SqlIdentifier SchemaName, SqlIdentifier LocalName)
            : base(SchemaName, LocalName)
        { }

        public SqlObjectName(SqlSchemaName SchemaName, string LocalName, bool quoted = true)
            : base(quoted, SchemaName.UnquotedLocalName, LocalName)
        { }

        public SqlObjectName(SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName, bool quoted = true)
            : base(quoted, DatabaseName.UnquotedLocalName, SchemaName.UnquotedLocalName, LocalName)
        { }

        public SqlObjectName(SqlServerName ServerName, SqlDatabaseName DatabaseName, SqlSchemaName SchemaName, string LocalName, bool quoted = true)
            : base(quoted, ServerName.UnquotedLocalName, DatabaseName.UnquotedLocalName, SchemaName.UnquotedLocalName, LocalName)
        { }

        public SqlObjectName(SqlObjectName ObjectName)
            : base(ObjectName.ServerNamePart, ObjectName.DatabaseNamePart, ObjectName.SchemaNamePart, ObjectName.UnquotedLocalName)
        { }

        public SqlServerName ServerName
        {
            get
            {
                var StandardPosition = 4;
                var count = NameComponents.Count;
                if (count >= StandardPosition)
                    return GetComponent(count - StandardPosition);
                else
                    return String.Empty;
            }

        }

        public string ServerNamePart
        {
            get
            {
                var StandardPosition = 4;
                var count = NameComponents.Count;
                if (count >= StandardPosition)
                    return GetComponent(count - StandardPosition);
                else
                    return String.Empty;
            }

        }

        public string DatabaseNamePart
        {
            get
            {
                var StandardPosition = 3;
                var count = NameComponents.Count;
                if (count >= StandardPosition)
                    return GetComponent(count - StandardPosition);
                else
                    return String.Empty;
            }

        }

        public SqlDatabaseName DatabaseName
            => !String.IsNullOrWhiteSpace(ServerNamePart) 
            ? new SqlDatabaseName(ServerNamePart, DatabaseNamePart) 
            : new SqlDatabaseName(DatabaseNamePart);


        public string SchemaNamePart
        {
            get
            {
                var StandardPosition = 2;
                var count = NameComponents.Count;
                if (count >= StandardPosition)
                    return GetComponent(count - StandardPosition);
                else
                    return String.Empty;

            }
        }

        protected virtual T CreateFromParts(params string[] parts)
            => Construct(parts);

        public SqlSchemaName SchemaName
            => SchemaNamePart;

        public bool IsSystemObject
            => SchemaName.IsSystemSchema;


        public virtual T OnDatabase(SqlDatabaseName DatabaseName)
            => CreateFromParts(DatabaseName.ServerName.UnquotedLocalName, DatabaseName.UnquotedLocalName, SchemaName, UnquotedLocalName);

        public T Qualify(SqlServerName ServerName, SqlDatabaseName DatabaseName)
            => CreateFromParts(ServerName.UnquotedLocalName, DatabaseName.UnquotedLocalName, SchemaName, UnquotedLocalName);

        public T TrimServer()
            => CreateFromParts(DatabaseName.UnquotedLocalName, SchemaName, UnquotedLocalName);

        public T TrimCatalog()
            => CreateFromParts(SchemaName, UnquotedLocalName);

        public T TrimSchema()
            => CreateFromParts(UnquotedLocalName);

        public T ReplaceServer(SqlServerName ServerName)
            => CreateFromParts(ServerName.UnquotedLocalName, DatabaseNamePart, SchemaNamePart, UnquotedLocalName);

        public T ReplaceDatabase(SqlDatabaseName DatabaseName)
            => CreateFromParts(ServerNamePart, DatabaseName.UnquotedLocalName, SchemaNamePart, UnquotedLocalName);

        public T ReplaceSchema(SqlSchemaName SchemaName)
            => CreateFromParts(ServerNamePart, DatabaseNamePart, SchemaName.UnquotedLocalName, UnquotedLocalName);

        public T ReplaceLocalName(string UnquotedLocalName)
            => CreateFromParts(ServerNamePart, DatabaseNamePart, SchemaName.UnquotedLocalName, UnquotedLocalName);

        public string SchemaQualifiedName
            => SchemaName.IsEmpty() 
             ? $"[{UnquotedLocalName}]" 
             : $"[{SchemaNamePart}].[{UnquotedLocalName}]";

        public string DatabaseQualifiedName
            => DatabaseName.IsEmpty()
            ? SchemaQualifiedName
            : $"[{DatabaseNamePart}].{SchemaQualifiedName}";

        public string ServerQualifiedName
            => ServerName.IsEmpty()
            ? DatabaseQualifiedName
            : $"[{ServerNamePart}].{DatabaseQualifiedName}";

        public T WithSchema(SqlSchemaName SchemaName)
            => CreateFromParts(ServerNamePart, DatabaseNamePart, SchemaName, UnquotedLocalName);

        public T WithSystemSchema()
            => WithSchema("sys");


        public override sealed string ToString()
            => (IsSystemObject && not(this.IsDatabaseQualified())) ?
                UnqualifiedName : base.ToString();


    }



}