//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Core;

    public class vServiceMessageType : vSystemElement, IServiceMessageType
    {
        public vServiceMessageType(
            string name, 
            int message_type_id,
            int? principal_id,
            string validation, 
            string validation_desc,
            int? xml_collection_id,
            bool is_user_defined
            ) : base(name, is_user_defined)
        {
            this.message_type_id = message_type_id;
       
            this.principal_id = principal_id;
            this.validation = validation;
            this.validation_desc = validation_desc;
            this.xml_collection_id = xml_collection_id;
            this.is_user_defined = is_user_defined;
        }

        bool is_user_defined { get; }

        int message_type_id { get; }

        int? principal_id { get; }

        string validation { get; }

        string validation_desc { get; }

        int? xml_collection_id { get; }

        public SqlMessageTypeName MessageTypeName
            => new SqlMessageTypeName(Name);

        #region IServiceMessageType
        int IServiceMessageType.message_type_id
            => message_type_id;

        int? IServiceMessageType.principal_id
            => principal_id;

        string IServiceMessageType.validation
            => validation;

        string IServiceMessageType.validation_desc
            => validation_desc;

        int? IServiceMessageType.xml_collection_id
            => xml_collection_id;

        bool IServiceMessageType.is_user_defined
            => is_user_defined;

        #endregion
    }

}