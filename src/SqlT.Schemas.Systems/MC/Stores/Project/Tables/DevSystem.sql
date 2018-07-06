create table [MC].[DevSystem]
(
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_DevSystem_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_DevSystem primary key(Identifier),
	constraint UQ_DevSystem_Label unique(Label),
)
GO

create trigger [MC].[OnDevSystemUpdated] 
	on [MC].[DevSystem] after update as
	update [MC].[DevSystem] set 
		UpdateTS = getdate()
	from 
		[MC].[DevSystem] c 
	inner join 
		inserted on inserted.Identifier = c.Identifier
GO
