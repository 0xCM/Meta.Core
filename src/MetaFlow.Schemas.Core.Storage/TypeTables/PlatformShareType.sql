create table [PF].[PlatformShareType]
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_PlatformShareType_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_PlatformShareType primary key(TypeCode),
	constraint UQ_PlatformShareType_Identifier unique(Identifier),
	constraint UQ_PlatformShareType_Label unique(Label),
)
GO

create trigger [PF].[PlatformShareTypeUpdated] 
	on [PF].[PlatformShareType] after update as
	update [PF].[PlatformShareType] set 
		UpdateTS = getdate()
	from 
		[PF].[PlatformShareType] c 
	inner join 
		inserted on inserted.TypeCode = c.TypeCode
GO

create function [PF].[PlatformShareTypeExists](@Identifier nvarchar(75)) returns bit as
	begin
	declare @Exists bit = case (select 1 from [PF].[PlatformShareType] where Identifier = @Identifier)
							when 1 then 1 else 0 end;
	return @Exists;	
	end
GO

exec sp_addextendedproperty @name = N'SqlT_TableRole',
    @value = N'TypeTable',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'TABLE',
    @level1name = N'PlatformShareType',
    @level2type = NULL,
    @level2name = NULL
GO

exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[TinyTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'Table',
    @level1name = N'PlatformShareType',
    @level2type = NULL,
    @level2name = NULL
GO
exec sp_addextendedproperty @name = N'SqlT_EnumProvider',
    @value = '',
    @level0type = 'SCHEMA',
    @level0name = 'PF',
    @level1type = 'Table',
    @level1name = 'PlatformShareType';
GO



