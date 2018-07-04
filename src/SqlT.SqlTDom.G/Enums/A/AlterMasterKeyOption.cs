////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum AlterMasterKeyOption : int
    {
        None = 0,
        Regenerate = 1,
        ForceRegenerate = 2,
        AddEncryptionByServiceMasterKey = 3,
        AddEncryptionByPassword = 4,
        DropEncryptionByServiceMasterKey = 5,
        DropEncryptionByPassword = 6
    }
}