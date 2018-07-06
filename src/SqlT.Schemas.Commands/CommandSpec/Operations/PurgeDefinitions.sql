CREATE PROCEDURE [CommandSpec].[PurgeDefinitions] as
	delete CommandSpec.CommandDefinition
