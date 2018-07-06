create table [MC].[DistributionRegistry]
(
 	StoreKey int not null
		constraint DF_DistributionRegistry_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),

	DistributionId nvarchar(75) not null,
	ContentType nvarchar(75) not null,
	ContentVersion nvarchar(75) null,

	CreateTS datetime2(0) not null
		constraint DF_DistributionRegistry_CreateTS default(getdate()),	
	UpdateTS datetime2(0) null,
	constraint PK_DistributionRegistry primary key(StoreKey),	
	constraint UQ_DistributionRegistry unique(DistributionId, ContentType),
	constraint FK_DistributionRegistry foreign key(ContentType)
		references [MC].[DistributionType](Identifier)


)
	
