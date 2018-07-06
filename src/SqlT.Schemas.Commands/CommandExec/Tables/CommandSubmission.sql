create table [CommandExec].[CommandSubmission]
(
	SubmissionId bigint not null 
		constraint DF_CommandSubmission_SubmissionId 
			default(next value for [CommandExec].SubmissionSequence),
	CommandName nvarchar(250) not null,
	CommandSpecName nvarchar(500) not null,	
	CommandJson nvarchar(max) not null 
		constraint CK_CommandSubmission_CommandJson check(isjson(CommandJson)>0),    
	CorrelationToken nvarchar(50) null,
	RecipientName nvarchar(250) null,
	EnqueuedTime datetime2(3) not null 
		constraint DF_CommandInstance_EnqueuedTime default(getdate()),
	DbCreateTime datetime2(3) not null 
		constraint DF_CommandInstance_DbCreateTime default(getdate()),
	constraint PK_CommandSubmission primary key(SubmissionId)
)
GO
create sequence [CommandExec].[SubmissionSequence]
	as bigint start with 1 cache 100
GO
