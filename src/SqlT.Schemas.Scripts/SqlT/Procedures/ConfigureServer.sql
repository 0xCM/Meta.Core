create procedure [SqlT].[ConfigureServer](@SettingName varchar(35), @SettingValue int) as
begin
	exec sp_configure @SettingName, @SettingValue
	reconfigure
end
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Specifies and applies a server-level setting',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'PROCEDURE',
    @level1name = N'ConfigureServer',
    @level2type = NULL,
    @level2name = NULL
