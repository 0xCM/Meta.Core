//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Services;
    using SqlT.Models;
    using SqlT.Types;

    using static metacore;



    public sealed class SqlSmallTypeTableAdapter : SqlTypeTableAdapter<short>
    {
        public SqlSmallTypeTableAdapter(ISqlTableProxy Subject)
            : base(Subject) { }

    }


}