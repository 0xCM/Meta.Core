namespace SqlT.Syntax
{
    public enum statement_kind
    {
        None = 0,
        Select,
        TruncateTable,
        DeclareVariable,
        Insert,
        Update,
        Delete,
        If,
        Use,
        While,
        DeclareTableVariable,
        CreateTable,

        Set,
        SetVariable,

        RaiseError,

        AlterDatabase,
        AlterTable,
        AlterIndex,

        Merge,

        DropTable,
        DropSequence,
        DropView,
        DropIndex,

        CreateSynonym,
        CreateService,
        CreateSchema,
        CreateQueue,
        CreateMessageType,
        CreateIndex,
        CreateView,
        CreateTableType,
        CreateContract,
        CreateDatabase,
        CreateProcedure,

        BackupDatabase,
        RestoreDatabase,

        Execute
    }
}
