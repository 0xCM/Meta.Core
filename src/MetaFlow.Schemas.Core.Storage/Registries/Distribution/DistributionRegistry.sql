create table [PF].[DistributionRegistry]
(
	DistributionId nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_Distribution_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,


	constraint PK_DistributionRegistry primary key(DistributionId),
	
)
GO
create trigger [PF].[DistributionRegistryUpdated] 
	on [PF].[DistributionRegistry] after update as
		update [PF].[DistributionRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[DistributionRegistry] x 
			inner join inserted on 
				inserted.DistributionId = x.DistributionId
GO

