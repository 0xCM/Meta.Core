create function [Patterns].[Transformer01]() returns table as return 
	select 	
		CompanyId, 
		CompanyType = CompanyTypeCode, 
		CompanyName, 
		IsBankrupt = cast(case StatusCode when 'Bankrupt' then 1 else 0 end as bit),
		Address1 = case rtrim(ltrim(Line1)) when '' then null else Line1 end, 
		Address2 = case rtrim(ltrim(Line2)) when '' then null else Line1 end,  
		City = case rtrim(ltrim(entCityName)) when '' then null else City end,  
		[State] = entState, 
		Zip = entZip, 
		PhoneNumber = case rtrim(ltrim(Phone)) when '' then null else Phone end,  
		IsCorp = cast(IsCorp as bit), 
		CreateTS = CreateDate
	
	from 
		[Patterns].[CompanyAddress]