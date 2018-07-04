//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using SqlT.Core;
    using SqlT.Syntax;
    using sxc = Syntax.contracts;
    using static metacore;


    public abstract class SqlObject<M> : SqlElement<M>, ISqlObject
        where M : SqlObject<M>
    {
        protected static readonly M instance;

        public static M get()
            => instance;

        static SqlObject()
        {
            try
            {

                instance =
                    (from ctor in typeof(M).TryGetDefaultPrivateConstructor()
                     let v = (M)ctor.Invoke(array<object>())
                     select v).ValueOrDefault();
            }
            catch(Exception e)
            {
                SystemConsole.Get().Write(error($"Trapped an exception in SqlObject static constructor: {e}"));
            }
        }


        protected SqlObject
        (
            sxc.ISqlObjectName ObjectName, 
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null,
            bool IsIntrinsic = false
        ) : base
            (
                  ObjectName,
                  Documentation : Documentation, 
                  Properties : Properties 
                  
            )
        {
            this.ObjectName = ObjectName;
        }

        public sxc.ISqlObjectName ObjectName { get; }

        public SqlSchemaName SchemaName
            => ObjectName.SchemaNamePart;

        public string LocalName 
            => ObjectName.UnqualifiedName;

        public override string ToString() 
            => this.ObjectName.ToString();

        public override bool IsSchemaObject
            => true;

    }

    public abstract class SqlObject<M, N> : SqlObject<M>, sxc.sql_object<N>
        where M : SqlObject<M,N>
        where N : SqlObjectName<N>, new()
    {
        protected SqlObject
        (
            N Name,
            SqlElementDescription Documentation = null,
            IEnumerable<SqlPropertyAttachment> Properties = null
            
        ) : base
            (
                ObjectName: Name,
                Documentation: Documentation,
                Properties: Properties
            )
        {
            this.Name = Name;
        }


        public N Name { get; }

        N IModel<N>.Name
            => Name;
    }
}
