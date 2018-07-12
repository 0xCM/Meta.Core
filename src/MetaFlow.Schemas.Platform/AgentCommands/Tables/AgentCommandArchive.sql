create table [WF].[AgentCommandArchive]
(
	CommandId bigint not null,
	SourceNodeId nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,
	CorrelationToken nvarchar(250) not null,

	AgentId nvarchar(75) not null,
	CommandName nvarchar(75) not null,
	Arg1Name nvarchar(75) null,
	Arg1Value nvarchar(250) null,
	Arg2Name nvarchar(75) null,
	Arg2Value nvarchar(250) null,
	Arg3Name nvarchar(75) null,
	Arg3Value nvarchar(250) null,
	Arg4Name nvarchar(75) null,
	Arg4Value nvarchar(250) null,
	Arg5Name nvarchar(75) null,
	Arg5Value nvarchar(250) null,
	Arg6Name nvarchar(75) null,
	Arg6Value nvarchar(250) null,


	SubmissionTS datetime2(0) not null, 
	Dispatched bit not null,
	DispatchedTS datetime2(0) null,
	Completed bit not null,
	Succeeded bit not null,
	CompletionTS datetime2(0) null,
	OutcomeDescription nvarchar(1024) null,	

	ArchiveTS datetime2(0) not null
		constraint DF_AgentCommandArchive_ArchiveTS default(getdate()),

	constraint PK_AgentCommandArchive primary key(CommandId)
)
GO
