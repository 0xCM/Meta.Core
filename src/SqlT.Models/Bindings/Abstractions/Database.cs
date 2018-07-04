//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Bindings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;

    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;
    using static metacore;

    using static SqlT.Syntax.SqlSyntax;

    public abstract class Database<M> : SqlElement<M, SqlDatabaseName>, ISqlDatabaseBinding<M>
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

        public virtual IEnumerable<SqlTableType> TableTypes
            => stream<SqlTableType>();

        public virtual IEnumerable<SqlMessageType> MessageTypes
            => stream<SqlMessageType>();

        public virtual IEnumerable<SqlQueue> Queues
            => stream<SqlQueue>();

        public virtual IEnumerable<SqlFileGroup> DataFileGroups
            => stream<SqlFileGroup>();

        public virtual IEnumerable<SqlFileGroup> LogFileGroups
            => stream<SqlFileGroup>();

        public virtual IEnumerable<SqlSchema> Schemas
            => stream<SqlSchema>();

        public virtual IEnumerable<SqlTable> Tables
            => stream<SqlTable>();

        public virtual SqlVersion SqlVersion
            => SqlVersions.Latest;

        public virtual SemanticVersion DbVersion
            => "1.0.0";
       
        public IEnumerable<ISqlObject> Objects
            => union<ISqlObject>(Tables, TableTypes, Queues);

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