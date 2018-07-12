create type [T0].[DacDeploymentToken] as table
(
	DeploymentId int not null,
	CorrelationToken nvarchar(250) not null
)


