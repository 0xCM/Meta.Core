////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum SimpleAlterFullTextIndexActionKind : int
    {
        None = 0,
        Enable = 1,
        Disable = 2,
        SetChangeTrackingManual = 3,
        SetChangeTrackingAuto = 4,
        SetChangeTrackingOff = 5,
        StartFullPopulation = 6,
        StartIncrementalPopulation = 7,
        StartUpdatePopulation = 8,
        StopPopulation = 9,
        PausePopulation = 10,
        ResumePopulation = 11
    }
}