create procedure [PF].[RegisterHostDatabase]
(
	@DatabaseName sysname, 
	@DatabaseType nvarchar(75), 
	@IsPrimary bit = 1, 
	@IsEnabled bit = 1, 
	@IsModel bit = 0,
	@IsRestore bit = 0
) as

	set xact_abort on
	set nocount on

	declare @ServerId 
		nvarchar(75) = [PF].[SqlNodeId]();

	if @ServerId is null
		throw 75000, 'The server has not been configured: Executing server is NULL', 1;	
	
	if exists(select 1 from [PF].[PlatformDatabaseRegistry] where DatabaseName = @DatabaseName and ServerId = @ServerId)
	begin
		if not exists
		(
			select 
				@DatabaseType,
				@IsPrimary,
				@IsEnabled,
				@IsModel,
				@IsRestore

			intersect

			select
				DatabaseType,
				IsPrimary,
				IsEnabled,
				IsModel,
				IsRestore
			from
				[PF].[PlatformDatabaseRegistry]
			where
				DatabaseName = @DatabaseName
			and ServerId = @ServerId
		)
		update [PF].[PlatformDatabaseRegistry] set 
			DatabaseType = @DatabaseType,
			IsPrimary = @IsPrimary,
			IsEnabled = @IsEnabled,
			IsModel = @IsModel,
			IsRestore = @IsRestore
		where
			DatabaseName = @DatabaseName
		and ServerId = @ServerId
	end
	else
		insert [PF].[PlatformDatabaseRegistry] 
		(

			ServerId,
			DatabaseName,
			DatabaseType,
			IsPrimary,
			IsEnabled,
			IsModel,
			IsRestore
		)
		values
		(
			@ServerId,
			@DatabaseName,
			@DatabaseType,
			@IsPrimary,
			@IsEnabled,
			@IsModel,
			@IsRestore
		);
		
	


