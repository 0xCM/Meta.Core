//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
        

    using static metacore;

    public class all_procedures : IProcedure
    {
        public all_procedures(ISystemObject o)
        {
            this.create_date = o.create_date;
            this.modify_date = o.modify_date;
            this.name = o.name;
            this.object_id = o.object_id;
            this.parent_object_id = o.parent_object_id;
            this.principal_id = o.principal_id;
            this.schema_id = o.schema_id;
            this.type = o.type;
            this.type_desc = o.type_desc;
            this.is_ms_shipped = o.is_ms_shipped;

        }

        public string name { get; set; }

        public int object_id { get; set; }

        public int? principal_id { get; set; }

        public int schema_id { get; set; }

        public int parent_object_id { get; set; }

        public string type { get; set; }

        public string type_desc { get; set; }

        public DateTime create_date { get; set; }

        public DateTime modify_date { get; set; }

        public bool is_ms_shipped { get; set; }

        public bool is_published { get; set; }

        public bool is_schema_published { get; set; }

        public bool is_auto_executed { get; set; }

        public bool? is_execution_replicated { get; set; }

        public bool? is_repl_serializable_only { get; set; }

        public bool? skips_repl_constraints { get; set; }

        public bool is_user_defined => not(is_ms_shipped);

    }
}
