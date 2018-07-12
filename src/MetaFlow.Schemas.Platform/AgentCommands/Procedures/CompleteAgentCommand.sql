create procedure [WF].[CompleteAgentCommand]
(
	@CommandId bigint, 
	@Succeeded bit, 
	@ResultDescription nvarchar(max) = null
) as

	set nocount on
	set xact_abort on
	
	declare 
		@LoadTS datetime2(0) = getdate(),
		@LoadCT int = 0,
		@OpName sysname = object_name(@@procid),
		@Msg nvarchar(250);

	set @Msg = concat('Executing @OpName=', @OpName);	
	raiserror(@Msg, 0, 1) with nowait;

	update [WF].[AgentCommandQueue]
	set
		Completed = 1,
		Succeeded = @Succeeded,
		CompletionTS = @LoadTS,
		CompletionMessage = @ResultDescription
	where
		CommandId = @CommandId;

	set @LoadCT = @@ROWCOUNT;

	set @Msg = concat('Executed @OpName=', @OpName, ' @LoadCT=', @LoadCT);	
	raiserror(@Msg, 0, 1) with nowait;

	return @LoadCT;



	
