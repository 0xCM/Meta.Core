////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum CommandOptions : int
    {
        None = 0,
        CreateDatabase = 1,
        CreateDefault = 2,
        CreateProcedure = 4,
        CreateFunction = 8,
        CreateRule = 16,
        CreateTable = 32,
        CreateView = 64,
        BackupDatabase = 128,
        BackupLog = 256
    }
}