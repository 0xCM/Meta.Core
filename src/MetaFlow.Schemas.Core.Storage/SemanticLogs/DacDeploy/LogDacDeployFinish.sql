create procedure [PF].[LogDacDeployFinish](@DeploymentId int, @Succeeded bit, @Message nvarchar(1024))  as

	set nocount on
	set xact_abort on

	update [PF].[DacDeployLog] set 
		Succeeded = @Succeeded,
		Completed = 1,
		CompletionMessage = @Message
	where 
		DeploymentId = @DeploymentId;

