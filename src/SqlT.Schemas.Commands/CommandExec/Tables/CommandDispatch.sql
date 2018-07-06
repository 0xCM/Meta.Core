CREATE TABLE [CommandExec].[CommandDispatch]
(
	SubmissionId bigint not null,
	CommandName nvarchar(250) not null,
	CommandSpecName nvarchar(500) not null,	
	CommandJson nvarchar(max) not null
		constraint CK_CommandDispatch_CommandJson check(isjson(CommandJson)>0),
	CorrelationToken nvarchar(50) null,
    EnqueuedTime datetime2(3) not null,
	DispatchTime datetime2(3) not null constraint DF_CommandDispatch_DispatchTime default(getdate()), 
	DbCreateTime datetime2(3) not null constraint DF_CommandDispatch_DbCreateTime default(getdate()),
	constraint PK_CommandDispatch primary key(SubmissionId),

)
