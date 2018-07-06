CREATE PROCEDURE [SqlT].[ConfigureServerOption](@OptionName varchar(35), @OptionValue int) as
begin
	exec sp_configure 'show_advanced_option', '1'
	reconfigure
	exec sp_configure @OptionName, @OptionValue
	reconfigure
	exec sp_configure
end	
