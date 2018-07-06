CREATE TABLE [CommandExec].[CommandHistory]
(
	SubmissionId bigint not null,
	CommandName nvarchar(250) not null,
	CommandSpecName nvarchar(500) not null,	
	CommandJson nvarchar(max) not null
		constraint CK_CommandHistory_CommandJson check(isjson(CommandJson)>0),    
	CorrelationToken nvarchar(50) null,
    EnqueuedTime datetime2(3) not null,
	DispatchTime datetime2(3) not null,
	CompleteTime datetime2(3) not null constraint DF_CommandHistory_CompleteTime default(getdate()),
	Succeeded bit not null,
	ResultMessage varchar(MAX) null,
	DbCreateTime datetime2(3) not null constraint DF_CommandHistory_DbCreateTime default(getdate()),
	constraint PK_CommandHistory primary key(SubmissionId),

)
GO
