create table [MC].[DevArea]
(
	Identifier nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_DevArea_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_DevArea primary key(Identifier),
)
GO

create trigger [MC].[OnDevAreaUpdated] 
	on [MC].[DevArea] after update as
	update [MC].[DevArea] set 
		UpdateTS = getdate()
	from 
		[MC].[DevArea] c 
	inner join 
		inserted on inserted.Identifier = c.Identifier
GO

