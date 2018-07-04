update [YSchema].[YTable] 
	set 
		YCol1 = @XParam1,  
		YCol2 = @XParam2 
	where 
		YCol3 = @XParam3 
	and YCol4 is null