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

    public class SqlScheduleClassifiers
    {

        [Flags]
        public enum WeekdayIntervalKind : byte
        {
            None = 0,

            Sunday = 1,

            Monday = 2,

            Tuesday = 4,

            Wednesday = 8,

            Thursday = 16,

            Friday = 32,

            Saturday = 64
        }

        public enum MonthlyRelativeKind : byte
        {
            None = 0,

            Sunday = 1,

            Monday = 2,

            Tuesday = 3,

            Wednesday = 4,

            Thursday = 5,

            Friday = 6,

            Staturday = 7,

            Day = 8,

            Weekday = 9,

            WeekendDay = 10


        }


        public enum SubDayFrequencyKind : byte
        {
            None = 0,

            AsSpecified = 1,

            Seconds = 2,

            Minutes = 4,

            Hours = 8

        }

        public enum RelativeFrequency : byte
        {
            None = 0,
            First = 1,
            Second = 2,
            Third = 4,
            Fourth = 8,
            Last = 16
        }


        public enum FrequencyType : byte
        {
            None = 0,

            [Description("Job is to be executed once")]
            Once = 1,

            [Description("Job is to be executed once per day")]
            Daily = 4,

            [Description("Job is to be executed once per week")]
            Weekly = 8,

            [Description("Job is to be executed once per month")]
            Monthly = 16,

            [Description("Job is to be executed monthly, relative to frequency interval")]
            MonthlyRelative = 32,

            [Description("Job is to be executed when Sql Agent starts")]
            AgentStart = 64,

            [Description("Job is to be executed when server is idle")]
            Idle = 128
        }

        [Description("In conjunction with FrequencyType, determines the days on which a job is executed")]
        public enum FrequencyTypeInterval : byte
        {
            None = 0,

            Once = 1,

            Daily = 4,

            Weekly = 8,

            Monthly = 16,

            MonthlyRelative = 32,

            AgentStart = 64,


            Idle = 128,

        }

    }



}