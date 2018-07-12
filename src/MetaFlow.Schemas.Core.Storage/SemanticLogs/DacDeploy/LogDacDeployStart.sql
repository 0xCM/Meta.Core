create procedure [PF].[LogDacDeployStart]
(
	@SourceNodeId nvarchar(75),
	@SourcePackage nvarchar(128),
	@TargetNodeId nvarchar(75),
	@TargetDatabase nvarchar(128),
	@CorrelationToken nvarchar(250)	
)
as
	set nocount on
	set xact_abort on

	declare @DeploymentToken [T0].[DacDeploymentToken];
	
	insert [PF].[DacDeployLog]
	(
		SourceNodeId,
		SourcePackage,
		TargetNodeId,
		TargetDatabase,
		CorrelationToken
	)
	output 
		inserted.DeploymentId, 
		inserted.CorrelationToken 
	into 
		@DeploymentToken(DeploymentId,CorrelationToken)
	select 
		@SourceNodeId, 
		@SourcePackage, 
		@TargetNodeId, 
		@TargetDatabase, 
		@CorrelationToken;

	select * from @DeploymentToken
GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[DacDeploymentToken]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'PROCEDURE',
    @level1name = N'LogDacDeployStart',
    @level2type = NULL,
    @level2name = NULL
