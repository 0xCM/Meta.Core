create type [WF].[CompletionOperator] as table
(
	TaskId bigint null, 
	Succeeded bit null, 	
	ResultDescription nvarchar(250) null
)

	
