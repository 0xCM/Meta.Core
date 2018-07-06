create procedure [SqlT].[EnableSqlClr] as
	exec sp_configure 'show advanced options', 1;  
	reconfigure;  
	exec sp_configure 'clr enabled', 1;    
	reconfigure;  
  
