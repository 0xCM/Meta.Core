create table [PF].[EnterpriseShareDefinition]
(
	SystemKey bigint not null 
		constraint DF_EnterpriseShare_SystemKey default(next value for [PF].[SystemKeySequence]),
	ShareLabel nvarchar(128) not null,
	UncRootPath nvarchar(500) not null,
	UserName nvarchar(128),
	UserPass nvarchar(128),
	CreateTS  datetime2(0) not null
		constraint DF_EnterpriseShare_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,	
	
	constraint PK_EnterpriseShare primary key(SystemKey),
	
	
)
GO
create trigger [PF].[EnterpriseShareStoreUpdated] 
	on [PF].[EnterpriseShareDefinition] after update as
	update [PF].[EnterpriseShareDefinition] set 
		UpdateTS = getdate()
	from 
		[PF].[EnterpriseShareDefinition] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
