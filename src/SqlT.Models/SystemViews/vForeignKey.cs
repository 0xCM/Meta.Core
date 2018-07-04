//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System.Collections.Generic;

    using static metacore;

    using SqlT.Core;
    using System;
    using sxc = SqlT.Syntax.contracts;



    public class vForeignKey : vObject, IForeignKey
    {

        public vForeignKey
            (
                ISchema schema,
                IForeignKey fk,
                ISchema sClient,
                ITable tClient,
                ISchema sSupplier,
                ITable tSupplier,
                IReadOnlyList<vForeignKeyColumn> columns,
                IEnumerable<IExtendedProperty> properties
            )
            : base(schema, fk, properties)
        {
            this.Subject = fk;
        }

        public IReadOnlyList<vForeignKeyColumn> KeyColumns { get; }

        ISchema ClientSchema { get; }

        ISchema SupplierSchema { get; }

        ITable ClientTable { get; }

        ITable SupplierTable { get; }

        IForeignKey Subject { get; }

        public override sxc.ISqlObjectName ObjectName
            => new SqlForeignKeyName(ClientSchema.name, Subject.name);

        bool IForeignKey.is_schema_published
            => Subject.is_schema_published;

        int? IForeignKey.referenced_object_id
            => Subject.referenced_object_id;

        int? IForeignKey.key_index_id
            => Subject.key_index_id;

        bool IForeignKey.is_disabled
            => Subject.is_disabled;

        bool IForeignKey.is_not_for_replication
            => Subject.is_not_for_replication;

        bool IForeignKey.is_not_trusted
            => Subject.is_not_trusted;

        byte? IForeignKey.delete_referential_action
            => Subject.delete_referential_action;

        string IForeignKey.delete_referential_action_desc
            => Subject.delete_referential_action_desc;

        byte? IForeignKey.update_referential_action
            => Subject.update_referential_action;

        string IForeignKey.update_referential_action_desc
            => Subject.update_referential_action_desc;

        bool IForeignKey.is_system_named
            => Subject.is_system_named;
    }


}