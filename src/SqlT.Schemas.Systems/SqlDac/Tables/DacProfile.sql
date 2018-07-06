create table [SqlDac].[DacProfile]
(
	StoreKey int not null 
		constraint DF_DacProfile_SystemKey 
			default(next value for [SqlStore].[StoreKeySequence]),
	ProfileFileName nvarchar(250) not null,
	SourcePackage nvarchar(75) null,
	TargetServer nvarchar(75) not null,	
	TargetDatabase nvarchar(128) not null,
	ProfileXml nvarchar(max) not null,
	ProfilePath nvarchar(250) null,	
	CreateTS datetime2(0) not null 
		constraint DF_DacProfile_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,
	
	constraint PK_DacProfile primary key(StoreKey),
	constraint UQ_DacProfile unique(ProfileFileName)


)	
GO
create trigger [SqlDac].[DacProfileUpdated] 
	on [SqlDac].[DacProfile] after update as
		update [SqlDac].[DacProfile] set 
			UpdateTS = getdate()
	from 
		[SqlDac].[DacProfile] x 
			inner join inserted on 
				inserted.StoreKey = x.StoreKey
GO



