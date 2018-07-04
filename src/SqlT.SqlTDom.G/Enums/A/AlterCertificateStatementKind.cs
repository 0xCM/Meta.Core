////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum AlterCertificateStatementKind : int
    {
        None = 0,
        RemovePrivateKey = 1,
        RemoveAttestedOption = 2,
        WithPrivateKey = 3,
        WithActiveForBeginDialog = 4,
        AttestedBy = 5
    }
}