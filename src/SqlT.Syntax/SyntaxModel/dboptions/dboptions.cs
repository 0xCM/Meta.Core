//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Linq;

    using Meta.Models;
    using SqlT.Core;

    using static metacore;

    partial class SqlSyntax
    {
        /// <summary>
        /// Defines a (limited) database opption syntax model
        /// </summary>
        public sealed class dboptions
        {
            public dboptions(containment_type containment_type = null, 
                service_broker_option service_broker_option = null, 
                recovery_model recovery_model = null,
                parameter_sniffing parameter_sniffing = null
                )
            {
                this.containment_type = containment_type;
                this.recovery_model = recovery_model;
                this.service_broker_option = service_broker_option;
                this.parameter_sniffing = parameter_sniffing;
            }

            /// <summary>
            /// If specified, indicates the database containment level
            /// </summary>
            public ModelOption<containment_type> containment_type { get; }

            /// <summary>
            /// If specified, indicates the desired service broker disposition
            /// </summary>
            public ModelOption<service_broker_option> service_broker_option { get; }

            /// <summary>
            /// If specified, indicates the reconvery model
            /// </summary>
            public ModelOption<recovery_model> recovery_model { get; }

            /// <summary>
            /// If specified, indicates whether parameter sniffing should be enabled
            /// </summary>
            public ModelOption<parameter_sniffing> parameter_sniffing { get; }

            public override string ToString()
                => join(",", from p in GetType().GetDeclaredPublicInstanceProperties()
                        select $"{p.Name} = {p.GetValue(this)}");
        }
    }
}