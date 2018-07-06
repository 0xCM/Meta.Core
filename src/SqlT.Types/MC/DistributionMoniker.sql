create type [MC].[DistributionMoniker] as table
(
	DistributionId nvarchar(75) not null,
	ContentType nvarchar(75) not null,
	ContentVersion nvarchar(75) null

)
GO


	
