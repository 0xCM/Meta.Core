////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum SetOptions : int
    {
        None = 0,
        QuotedIdentifier = 1,
        ConcatNullYieldsNull = 2,
        CursorCloseOnCommit = 4,
        ArithAbort = 8,
        ArithIgnore = 16,
        FmtOnly = 32,
        NoCount = 64,
        NoExec = 128,
        NumericRoundAbort = 256,
        ParseOnly = 512,
        AnsiDefaults = 1024,
        AnsiNullDfltOff = 2048,
        AnsiNullDfltOn = 4096,
        AnsiNulls = 8192,
        AnsiPadding = 16384,
        AnsiWarnings = 32768,
        ForcePlan = 65536,
        ShowPlanAll = 131072,
        ShowPlanText = 262144,
        ImplicitTransactions = 524288,
        RemoteProcTransactions = 1048576,
        XactAbort = 2097152,
        DisableDefCnstChk = 4194304,
        ShowPlanXml = 8388608,
        NoBrowsetable = 16777216
    }
}