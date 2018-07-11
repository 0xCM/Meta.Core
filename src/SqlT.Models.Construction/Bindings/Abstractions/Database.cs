//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings
{
    using System;
    using System.Linq;

    using Meta.Core;
    using Meta.Models;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;
    using static SqlT.Syntax.SqlSyntax;

    using sxc = SqlT.Syntax.contracts;

    public abstract class Database<M> : SqlElement<M, SqlDatabaseName>
        where M : Database<M>
    {       
        protected Database(SqlDatabaseName DatabaseName = null)
            : base(DatabaseName ?? typeof(M).Name)
        {
            
        }

        public virtual ModelOption<containment_type> containment_type { get; }
            = containment_types.PARTIAL;

        public virtual ModelOption<service_broker_option> service_broker_option { get; }
            = service_broker_options.DISABLE_BROKER;

        public virtual ModelOption<parameter_sniffing> parameter_sniffing { get; }
            = parameter_sniffings.OFF;

        public ModelOption<recovery_model> recovery_model { get; }
            = recovery_models.SIMPLE;

        public virtual Seq<SqlTableType> TableTypes
            => seq<SqlTableType>();

        public virtual Seq<SqlMessageType> MessageTypes
            => seq<SqlMessageType>();

        public virtual Seq<SqlQueue> Queues
            => seq<SqlQueue>();

        public virtual Seq<SqlFileGroup> DataFileGroups
            => seq<SqlFileGroup>();

        public virtual Seq<SqlFileGroup> LogFileGroups
            => seq<SqlFileGroup>();

        public virtual Seq<SqlSchema> Schemas
            => seq<SqlSchema>();

        public virtual Seq<SqlTable> Tables
            => seq<SqlTable>();

        public virtual SqlVersion SqlVersion
            => SqlVersions.Latest;

        public virtual SemanticVersion DbVersion
            => "1.0.0";
       
        public Seq<sxc.sql_object> Objects
            => Seq.union(
                Tables.Cast<sxc.sql_object>(),
                TableTypes.Cast<sxc.sql_object>(), 
                Queues.Cast<sxc.sql_object>()
                );

        public dboptions DatabaseOptions
            => new dboptions(containment_type: containment_type.value,
                service_broker_option: service_broker_option.value,
                recovery_model: recovery_model.value,
                parameter_sniffing: parameter_sniffing.value
                );

        public SqlDatabase Define()
        {
            return new SqlDatabase
                (
                    Name, 
                    DatabaseOptions,
                    DataFileGroups: DataFileGroups,
                    LogFileGroups: LogFileGroups,
                    Schemas: Schemas,
                    Objects: Objects,
                    Properties: Properties,
                    Documentation : Documentation.ValueOrDefault(SqlElementDescription.Empty)                                
                );
        }

        public override string ToString()
            => Name.ToString();
    }
}