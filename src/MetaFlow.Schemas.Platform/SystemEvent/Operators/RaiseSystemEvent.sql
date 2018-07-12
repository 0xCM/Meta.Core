create procedure [WF].[RaiseSystemEvent]
(
	@EventId uniqueidentifier, 
	@PairId uniqueidentifier,
	@SourceNodeId nvarchar(75),
	@SourceSystemId nvarchar(75),
	@EventType nvarchar(128),
	@EventUri nvarchar(250),
	@CorrelationToken nvarchar(250),
	@SeverityLevel int,
	@EventBody nvarchar(max),
	@EventTS datetime2(7) = null
) as
	set nocount on
	set xact_abort on
	
	insert [WF].[SystemEventStore]
	(
		EventTS,
		EventId,
		PairId,
		SourceNodeId,
		SourceSystemId,
		EventType,
		EventUri,
		CorrelationToken,
		SeverityLevel,
		EventBody
	)
	select
		isnull(@EventTS, sysdatetime()),
		@EventId,
		@PairId,
		@SourceNodeId,
		@SourceSystemId,
		@EventType,
		@EventUri,
		@CorrelationToken,
		@SeverityLevel,
		@EventBody

GO
