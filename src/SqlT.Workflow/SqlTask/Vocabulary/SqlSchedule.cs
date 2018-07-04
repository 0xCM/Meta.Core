//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;

    using SqlT.Core;
    using SqlT.Models;

    using SPT = SqlScheduleClassifiers;

    /// <summary>
    /// Logical representation of a SQL Server schedule
    /// </summary>
    /// <remarks>
    /// See https://docs.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-add-schedule-transact-sql
    /// </remarks>
    public class SqlSchedule : SqlElement<SqlSchedule,SqlScheduleName>
    {
        public SqlSchedule(SqlScheduleName Name)
            : base(Name)
        {
            this.ScheduleName = Name;
        }

        [SqlParameter("@schedule_name", 1)]
        public SqlScheduleName ScheduleName { get; }

        [SqlParameter("@enabled",2)]
        public bool? Enabled { get; set; }

        [SqlParameter("@freq_type", 3)]
        public SPT.FrequencyType? FrequencyType { get; set; }

        [SqlParameter("@freq_interval", 4)]
        public SPT.FrequencyTypeInterval? FrequencyInterval { get; set; }

        [SqlParameter("@freq_subday_type", 5)]
        public SPT.SubDayFrequencyKind? SubDayFrequencyType { get; set; }

        [SqlParameter("@freq_subday_interval", 6)]
        public int? SubdayFrequencyInterval { get; set; }

        [SqlParameter("@freq_relative_interval", 7)]
        SPT.RelativeFrequency? FrequencyRelativeInterval { get; set; }

        [SqlParameter("@freq_recurrence_factor", 8)]
        public int? FrequenceyRecurrenceFactor { get; set; }

        [SqlParameter("@active_start_date", 9)]
        public Date? ActiveStartDate { get; set; }

        [SqlParameter("@active_end_date", 10)]
        public Date? ActiveEndDate { get; set; }

        [SqlParameter("@active_start_time", 11)]
        public TimeOfDay? ActiveStartTime { get; set; }

        [SqlParameter("@active_end_time", 12)]
        public TimeOfDay? ActiveEndTime { get; set; }

        [SqlParameter("@schedule_uid", 13, true)]
        public Guid? ScheduleUid { get; set; }

        [SqlParameter("@schedule_id", 14, true)]
        public int? ScheduleId { get; set; }

    }
}