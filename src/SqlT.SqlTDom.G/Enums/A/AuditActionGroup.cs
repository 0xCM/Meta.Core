////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum AuditActionGroup : int
    {
        None = 0,
        SuccessfulLogin = 1,
        Logout = 2,
        ServerStateChange = 3,
        FailedLogin = 4,
        LoginChangePassword = 5,
        ServerRoleMemberChange = 6,
        ServerPrincipalImpersonation = 7,
        ServerObjectOwnershipChange = 8,
        DatabaseMirroringLogin = 9,
        BrokerLogin = 10,
        ServerPermissionChange = 11,
        ServerObjectPermissionChange = 12,
        ServerOperation = 13,
        TraceChange = 14,
        ServerObjectChange = 15,
        ServerPrincipalChange = 16,
        DatabasePermissionChange = 17,
        SchemaObjectPermissionChange = 18,
        DatabaseRoleMemberChange = 19,
        ApplicationRoleChangePassword = 20,
        SchemaObjectAccess = 21,
        BackupRestore = 22,
        Dbcc = 23,
        AuditChange = 24,
        DatabaseChange = 25,
        DatabaseObjectChange = 26,
        DatabasePrincipalChange = 27,
        SchemaObjectChange = 28,
        DatabasePrincipalImpersonation = 29,
        DatabaseObjectOwnershipChange = 30,
        DatabaseOwnershipChange = 31,
        SchemaObjectOwnershipChange = 32,
        DatabaseObjectPermissionChange = 33,
        DatabaseOperation = 34,
        DatabaseObjectAccess = 35,
        SuccessfulDatabaseAuthenticationGroup = 36,
        FailedDatabaseAuthenticationGroup = 37,
        DatabaseLogoutGroup = 38,
        UserChangePasswordGroup = 39,
        UserDefinedAuditGroup = 40,
        TransactionBegin = 41,
        TransactionCommit = 42,
        TransactionRollback = 43,
        StatementRollback = 44,
        TransactionGroup = 45
    }
}