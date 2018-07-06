create procedure [SqlT].[EnabledContainedDatabases] as
exec sp_configure 'contained database authentication', 1
reconfigure