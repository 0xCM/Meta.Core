////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum TableHintKind : int
    {
        None = 0,
        FastFirstRow = 1,
        HoldLock = 2,
        NoLock = 3,
        PagLock = 4,
        ReadCommitted = 5,
        ReadPast = 6,
        ReadUncommitted = 7,
        RepeatableRead = 8,
        Rowlock = 9,
        Serializable = 10,
        TabLock = 11,
        TabLockX = 12,
        UpdLock = 13,
        XLock = 14,
        NoExpand = 15,
        NoWait = 16,
        ReadCommittedLock = 17,
        KeepIdentity = 18,
        KeepDefaults = 19,
        IgnoreConstraints = 20,
        IgnoreTriggers = 21,
        ForceSeek = 22,
        Index = 23,
        SpatialWindowMaxCells = 24,
        ForceScan = 25,
        Snapshot = 26
    }
}