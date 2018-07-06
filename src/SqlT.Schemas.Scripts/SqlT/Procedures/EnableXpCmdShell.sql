create procedure [SqlT].[EnableXpCmdShell] as

	-- To allow advanced options to be changed.
	exec sp_configure 'show advanced options', 1
	-- To update the currently configured value for advanced options.
	reconfigure
	-- To enable the feature.
	exec sp_configure 'xp_cmdshell', 1
	-- To update the currently configured value for this feature.
	reconfigure
