////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum BackupOptionKind : int
    {
        None = 0,
        NoRecovery = 1,
        TruncateOnly = 2,
        NoLog = 3,
        NoTruncate = 4,
        Unload = 5,
        NoUnload = 6,
        Rewind = 7,
        NoRewind = 8,
        Format = 9,
        NoFormat = 10,
        Init = 11,
        NoInit = 12,
        Skip = 13,
        NoSkip = 14,
        Restart = 15,
        Stats = 16,
        Differential = 17,
        Snapshot = 18,
        Checksum = 19,
        NoChecksum = 20,
        ContinueAfterError = 21,
        StopOnError = 22,
        CopyOnly = 23,
        Standby = 24,
        ExpireDate = 25,
        RetainDays = 26,
        Name = 27,
        Description = 28,
        Password = 29,
        MediaName = 30,
        MediaDescription = 31,
        MediaPassword = 32,
        BlockSize = 33,
        BufferCount = 34,
        MaxTransferSize = 35,
        EnhancedIntegrity = 36,
        Compression = 37,
        NoCompression = 38,
        Encryption = 39
    }
}