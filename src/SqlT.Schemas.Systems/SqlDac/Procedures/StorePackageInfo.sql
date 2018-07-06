create procedure [SqlDac].[StorePackageInfo]
(
	@PackageName nvarchar(128), 
	@Author nvarchar(128), 
	@Description nvarchar(250),
	@Variables [SqlDac].[PackageVariable] readonly,
	@Dependencies [SqlDac].[PackageAssociation] readonly
) as

	set xact_abort, nocount ON;


	begin transaction;

		with SrcDescriptors as
		(
			select 
				PackageName = @PackageName,
				PackageAuthor = @Author,
				[Description] = @Description
		)

		merge into [SqlDac].[PackageDescriptor] as Dst 
			using SrcDescriptors as Src on
				Dst.PackageName = Src.PackageName
		when not matched then
			insert
			(
				PackageName,
				PackageAuthor,
				[Description]
			)
			values
			(
				Src.PackageName,
				Src.PackageAuthor,
				Src.[Description]
			)
		when matched and not exists
			(

			select
				Src.PackageAuthor,
				Src.[Description]

			intersect

			select
				Dst.PackageAuthor,
				Dst.[Description]

			)
		then update set
			Dst.PackageAuthor = Src.PackageAuthor,
			Dst.[Description] = Src.[Description];
	

		
		merge into [SqlDac].[PackageVariable] as Dst 
			using @Variables as Src on
				Dst.VariableName = Src.VariableName
			and Dst.PackageName = Src.PackageName
		when not matched then
			insert
			(
				PackageName,
				VariableName
			)
			values
			(
				Src.PackageName,
				Src.VariableName
			);
				
		merge into [SqlDac].[PackageDependency] as Dst
			using @Dependencies as Src on
				Dst.ClientPackage = Src.ClientPackage
			and Dst.SupplierPackage = Src.SupplierPackage
		when not matched then insert
			(
				ClientPackage,
				SupplierPackage,
				DependencyType
			)
			values
			(
				Src.ClientPackage,
				Src.SupplierPackage,
				Src.DependencyType
			)
		when matched and Dst.DependencyType <> Src.DependencyType
		then update set
			Dst.DependencyType = Src.DependencyType;
			
	commit transaction