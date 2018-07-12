create procedure [PF].[ConfigureTableMonitoring]
(
	@HostId nvarchar(75), 
	@DatabaseName nvarchar(128), 
	@SchemaName nvarchar(128), 
	@TableName nvarchar(128), 
	@MonitorFrequency int, 
	@MonitorEnabled bit
) as

	if not exists(select top 1 1 from [PF].[MonitoredTableSetting] 
			where HostId = @HostId 
			and DatabaseName = @DatabaseName
			and SchemaName = @SchemaName 
			and TableName = @TableName)
		insert [PF].[MonitoredTableSetting]
		(
			HostId,
			DatabaseName,
			SchemaName,
			TableName,
			MonitorFrequency,
			MonitorEnabled

		)
		values
		(
			@HostId,
			@DatabaseName,
			@SchemaName,
			@TableName,
			@MonitorFrequency,
			@MonitorEnabled
		)
	else update [PF].[MonitoredTableSetting]
		set 
			MonitorFrequency = @MonitorFrequency,
			MonitorEnabled = @MonitorEnabled
		where 
			HostId = @HostId 
		and DatabaseName = @DatabaseName
		and SchemaName = @SchemaName 
		and TableName = @TableName;

		

	
	
