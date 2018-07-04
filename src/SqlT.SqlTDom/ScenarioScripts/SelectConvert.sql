select 
    YCol1 = convert(varchar(255), x.XCol1),
	YCol2 =  640, 
    XCol3 = x.YCol2
from
   [XSchema].[XTable] x

