create type [WF].[AgentCommand] as table
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
	Arg6Value nvarchar(250) null
)
	
