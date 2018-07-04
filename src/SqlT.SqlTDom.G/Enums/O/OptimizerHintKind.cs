////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum OptimizerHintKind : int
    {
        Unspecified = 0,
        HashGroup = 1,
        OrderGroup = 2,
        MergeJoin = 3,
        HashJoin = 4,
        LoopJoin = 5,
        ConcatUnion = 6,
        HashUnion = 7,
        MergeUnion = 8,
        KeepUnion = 9,
        ForceOrder = 10,
        RobustPlan = 11,
        KeepPlan = 12,
        KeepFixedPlan = 13,
        ExpandViews = 14,
        AlterColumnPlan = 15,
        ShrinkDBPlan = 16,
        BypassOptimizerQueue = 17,
        UsePlan = 18,
        ParameterizationSimple = 19,
        ParameterizationForced = 20,
        OptimizeCorrelatedUnionAll = 21,
        Recompile = 22,
        Fast = 23,
        CheckConstraintsPlan = 24,
        MaxRecursion = 25,
        MaxDop = 26,
        QueryTraceOn = 27,
        CardinalityTunerLimit = 28,
        TableHints = 29,
        OptimizeFor = 30,
        IgnoreNonClusteredColumnStoreIndex = 31,
        MaxGrantPercent = 32,
        MinGrantPercent = 33,
        NoPerformanceSpool = 34
    }
}