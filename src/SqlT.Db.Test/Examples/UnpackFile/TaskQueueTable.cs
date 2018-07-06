//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace WF
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Syntax;
    using sxf = SqlT.Syntax.SqlTypes;
    using static SqlT.Bindings.TypeStructures;
    using static SqlT.Syntax.SqlNativeTypeRefs;

    using SqlT.Models;


    using static metacore;

    public abstract class TaskQueueTable<T> : Table<T>
       where T : TaskQueueTable<T>, new()
        
    {
        public BIGINT TaskId { get; }
            = sxf.bigint(false);

        public DATETIME2 SubmittedTS { get; }
            = sxf.datetime2(0, false);

        public BIT Dispatched { get; }
            = sxf.bit(false);

        public DATETIME2 DispatchTS { get; }
            = sxf.datetime2(0, true);

        public BIT Completed { get; }
            = sxf.bit(false);

        public DATETIME2 CompleteTS { get; }
            = sxf.datetime2(0, true);

        public BIT Succeeded { get; }
            = sxf.bit(false);

        public NVARCHAR ResultDescription { get; }
            = sxf.nvarchar(250, false);

        public NVARCHAR CorrelationToken { get; }
            = sxf.nvarchar(250, true);

        public DATETIME2 CreateTS { get; }
            = sxf.datetime2(0, false);

        public DATETIME2 UpdateTS { get; }
            = sxf.datetime2(0, true);

        protected abstract SqlSequenceName TaskSequence { get; }

        protected override IEnumerable<ClrProperty> PrimaryKeyColumns
            => Properties(x => TaskId);

        public override IEnumerable<SqlDefaultConstraint> DefaultConstraints
            => stream(
                DefaultSequenceConstraint(x => x.TaskId, TaskSequence),
                DefaultTimestampContraint(c => c.SubmittedTS),
                DefaultTimestampContraint(c => c.CreateTS),
                DefaultLiteralConstraint(c => c.Dispatched, false),
                DefaultLiteralConstraint(c => c.Completed, false),
                DefaultLiteralConstraint(c => c.Succeeded, false)
                );

    }



}