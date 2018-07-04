////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum ResourcePoolParameterType : int
    {
        Unknown = 0,
        MaxCpuPercent = 1,
        MaxMemoryPercent = 2,
        MinCpuPercent = 3,
        MinMemoryPercent = 4,
        CapCpuPercent = 5,
        TargetMemoryPercent = 6,
        MinIoPercent = 7,
        MaxIoPercent = 8,
        CapIoPercent = 9,
        Affinity = 10,
        MinIopsPerVolume = 11,
        MaxIopsPerVolume = 12
    }
}