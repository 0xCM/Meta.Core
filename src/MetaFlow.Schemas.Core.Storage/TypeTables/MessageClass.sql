create table [PF].[MessageClass]
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_MessageClass_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_MessageClass primary key(TypeCode),
	constraint UQ_MessageClass_Identifier unique(Identifier),
	constraint UQ_MessageClass_Label unique(Label)

)

GO
create trigger [PF].[MessageClassUpdated] 
	on [PF].[MessageClass] after update as
	update [PF].[MessageClass] set 
		UpdateTS = getdate()
	from 
		[PF].[MessageClass] c 
	inner join 
		inserted on inserted.TypeCode = c.TypeCode
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[TinyTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'Table',
    @level1name = N'MessageClass',
    @level2type = NULL,
    @level2name = NULL

GO
exec sp_addextendedproperty @name = N'SqlT_EnumProvider',
    @value = '',
    @level0type = 'SCHEMA',
    @level0name = 'PF',
    @level1type = 'Table',
    @level1name = 'MessageClass';
GO
create procedure [PF].[SyncMessageClasses]
@Records [T0].[TinyTypeTableRow] readonly
as
merge into [PF].[MessageClass] with (holdlock)
 as Dst
using @Records as Src on Dst.TypeCode = Src.TypeCode
when not matched then insert (TypeCode, Identifier, Label, Description) values (Src.TypeCode, Src.Identifier, Src.Label, Src.Description)
when matched and not exists (select [Src].[Identifier],
                                    [Src].[Label],
                                    [Src].[Description]
                             intersect
                             select [Dst].[Identifier],
                                    [Dst].[Label],
                                    [Dst].[Description]) then update 
set Dst.Identifier  = Src.Identifier,
    Dst.Label       = Src.Label,
    Dst.Description = Src.Description
when not matched by source then delete;
GO

create function [PF].[MessageClasses]() returns table as return
	select
		TypeCode,
		Identifier,
		Label,
		[Description]
	from
		[PF].[MessageClass]
GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[TinyTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'Function',
    @level1name = N'MessageClasses',
    @level2type = NULL,
    @level2name = NULL

GO
