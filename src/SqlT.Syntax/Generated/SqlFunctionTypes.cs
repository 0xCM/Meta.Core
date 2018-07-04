//Generated @ 5/28/2018 5:32:19 PM
namespace SqlT.Syntax
{
	using T = SqlFunctionTypes;
	using sxc = contracts;

	public static class SqlFunctionTypes
	{
		public sealed class PARTITION : native_scalar_function<PARTITION> { PARTITION() : base("$partition") { } }
		public sealed class @CONNECTIONS : native_scalar_function<@CONNECTIONS> { @CONNECTIONS() : base("@@CONNECTIONS") { } }
		public sealed class @CPU_BUSY : native_scalar_function<@CPU_BUSY> { @CPU_BUSY() : base("@@CPU_BUSY") { } }
		public sealed class @CURSOR_ROWS : native_scalar_function<@CURSOR_ROWS> { @CURSOR_ROWS() : base("@@CURSOR_ROWS") { } }
		public sealed class @DATEFIRST : native_scalar_function<@DATEFIRST> { @DATEFIRST() : base("@@DATEFIRST") { } }
		public sealed class @DBTS : native_scalar_function<@DBTS> { @DBTS() : base("@@DBTS") { } }
		public sealed class @ERROR : native_scalar_function<@ERROR> { @ERROR() : base("@@ERROR") { } }
		public sealed class @FETCH_STATUS : native_scalar_function<@FETCH_STATUS> { @FETCH_STATUS() : base("@@FETCH_STATUS") { } }
		public sealed class @IDENTITY : native_scalar_function<@IDENTITY> { @IDENTITY() : base("@@IDENTITY") { } }
		public sealed class @IDLE : native_scalar_function<@IDLE> { @IDLE() : base("@@IDLE") { } }
		public sealed class @IO_BUSY : native_scalar_function<@IO_BUSY> { @IO_BUSY() : base("@@IO_BUSY") { } }
		public sealed class @LANGID : native_scalar_function<@LANGID> { @LANGID() : base("@@LANGID") { } }
		public sealed class @LANGUAGE : native_scalar_function<@LANGUAGE> { @LANGUAGE() : base("@@LANGUAGE") { } }
		public sealed class @LOCK_TIMEOUT : native_scalar_function<@LOCK_TIMEOUT> { @LOCK_TIMEOUT() : base("@@LOCK_TIMEOUT") { } }
		public sealed class @MAX_CONNECTIONS : native_scalar_function<@MAX_CONNECTIONS> { @MAX_CONNECTIONS() : base("@@MAX_CONNECTIONS") { } }
		public sealed class @MAX_PRECISION : native_scalar_function<@MAX_PRECISION> { @MAX_PRECISION() : base("@@MAX_PRECISION") { } }
		public sealed class @NESTLEVEL : native_scalar_function<@NESTLEVEL> { @NESTLEVEL() : base("@@NESTLEVEL") { } }
		public sealed class @OPTIONS : native_scalar_function<@OPTIONS> { @OPTIONS() : base("@@OPTIONS") { } }
		public sealed class @PACK_RECEIVED : native_scalar_function<@PACK_RECEIVED> { @PACK_RECEIVED() : base("@@PACK_RECEIVED") { } }
		public sealed class @PACK_SENT : native_scalar_function<@PACK_SENT> { @PACK_SENT() : base("@@PACK_SENT") { } }
		public sealed class @PACKET_ERRORS : native_scalar_function<@PACKET_ERRORS> { @PACKET_ERRORS() : base("@@PACKET_ERRORS") { } }
		public sealed class @PROCID : native_scalar_function<@PROCID> { @PROCID() : base("@@PROCID") { } }
		public sealed class @REMSERVER : native_scalar_function<@REMSERVER> { @REMSERVER() : base("@@REMSERVER") { } }
		public sealed class @ROWCOUNT : native_scalar_function<@ROWCOUNT> { @ROWCOUNT() : base("@@ROWCOUNT") { } }
		public sealed class @SERVERNAME : native_scalar_function<@SERVERNAME> { @SERVERNAME() : base("@@SERVERNAME") { } }
		public sealed class @SERVICENAME : native_scalar_function<@SERVICENAME> { @SERVICENAME() : base("@@SERVICENAME") { } }
		public sealed class @SPID : native_scalar_function<@SPID> { @SPID() : base("@@SPID") { } }
		public sealed class @TEXTSIZE : native_scalar_function<@TEXTSIZE> { @TEXTSIZE() : base("@@TEXTSIZE") { } }
		public sealed class @TIMETICKS : native_scalar_function<@TIMETICKS> { @TIMETICKS() : base("@@TIMETICKS") { } }
		public sealed class @TOTAL_ERRORS : native_scalar_function<@TOTAL_ERRORS> { @TOTAL_ERRORS() : base("@@TOTAL_ERRORS") { } }
		public sealed class @TOTAL_READ : native_scalar_function<@TOTAL_READ> { @TOTAL_READ() : base("@@TOTAL_READ") { } }
		public sealed class @TOTAL_WRITE : native_scalar_function<@TOTAL_WRITE> { @TOTAL_WRITE() : base("@@TOTAL_WRITE") { } }
		public sealed class @TRANCOUNT : native_scalar_function<@TRANCOUNT> { @TRANCOUNT() : base("@@TRANCOUNT") { } }
		public sealed class @VERSION : native_scalar_function<@VERSION> { @VERSION() : base("@@VERSION") { } }
		public sealed class ABS : native_scalar_function<ABS> { ABS() : base("ABS") { } }
		public sealed class ACOS : native_scalar_function<ACOS> { ACOS() : base("ACOS") { } }
		public sealed class APP_NAME : native_scalar_function<APP_NAME> { APP_NAME() : base("APP_NAME") { } }
		public sealed class APPLOCK_MODE : native_scalar_function<APPLOCK_MODE> { APPLOCK_MODE() : base("APPLOCK_MODE") { } }
		public sealed class APPLOCK_TEST : native_scalar_function<APPLOCK_TEST> { APPLOCK_TEST() : base("APPLOCK_TEST") { } }
		public sealed class ASCII : native_scalar_function<ASCII> { ASCII() : base("ASCII") { } }
		public sealed class ASIN : native_scalar_function<ASIN> { ASIN() : base("ASIN") { } }
		public sealed class ASSEMBLYPROPERTY : native_scalar_function<ASSEMBLYPROPERTY> { ASSEMBLYPROPERTY() : base("ASSEMBLYPROPERTY") { } }
		public sealed class ASYMKEY_ID : native_scalar_function<ASYMKEY_ID> { ASYMKEY_ID() : base("AsymKey_ID") { } }
		public sealed class ASYMKEYPROPERTY : native_scalar_function<ASYMKEYPROPERTY> { ASYMKEYPROPERTY() : base("ASYMKEYPROPERTY") { } }
		public sealed class ATAN : native_scalar_function<ATAN> { ATAN() : base("ATAN") { } }
		public sealed class ATN2 : native_scalar_function<ATN2> { ATN2() : base("ATN2") { } }
		public sealed class AVG : native_scalar_function<AVG> { AVG() : base("AVG") { } }
		public sealed class BADPASSWORDCOUNT : native_scalar_function<BADPASSWORDCOUNT> { BADPASSWORDCOUNT() : base("BadPasswordCount") { } }
		public sealed class BADPASSWORDTIME : native_scalar_function<BADPASSWORDTIME> { BADPASSWORDTIME() : base("BadPasswordTime") { } }
		public sealed class BINARY_CHECKSUM : native_scalar_function<BINARY_CHECKSUM> { BINARY_CHECKSUM() : base("BINARY_CHECKSUM") { } }
		public sealed class CAST : native_scalar_function<CAST> { CAST() : base("CAST") { } }
		public sealed class CEILING : native_scalar_function<CEILING> { CEILING() : base("CEILING") { } }
		public sealed class CERT_ID : native_scalar_function<CERT_ID> { CERT_ID() : base("CERT_ID") { } }
		public sealed class CERTENCODED : native_scalar_function<CERTENCODED> { CERTENCODED() : base("CERTENCODED") { } }
		public sealed class CERTPRIVATEKEY : native_scalar_function<CERTPRIVATEKEY> { CERTPRIVATEKEY() : base("CERTPRIVATEKEY") { } }
		public sealed class CERTPROPERTY : native_scalar_function<CERTPROPERTY> { CERTPROPERTY() : base("CERTPROPERTY") { } }
		public sealed class CHAR : native_scalar_function<CHAR> { CHAR() : base("char") { } }
		public sealed class CHARINDEX : native_scalar_function<CHARINDEX> { CHARINDEX() : base("CHARINDEX") { } }
		public sealed class CHECKSUM : native_scalar_function<CHECKSUM> { CHECKSUM() : base("CHECKSUM") { } }
		public sealed class CHECKSUM_AGG : native_scalar_function<CHECKSUM_AGG> { CHECKSUM_AGG() : base("CHECKSUM_AGG") { } }
		public sealed class CHOOSE : native_scalar_function<CHOOSE> { CHOOSE() : base("CHOOSE") { } }
		public sealed class COL_LENGTH : native_scalar_function<COL_LENGTH> { COL_LENGTH() : base("COL_LENGTH") { } }
		public sealed class COL_NAME : native_scalar_function<COL_NAME> { COL_NAME() : base("COL_NAME") { } }
		public sealed class COLLATIONPROPERTY : native_scalar_function<COLLATIONPROPERTY> { COLLATIONPROPERTY() : base("COLLATIONPROPERTY") { } }
		public sealed class COLUMNPROPERTY : native_scalar_function<COLUMNPROPERTY> { COLUMNPROPERTY() : base("COLUMNPROPERTY") { } }
		public sealed class COLUMNS_UPDATED : native_scalar_function<COLUMNS_UPDATED> { COLUMNS_UPDATED() : base("COLUMNS_UPDATED") { } }
		public sealed class COMPRESS : native_scalar_function<COMPRESS> { COMPRESS() : base("COMPRESS") { } }
		public sealed class CONCAT : native_scalar_function<CONCAT> { CONCAT() : base("CONCAT") { } }
		public sealed class CONCAT_WS : native_scalar_function<CONCAT_WS> { CONCAT_WS() : base("CONCAT_WS") { } }
		public sealed class CONNECTIONPROPERTY : native_scalar_function<CONNECTIONPROPERTY> { CONNECTIONPROPERTY() : base("CONNECTIONPROPERTY") { } }
		public sealed class CONTEXT_INFO : native_scalar_function<CONTEXT_INFO> { CONTEXT_INFO() : base("CONTEXT_INFO") { } }
		public sealed class CONVERT : native_scalar_function<CONVERT> { CONVERT() : base("CONVERT") { } }
		public sealed class COS : native_scalar_function<COS> { COS() : base("COS") { } }
		public sealed class COT : native_scalar_function<COT> { COT() : base("COT") { } }
		public sealed class COUNT : native_scalar_function<COUNT> { COUNT() : base("COUNT") { } }
		public sealed class COUNT_BIG : native_scalar_function<COUNT_BIG> { COUNT_BIG() : base("COUNT_BIG") { } }
		public sealed class CRYPT_GEN_RANDOM : native_scalar_function<CRYPT_GEN_RANDOM> { CRYPT_GEN_RANDOM() : base("CRYPT_GEN_RANDOM") { } }
		public sealed class CUME_DIST : native_scalar_function<CUME_DIST> { CUME_DIST() : base("CUME_DIST") { } }
		public sealed class CURRENT_REQUEST_ID : native_scalar_function<CURRENT_REQUEST_ID> { CURRENT_REQUEST_ID() : base("CURRENT_REQUEST_ID") { } }
		public sealed class CURRENT_TIMESTAMP : native_scalar_function<CURRENT_TIMESTAMP> { CURRENT_TIMESTAMP() : base("CURRENT_TIMESTAMP") { } }
		public sealed class CURRENT_USER : native_scalar_function<CURRENT_USER> { CURRENT_USER() : base("CURRENT_USER") { } }
		public sealed class CURSOR_STATUS : native_scalar_function<CURSOR_STATUS> { CURSOR_STATUS() : base("CURSOR_STATUS") { } }
		public sealed class DATABASE_PRINCIPAL_ID : native_scalar_function<DATABASE_PRINCIPAL_ID> { DATABASE_PRINCIPAL_ID() : base("DATABASE_PRINCIPAL_ID") { } }
		public sealed class DATABASEPROPERTYEX : native_scalar_function<DATABASEPROPERTYEX> { DATABASEPROPERTYEX() : base("DATABASEPROPERTYEX") { } }
		public sealed class DATALENGTH : native_scalar_function<DATALENGTH> { DATALENGTH() : base("DATALENGTH") { } }
		public sealed class DATE_FORMAT : native_scalar_function<DATE_FORMAT> { DATE_FORMAT() : base("DATE FORMAT") { } }
		public sealed class DATEADD : native_scalar_function<DATEADD> { DATEADD() : base("DATEADD") { } }
		public sealed class DATEDIFF : native_scalar_function<DATEDIFF> { DATEDIFF() : base("DATEDIFF") { } }
		public sealed class DATEDIFF_BIG : native_scalar_function<DATEDIFF_BIG> { DATEDIFF_BIG() : base("DATEDIFF_BIG") { } }
		public sealed class DATEFROMPARTS : native_scalar_function<DATEFROMPARTS> { DATEFROMPARTS() : base("DATEFROMPARTS") { } }
		public sealed class DATENAME : native_scalar_function<DATENAME> { DATENAME() : base("DATENAME") { } }
		public sealed class DATEPART : native_scalar_function<DATEPART> { DATEPART() : base("DATEPART") { } }
		public sealed class DATETIME2FROMPARTS : native_scalar_function<DATETIME2FROMPARTS> { DATETIME2FROMPARTS() : base("DATETIME2FROMPARTS") { } }
		public sealed class DATETIMEFROMPARTS : native_scalar_function<DATETIMEFROMPARTS> { DATETIMEFROMPARTS() : base("DATETIMEFROMPARTS") { } }
		public sealed class DATETIMEOFFSETFROMPARTS : native_scalar_function<DATETIMEOFFSETFROMPARTS> { DATETIMEOFFSETFROMPARTS() : base("DATETIMEOFFSETFROMPARTS") { } }
		public sealed class DAY : native_scalar_function<DAY> { DAY() : base("DAY") { } }
		public sealed class DB_ID : native_scalar_function<DB_ID> { DB_ID() : base("DB_ID") { } }
		public sealed class DB_NAME : native_scalar_function<DB_NAME> { DB_NAME() : base("DB_NAME") { } }
		public sealed class DECOMPRESS : native_scalar_function<DECOMPRESS> { DECOMPRESS() : base("DECOMPRESS") { } }
		public sealed class DECRYPTBYASYMKEY : native_scalar_function<DECRYPTBYASYMKEY> { DECRYPTBYASYMKEY() : base("DECRYPTBYASYMKEY") { } }
		public sealed class DECRYPTBYCERT : native_scalar_function<DECRYPTBYCERT> { DECRYPTBYCERT() : base("DECRYPTBYCERT") { } }
		public sealed class DECRYPTBYKEY : native_scalar_function<DECRYPTBYKEY> { DECRYPTBYKEY() : base("DECRYPTBYKEY") { } }
		public sealed class DECRYPTBYKEYAUTOASYMKEY : native_scalar_function<DECRYPTBYKEYAUTOASYMKEY> { DECRYPTBYKEYAUTOASYMKEY() : base("DECRYPTBYKEYAUTOASYMKEY") { } }
		public sealed class DECRYPTBYKEYAUTOCERT : native_scalar_function<DECRYPTBYKEYAUTOCERT> { DECRYPTBYKEYAUTOCERT() : base("DECRYPTBYKEYAUTOCERT") { } }
		public sealed class DECRYPTBYPASSPHRASE : native_scalar_function<DECRYPTBYPASSPHRASE> { DECRYPTBYPASSPHRASE() : base("DECRYPTBYPASSPHRASE") { } }
		public sealed class DEGREES : native_scalar_function<DEGREES> { DEGREES() : base("DEGREES") { } }
		public sealed class DENSE_RANK : native_scalar_function<DENSE_RANK> { DENSE_RANK() : base("DENSE_RANK") { } }
		public sealed class DIFFERENCE : native_scalar_function<DIFFERENCE> { DIFFERENCE() : base("DIFFERENCE") { } }
		public sealed class ENCRYPTBYASYMKEY : native_scalar_function<ENCRYPTBYASYMKEY> { ENCRYPTBYASYMKEY() : base("ENCRYPTBYASYMKEY") { } }
		public sealed class ENCRYPTBYCERT : native_scalar_function<ENCRYPTBYCERT> { ENCRYPTBYCERT() : base("ENCRYPTBYCERT") { } }
		public sealed class ENCRYPTBYKEY : native_scalar_function<ENCRYPTBYKEY> { ENCRYPTBYKEY() : base("ENCRYPTBYKEY") { } }
		public sealed class ENCRYPTBYPASSPHRASE : native_scalar_function<ENCRYPTBYPASSPHRASE> { ENCRYPTBYPASSPHRASE() : base("ENCRYPTBYPASSPHRASE") { } }
		public sealed class EOMONTH : native_scalar_function<EOMONTH> { EOMONTH() : base("EOMONTH") { } }
		public sealed class ERROR_LINE : native_scalar_function<ERROR_LINE> { ERROR_LINE() : base("ERROR_LINE") { } }
		public sealed class ERROR_MESSAGE : native_scalar_function<ERROR_MESSAGE> { ERROR_MESSAGE() : base("ERROR_MESSAGE") { } }
		public sealed class ERROR_NUMBER : native_scalar_function<ERROR_NUMBER> { ERROR_NUMBER() : base("ERROR_NUMBER") { } }
		public sealed class ERROR_PROCEDURE : native_scalar_function<ERROR_PROCEDURE> { ERROR_PROCEDURE() : base("ERROR_PROCEDURE") { } }
		public sealed class ERROR_SEVERITY : native_scalar_function<ERROR_SEVERITY> { ERROR_SEVERITY() : base("ERROR_SEVERITY") { } }
		public sealed class ERROR_STATE : native_scalar_function<ERROR_STATE> { ERROR_STATE() : base("ERROR_STATE") { } }
		public sealed class EVENTDATA : native_scalar_function<EVENTDATA> { EVENTDATA() : base("EVENTDATA") { } }
		public sealed class EXP : native_scalar_function<EXP> { EXP() : base("EXP") { } }
		public sealed class FILE_ID : native_scalar_function<FILE_ID> { FILE_ID() : base("FILE_ID") { } }
		public sealed class FILE_IDEX : native_scalar_function<FILE_IDEX> { FILE_IDEX() : base("FILE_IDEX") { } }
		public sealed class FILE_NAME : native_scalar_function<FILE_NAME> { FILE_NAME() : base("FILE_NAME") { } }
		public sealed class FILEGROUP_ID : native_scalar_function<FILEGROUP_ID> { FILEGROUP_ID() : base("FILEGROUP_ID") { } }
		public sealed class FILEGROUP_NAME : native_scalar_function<FILEGROUP_NAME> { FILEGROUP_NAME() : base("FILEGROUP_NAME") { } }
		public sealed class FILEGROUPPROPERTY : native_scalar_function<FILEGROUPPROPERTY> { FILEGROUPPROPERTY() : base("FILEGROUPPROPERTY") { } }
		public sealed class FILEPROPERTY : native_scalar_function<FILEPROPERTY> { FILEPROPERTY() : base("FILEPROPERTY") { } }
		public sealed class FILETABLEROOTPATH : native_scalar_function<FILETABLEROOTPATH> { FILETABLEROOTPATH() : base("FILETABLEROOTPATH") { } }
		public sealed class FIRST_VALUE : native_scalar_function<FIRST_VALUE> { FIRST_VALUE() : base("FIRST_VALUE") { } }
		public sealed class FLOOR : native_scalar_function<FLOOR> { FLOOR() : base("FLOOR") { } }
		public sealed class FN_EVENT_DATA : native_scalar_function<FN_EVENT_DATA> { FN_EVENT_DATA() : base("fn_event_data") { } }
		public sealed class FORMAT : native_scalar_function<FORMAT> { FORMAT() : base("FORMAT") { } }
		public sealed class FORMATMESSAGE : native_scalar_function<FORMATMESSAGE> { FORMATMESSAGE() : base("FORMATMESSAGE") { } }
		public sealed class FULLTEXTCATALOGPROPERTY : native_scalar_function<FULLTEXTCATALOGPROPERTY> { FULLTEXTCATALOGPROPERTY() : base("FULLTEXTCATALOGPROPERTY") { } }
		public sealed class FULLTEXTSERVICEPROPERTY : native_scalar_function<FULLTEXTSERVICEPROPERTY> { FULLTEXTSERVICEPROPERTY() : base("FULLTEXTSERVICEPROPERTY") { } }
		public sealed class GET_FILESTREAM_TRANSACTION_CONTEXT : native_scalar_function<GET_FILESTREAM_TRANSACTION_CONTEXT> { GET_FILESTREAM_TRANSACTION_CONTEXT() : base("GET_FILESTREAM_TRANSACTION_CONTEXT") { } }
		public sealed class GETANSINULL : native_scalar_function<GETANSINULL> { GETANSINULL() : base("GETANSINULL") { } }
		public sealed class GETDATE : native_scalar_function<GETDATE> { GETDATE() : base("GETDATE") { } }
		public sealed class GETUTCDATE : native_scalar_function<GETUTCDATE> { GETUTCDATE() : base("GETUTCDATE") { } }
		public sealed class GROUPING : native_scalar_function<GROUPING> { GROUPING() : base("GROUPING") { } }
		public sealed class GROUPING_ID : native_scalar_function<GROUPING_ID> { GROUPING_ID() : base("GROUPING_ID") { } }
		public sealed class HAS_DBACCESS : native_scalar_function<HAS_DBACCESS> { HAS_DBACCESS() : base("HAS_DBACCESS") { } }
		public sealed class HAS_PERMS_BY_NAME : native_scalar_function<HAS_PERMS_BY_NAME> { HAS_PERMS_BY_NAME() : base("HAS_PERMS_BY_NAME") { } }
		public sealed class HASHBYTES : native_scalar_function<HASHBYTES> { HASHBYTES() : base("HASHBYTES") { } }
		public sealed class HISTORYLENGTHISEXPIRED : native_scalar_function<HISTORYLENGTHISEXPIRED> { HISTORYLENGTHISEXPIRED() : base("HistoryLengthIsExpired") { } }
		public sealed class HOST_ID : native_scalar_function<HOST_ID> { HOST_ID() : base("HOST_ID") { } }
		public sealed class HOST_NAME : native_scalar_function<HOST_NAME> { HOST_NAME() : base("HOST_NAME") { } }
		public sealed class IDENT_CURRENT : native_scalar_function<IDENT_CURRENT> { IDENT_CURRENT() : base("IDENT_CURRENT") { } }
		public sealed class IDENT_INCR : native_scalar_function<IDENT_INCR> { IDENT_INCR() : base("IDENT_INCR") { } }
		public sealed class IDENT_SEED : native_scalar_function<IDENT_SEED> { IDENT_SEED() : base("IDENT_SEED") { } }
		public sealed class IIF : native_scalar_function<IIF> { IIF() : base("IIF") { } }
		public sealed class INDEX_COL : native_scalar_function<INDEX_COL> { INDEX_COL() : base("INDEX_COL") { } }
		public sealed class INDEXKEY_PROPERTY : native_scalar_function<INDEXKEY_PROPERTY> { INDEXKEY_PROPERTY() : base("INDEXKEY_PROPERTY") { } }
		public sealed class INDEXPROPERTY : native_scalar_function<INDEXPROPERTY> { INDEXPROPERTY() : base("INDEXPROPERTY") { } }
		public sealed class IS_MEMBER : native_scalar_function<IS_MEMBER> { IS_MEMBER() : base("IS_MEMBER") { } }
		public sealed class IS_OBJECTSIGNED : native_scalar_function<IS_OBJECTSIGNED> { IS_OBJECTSIGNED() : base("IS_OBJECTSIGNED") { } }
		public sealed class IS_ROLEMEMBER : native_scalar_function<IS_ROLEMEMBER> { IS_ROLEMEMBER() : base("IS_ROLEMEMBER") { } }
		public sealed class IS_SRVROLEMEMBER : native_scalar_function<IS_SRVROLEMEMBER> { IS_SRVROLEMEMBER() : base("IS_SRVROLEMEMBER") { } }
		public sealed class ISDATE : native_scalar_function<ISDATE> { ISDATE() : base("ISDATE") { } }
		public sealed class ISDATETIME : native_scalar_function<ISDATETIME> { ISDATETIME() : base("ISDATETIME") { } }
		public sealed class ISJSON : native_scalar_function<ISJSON> { ISJSON() : base("ISJSON") { } }
		public sealed class ISLOCKEDISMUSTCHANGE : native_scalar_function<ISLOCKEDISMUSTCHANGE> { ISLOCKEDISMUSTCHANGE() : base("IsLockedIsMustChange") { } }
		public sealed class ISNULL : native_scalar_function<ISNULL> { ISNULL() : base("ISNULL") { } }
		public sealed class ISNUMERIC : native_scalar_function<ISNUMERIC> { ISNUMERIC() : base("ISNUMERIC") { } }
		public sealed class JSON_QUERY : native_scalar_function<JSON_QUERY> { JSON_QUERY() : base("JSON_QUERY") { } }
		public sealed class JSON_VALUE : native_scalar_function<JSON_VALUE> { JSON_VALUE() : base("JSON_VALUE") { } }
		public sealed class KEY_GUID : native_scalar_function<KEY_GUID> { KEY_GUID() : base("Key_GUID") { } }
		public sealed class KEY_ID : native_scalar_function<KEY_ID> { KEY_ID() : base("Key_ID") { } }
		public sealed class KEY_NAME : native_scalar_function<KEY_NAME> { KEY_NAME() : base("KEY_NAME") { } }
		public sealed class LAG : native_scalar_function<LAG> { LAG() : base("LAG") { } }
		public sealed class LAST_VALUE : native_scalar_function<LAST_VALUE> { LAST_VALUE() : base("LAST_VALUE") { } }
		public sealed class LEAD : native_scalar_function<LEAD> { LEAD() : base("LEAD") { } }
		public sealed class LEFT : native_scalar_function<LEFT> { LEFT() : base("LEFT") { } }
		public sealed class LEN : native_scalar_function<LEN> { LEN() : base("LEN") { } }
		public sealed class LOCKOUTTIME : native_scalar_function<LOCKOUTTIME> { LOCKOUTTIME() : base("LockoutTime") { } }
		public sealed class LOG : native_scalar_function<LOG> { LOG() : base("LOG") { } }
		public sealed class LOG10 : native_scalar_function<LOG10> { LOG10() : base("LOG10") { } }
		public sealed class LOGINPROPERTY : native_scalar_function<LOGINPROPERTY> { LOGINPROPERTY() : base("LOGINPROPERTY") { } }
		public sealed class LOWER : native_scalar_function<LOWER> { LOWER() : base("LOWER") { } }
		public sealed class LTRIM : native_scalar_function<LTRIM> { LTRIM() : base("LTRIM") { } }
		public sealed class MAX : native_scalar_function<MAX> { MAX() : base("MAX") { } }
		public sealed class MIN : native_scalar_function<MIN> { MIN() : base("MIN") { } }
		public sealed class MIN_ACTIVE_ROWVERSION : native_scalar_function<MIN_ACTIVE_ROWVERSION> { MIN_ACTIVE_ROWVERSION() : base("MIN_ACTIVE_ROWVERSION") { } }
		public sealed class MONTH : native_scalar_function<MONTH> { MONTH() : base("MONTH") { } }
		public sealed class NCHAR : native_scalar_function<NCHAR> { NCHAR() : base("nchar") { } }
		public sealed class NEWID : native_scalar_function<NEWID> { NEWID() : base("NEWID") { } }
		public sealed class NEWSEQUENTIALID : native_scalar_function<NEWSEQUENTIALID> { NEWSEQUENTIALID() : base("NEWSEQUENTIALID") { } }
		public sealed class NEXT : native_scalar_function<NEXT> { NEXT() : base("NEXT") { } }
		public sealed class NEXT_VALUE : native_scalar_function<NEXT_VALUE> { NEXT_VALUE() : base("NEXT VALUE") { } }
		public sealed class NEXT_VALUE_FOR : native_scalar_function<NEXT_VALUE_FOR> { NEXT_VALUE_FOR() : base("NEXT VALUE FOR") { } }
		public sealed class NTILE : native_scalar_function<NTILE> { NTILE() : base("NTILE") { } }
		public sealed class OBJECT_DEFINITION : native_scalar_function<OBJECT_DEFINITION> { OBJECT_DEFINITION() : base("OBJECT_DEFINITION") { } }
		public sealed class OBJECT_ID : native_scalar_function<OBJECT_ID> { OBJECT_ID() : base("OBJECT_ID") { } }
		public sealed class OBJECT_NAME : native_scalar_function<OBJECT_NAME> { OBJECT_NAME() : base("OBJECT_NAME") { } }
		public sealed class OBJECT_SCHEMA_NAME : native_scalar_function<OBJECT_SCHEMA_NAME> { OBJECT_SCHEMA_NAME() : base("OBJECT_SCHEMA_NAME") { } }
		public sealed class OBJECTPROPERTY : native_scalar_function<OBJECTPROPERTY> { OBJECTPROPERTY() : base("OBJECTPROPERTY") { } }
		public sealed class OBJECTPROPERTYEX : native_scalar_function<OBJECTPROPERTYEX> { OBJECTPROPERTYEX() : base("OBJECTPROPERTYEX") { } }
		public sealed class OPENDATASOURCE : native_scalar_function<OPENDATASOURCE> { OPENDATASOURCE() : base("OPENDATASOURCE") { } }
		public sealed class OPENJSON : native_scalar_function<OPENJSON> { OPENJSON() : base("OPENJSON") { } }
		public sealed class OPENQUERY : native_scalar_function<OPENQUERY> { OPENQUERY() : base("OPENQUERY") { } }
		public sealed class OPENROWSET : native_scalar_function<OPENROWSET> { OPENROWSET() : base("OPENROWSET") { } }
		public sealed class OPENXML : native_scalar_function<OPENXML> { OPENXML() : base("OPENXML") { } }
		public sealed class ORIGINAL_DB_NAME : native_scalar_function<ORIGINAL_DB_NAME> { ORIGINAL_DB_NAME() : base("ORIGINAL_DB_NAME") { } }
		public sealed class ORIGINAL_LOGIN : native_scalar_function<ORIGINAL_LOGIN> { ORIGINAL_LOGIN() : base("ORIGINAL_LOGIN") { } }
		public sealed class PARSE : native_scalar_function<PARSE> { PARSE() : base("PARSE") { } }
		public sealed class PARSENAME : native_scalar_function<PARSENAME> { PARSENAME() : base("PARSENAME") { } }
		public sealed class PASSWORDHASH : native_scalar_function<PASSWORDHASH> { PASSWORDHASH() : base("PasswordHash") { } }
		public sealed class PASSWORDLASTSETTIME : native_scalar_function<PASSWORDLASTSETTIME> { PASSWORDLASTSETTIME() : base("PasswordLastSetTime") { } }
		public sealed class PATINDEX : native_scalar_function<PATINDEX> { PATINDEX() : base("PATINDEX") { } }
		public sealed class PERCENT_RANK : native_scalar_function<PERCENT_RANK> { PERCENT_RANK() : base("PERCENT_RANK") { } }
		public sealed class PERCENTILE_CONT : native_scalar_function<PERCENTILE_CONT> { PERCENTILE_CONT() : base("PERCENTILE_CONT") { } }
		public sealed class PERCENTILE_DISC : native_scalar_function<PERCENTILE_DISC> { PERCENTILE_DISC() : base("PERCENTILE_DISC") { } }
		public sealed class PERMISSIONS : native_scalar_function<PERMISSIONS> { PERMISSIONS() : base("PERMISSIONS") { } }
		public sealed class PI : native_scalar_function<PI> { PI() : base("PI") { } }
		public sealed class POWER : native_scalar_function<POWER> { POWER() : base("POWER") { } }
		public sealed class PUBLISHINGSERVERNAME : native_scalar_function<PUBLISHINGSERVERNAME> { PUBLISHINGSERVERNAME() : base("PUBLISHINGSERVERNAME") { } }
		public sealed class PWDCOMPARE : native_scalar_function<PWDCOMPARE> { PWDCOMPARE() : base("PWDCOMPARE") { } }
		public sealed class PWDENCRYPT : native_scalar_function<PWDENCRYPT> { PWDENCRYPT() : base("PWDENCRYPT") { } }
		public sealed class QUOTENAME : native_scalar_function<QUOTENAME> { QUOTENAME() : base("QUOTENAME") { } }
		public sealed class RADIANS : native_scalar_function<RADIANS> { RADIANS() : base("RADIANS") { } }
		public sealed class RAISERROR : native_scalar_function<RAISERROR> { RAISERROR() : base("RAISERROR") { } }
		public sealed class RAND : native_scalar_function<RAND> { RAND() : base("RAND") { } }
		public sealed class RANK : native_scalar_function<RANK> { RANK() : base("RANK") { } }
		public sealed class REPLACE : native_scalar_function<REPLACE> { REPLACE() : base("REPLACE") { } }
		public sealed class REPLICATE : native_scalar_function<REPLICATE> { REPLICATE() : base("REPLICATE") { } }
		public sealed class REVERSE : native_scalar_function<REVERSE> { REVERSE() : base("REVERSE") { } }
		public sealed class RIGHT : native_scalar_function<RIGHT> { RIGHT() : base("RIGHT") { } }
		public sealed class ROUND : native_scalar_function<ROUND> { ROUND() : base("ROUND") { } }
		public sealed class ROW_NUMBER : native_scalar_function<ROW_NUMBER> { ROW_NUMBER() : base("ROW_NUMBER") { } }
		public sealed class ROWCOUNT_BIG : native_scalar_function<ROWCOUNT_BIG> { ROWCOUNT_BIG() : base("ROWCOUNT_BIG") { } }
		public sealed class RTRIM : native_scalar_function<RTRIM> { RTRIM() : base("RTRIM") { } }
		public sealed class SCHEMA_ID : native_scalar_function<SCHEMA_ID> { SCHEMA_ID() : base("SCHEMA_ID") { } }
		public sealed class SCHEMA_NAME : native_scalar_function<SCHEMA_NAME> { SCHEMA_NAME() : base("SCHEMA_NAME") { } }
		public sealed class SCOPE_IDENTITY : native_scalar_function<SCOPE_IDENTITY> { SCOPE_IDENTITY() : base("SCOPE_IDENTITY") { } }
		public sealed class SERVERPROPERTY : native_scalar_function<SERVERPROPERTY> { SERVERPROPERTY() : base("SERVERPROPERTY") { } }
		public sealed class SESSION_USER : native_scalar_function<SESSION_USER> { SESSION_USER() : base("SESSION_USER") { } }
		public sealed class SESSIONPROPERTY : native_scalar_function<SESSIONPROPERTY> { SESSIONPROPERTY() : base("SESSIONPROPERTY") { } }
		public sealed class SIGN : native_scalar_function<SIGN> { SIGN() : base("SIGN") { } }
		public sealed class SIGNBYASYMKEY : native_scalar_function<SIGNBYASYMKEY> { SIGNBYASYMKEY() : base("SIGNBYASYMKEY") { } }
		public sealed class SIGNBYCERT : native_scalar_function<SIGNBYCERT> { SIGNBYCERT() : base("SIGNBYCERT") { } }
		public sealed class SIN : native_scalar_function<SIN> { SIN() : base("SIN") { } }
		public sealed class SMALLDATETIMEFROMPARTS : native_scalar_function<SMALLDATETIMEFROMPARTS> { SMALLDATETIMEFROMPARTS() : base("SMALLDATETIMEFROMPARTS") { } }
		public sealed class SOUNDEX : native_scalar_function<SOUNDEX> { SOUNDEX() : base("SOUNDEX") { } }
		public sealed class SPACE : native_scalar_function<SPACE> { SPACE() : base("SPACE") { } }
		public sealed class SQL_VARIANT_PROPERTY : native_scalar_function<SQL_VARIANT_PROPERTY> { SQL_VARIANT_PROPERTY() : base("SQL_VARIANT_PROPERTY") { } }
		public sealed class SQRT : native_scalar_function<SQRT> { SQRT() : base("SQRT") { } }
		public sealed class SQUARE : native_scalar_function<SQUARE> { SQUARE() : base("SQUARE") { } }
		public sealed class STATS_DATE : native_scalar_function<STATS_DATE> { STATS_DATE() : base("STATS_DATE") { } }
		public sealed class STDEV : native_scalar_function<STDEV> { STDEV() : base("STDEV") { } }
		public sealed class STDEVP : native_scalar_function<STDEVP> { STDEVP() : base("STDEVP") { } }
		public sealed class STR : native_scalar_function<STR> { STR() : base("STR") { } }
		public sealed class STRING_AGG : native_scalar_function<STRING_AGG> { STRING_AGG() : base("STRING_AGG") { } }
		public sealed class STRING_ESCAPE : native_scalar_function<STRING_ESCAPE> { STRING_ESCAPE() : base("STRING_ESCAPE") { } }
		public sealed class STRING_SPLIT : native_scalar_function<STRING_SPLIT> { STRING_SPLIT() : base("STRING_SPLIT") { } }
		public sealed class STUFF : native_scalar_function<STUFF> { STUFF() : base("STUFF") { } }
		public sealed class SUBSTRING : native_scalar_function<SUBSTRING> { SUBSTRING() : base("SUBSTRING") { } }
		public sealed class SUM : native_scalar_function<SUM> { SUM() : base("SUM") { } }
		public sealed class SUSER_ID : native_scalar_function<SUSER_ID> { SUSER_ID() : base("SUSER_ID") { } }
		public sealed class SUSER_NAME : native_scalar_function<SUSER_NAME> { SUSER_NAME() : base("SUSER_NAME") { } }
		public sealed class SUSER_SID : native_scalar_function<SUSER_SID> { SUSER_SID() : base("SUSER_SID") { } }
		public sealed class SUSER_SNAME : native_scalar_function<SUSER_SNAME> { SUSER_SNAME() : base("SUSER_SNAME") { } }
		public sealed class SWITCH_TZ : native_scalar_function<SWITCH_TZ> { SWITCH_TZ() : base("SWITCH_TZ") { } }
		public sealed class SWITCHTZ : native_scalar_function<SWITCHTZ> { SWITCHTZ() : base("SWITCHTZ") { } }
		public sealed class SYMKEYPROPERTY : native_scalar_function<SYMKEYPROPERTY> { SYMKEYPROPERTY() : base("SYMKEYPROPERTY") { } }
		public sealed class CURRENT_TRANSACTION_ID : native_scalar_function<CURRENT_TRANSACTION_ID> { CURRENT_TRANSACTION_ID() : base("sys.CURRENT_TRANSACTION_ID") { } }
		public sealed class SESSION_CONTEXT : native_scalar_function<SESSION_CONTEXT> { SESSION_CONTEXT() : base("sys.SESSION_CONTEXT") { } }
		public sealed class SYSDATETIME : native_scalar_function<SYSDATETIME> { SYSDATETIME() : base("SYSDATETIME") { } }
		public sealed class SYSDATETIMEOFFSET : native_scalar_function<SYSDATETIMEOFFSET> { SYSDATETIMEOFFSET() : base("SYSDATETIMEOFFSET") { } }
		public sealed class SYSTEM_USER : native_scalar_function<SYSTEM_USER> { SYSTEM_USER() : base("SYSTEM_USER") { } }
		public sealed class SYSUTCDATETIME : native_scalar_function<SYSUTCDATETIME> { SYSUTCDATETIME() : base("SYSUTCDATETIME") { } }
		public sealed class TAN : native_scalar_function<TAN> { TAN() : base("TAN") { } }
		public sealed class TERTIARY_WEIGHTS : native_scalar_function<TERTIARY_WEIGHTS> { TERTIARY_WEIGHTS() : base("TERTIARY_WEIGHTS") { } }
		public sealed class TEXTPTR : native_scalar_function<TEXTPTR> { TEXTPTR() : base("TEXTPTR") { } }
		public sealed class TEXTVALID : native_scalar_function<TEXTVALID> { TEXTVALID() : base("TEXTVALID") { } }
		public sealed class TIMEFROMPARTS : native_scalar_function<TIMEFROMPARTS> { TIMEFROMPARTS() : base("TIMEFROMPARTS") { } }
		public sealed class TO_DATETIMEOFFSET : native_scalar_function<TO_DATETIMEOFFSET> { TO_DATETIMEOFFSET() : base("TO_DATETIMEOFFSET") { } }
		public sealed class TRANSLATE : native_scalar_function<TRANSLATE> { TRANSLATE() : base("TRANSLATE") { } }
		public sealed class TRIGGER_NESTLEVEL : native_scalar_function<TRIGGER_NESTLEVEL> { TRIGGER_NESTLEVEL() : base("TRIGGER_NESTLEVEL") { } }
		public sealed class TRIM : native_scalar_function<TRIM> { TRIM() : base("TRIM") { } }
		public sealed class TRY_CAST : native_scalar_function<TRY_CAST> { TRY_CAST() : base("TRY_CAST") { } }
		public sealed class TRY_CONVERT : native_scalar_function<TRY_CONVERT> { TRY_CONVERT() : base("TRY_CONVERT") { } }
		public sealed class TRY_PARSE : native_scalar_function<TRY_PARSE> { TRY_PARSE() : base("TRY_PARSE") { } }
		public sealed class TSQL : native_scalar_function<TSQL> { TSQL() : base("TSQL") { } }
		public sealed class TYPE_ID : native_scalar_function<TYPE_ID> { TYPE_ID() : base("TYPE_ID") { } }
		public sealed class TYPE_NAME : native_scalar_function<TYPE_NAME> { TYPE_NAME() : base("TYPE_NAME") { } }
		public sealed class TYPEPROPERTY : native_scalar_function<TYPEPROPERTY> { TYPEPROPERTY() : base("TYPEPROPERTY") { } }
		public sealed class UNICODE : native_scalar_function<UNICODE> { UNICODE() : base("UNICODE") { } }
		public sealed class UPPER : native_scalar_function<UPPER> { UPPER() : base("UPPER") { } }
		public sealed class USER : native_scalar_function<USER> { USER() : base("USER") { } }
		public sealed class USER_ID : native_scalar_function<USER_ID> { USER_ID() : base("USER_ID") { } }
		public sealed class USER_NAME : native_scalar_function<USER_NAME> { USER_NAME() : base("USER_NAME") { } }
		public sealed class VAR : native_scalar_function<VAR> { VAR() : base("VAR") { } }
		public sealed class VARP : native_scalar_function<VARP> { VARP() : base("VARP") { } }
		public sealed class VERIFYSIGNEDBYASYMKEY : native_scalar_function<VERIFYSIGNEDBYASYMKEY> { VERIFYSIGNEDBYASYMKEY() : base("VERIFYSIGNEDBYASYMKEY") { } }
		public sealed class VERIFYSIGNEDBYCERT : native_scalar_function<VERIFYSIGNEDBYCERT> { VERIFYSIGNEDBYCERT() : base("VERIFYSIGNEDBYCERT") { } }
		public sealed class XACT_STATE : native_scalar_function<XACT_STATE> { XACT_STATE() : base("XACT_STATE") { } }
		public sealed class YEAR : native_scalar_function<YEAR> { YEAR() : base("YEAR") { } }
	}

	public class SqlFunctions : TypedItemList<SqlFunctions, sxc.native_function>
	{
		public static readonly T.PARTITION PARTITION = T.PARTITION.get();
		public static readonly T.@CONNECTIONS @CONNECTIONS = T.@CONNECTIONS.get();
		public static readonly T.@CPU_BUSY @CPU_BUSY = T.@CPU_BUSY.get();
		public static readonly T.@CURSOR_ROWS @CURSOR_ROWS = T.@CURSOR_ROWS.get();
		public static readonly T.@DATEFIRST @DATEFIRST = T.@DATEFIRST.get();
		public static readonly T.@DBTS @DBTS = T.@DBTS.get();
		public static readonly T.@ERROR @ERROR = T.@ERROR.get();
		public static readonly T.@FETCH_STATUS @FETCH_STATUS = T.@FETCH_STATUS.get();
		public static readonly T.@IDENTITY @IDENTITY = T.@IDENTITY.get();
		public static readonly T.@IDLE @IDLE = T.@IDLE.get();
		public static readonly T.@IO_BUSY @IO_BUSY = T.@IO_BUSY.get();
		public static readonly T.@LANGID @LANGID = T.@LANGID.get();
		public static readonly T.@LANGUAGE @LANGUAGE = T.@LANGUAGE.get();
		public static readonly T.@LOCK_TIMEOUT @LOCK_TIMEOUT = T.@LOCK_TIMEOUT.get();
		public static readonly T.@MAX_CONNECTIONS @MAX_CONNECTIONS = T.@MAX_CONNECTIONS.get();
		public static readonly T.@MAX_PRECISION @MAX_PRECISION = T.@MAX_PRECISION.get();
		public static readonly T.@NESTLEVEL @NESTLEVEL = T.@NESTLEVEL.get();
		public static readonly T.@OPTIONS @OPTIONS = T.@OPTIONS.get();
		public static readonly T.@PACK_RECEIVED @PACK_RECEIVED = T.@PACK_RECEIVED.get();
		public static readonly T.@PACK_SENT @PACK_SENT = T.@PACK_SENT.get();
		public static readonly T.@PACKET_ERRORS @PACKET_ERRORS = T.@PACKET_ERRORS.get();
		public static readonly T.@PROCID @PROCID = T.@PROCID.get();
		public static readonly T.@REMSERVER @REMSERVER = T.@REMSERVER.get();
		public static readonly T.@ROWCOUNT @ROWCOUNT = T.@ROWCOUNT.get();
		public static readonly T.@SERVERNAME @SERVERNAME = T.@SERVERNAME.get();
		public static readonly T.@SERVICENAME @SERVICENAME = T.@SERVICENAME.get();
		public static readonly T.@SPID @SPID = T.@SPID.get();
		public static readonly T.@TEXTSIZE @TEXTSIZE = T.@TEXTSIZE.get();
		public static readonly T.@TIMETICKS @TIMETICKS = T.@TIMETICKS.get();
		public static readonly T.@TOTAL_ERRORS @TOTAL_ERRORS = T.@TOTAL_ERRORS.get();
		public static readonly T.@TOTAL_READ @TOTAL_READ = T.@TOTAL_READ.get();
		public static readonly T.@TOTAL_WRITE @TOTAL_WRITE = T.@TOTAL_WRITE.get();
		public static readonly T.@TRANCOUNT @TRANCOUNT = T.@TRANCOUNT.get();
		public static readonly T.@VERSION @VERSION = T.@VERSION.get();
		public static readonly T.ABS ABS = T.ABS.get();
		public static readonly T.ACOS ACOS = T.ACOS.get();
		public static readonly T.APP_NAME APP_NAME = T.APP_NAME.get();
		public static readonly T.APPLOCK_MODE APPLOCK_MODE = T.APPLOCK_MODE.get();
		public static readonly T.APPLOCK_TEST APPLOCK_TEST = T.APPLOCK_TEST.get();
		public static readonly T.ASCII ASCII = T.ASCII.get();
		public static readonly T.ASIN ASIN = T.ASIN.get();
		public static readonly T.ASSEMBLYPROPERTY ASSEMBLYPROPERTY = T.ASSEMBLYPROPERTY.get();
		public static readonly T.ASYMKEY_ID ASYMKEY_ID = T.ASYMKEY_ID.get();
		public static readonly T.ASYMKEYPROPERTY ASYMKEYPROPERTY = T.ASYMKEYPROPERTY.get();
		public static readonly T.ATAN ATAN = T.ATAN.get();
		public static readonly T.ATN2 ATN2 = T.ATN2.get();
		public static readonly T.AVG AVG = T.AVG.get();
		public static readonly T.BADPASSWORDCOUNT BADPASSWORDCOUNT = T.BADPASSWORDCOUNT.get();
		public static readonly T.BADPASSWORDTIME BADPASSWORDTIME = T.BADPASSWORDTIME.get();
		public static readonly T.BINARY_CHECKSUM BINARY_CHECKSUM = T.BINARY_CHECKSUM.get();
		public static readonly T.CAST CAST = T.CAST.get();
		public static readonly T.CEILING CEILING = T.CEILING.get();
		public static readonly T.CERT_ID CERT_ID = T.CERT_ID.get();
		public static readonly T.CERTENCODED CERTENCODED = T.CERTENCODED.get();
		public static readonly T.CERTPRIVATEKEY CERTPRIVATEKEY = T.CERTPRIVATEKEY.get();
		public static readonly T.CERTPROPERTY CERTPROPERTY = T.CERTPROPERTY.get();
		public static readonly T.CHAR CHAR = T.CHAR.get();
		public static readonly T.CHARINDEX CHARINDEX = T.CHARINDEX.get();
		public static readonly T.CHECKSUM CHECKSUM = T.CHECKSUM.get();
		public static readonly T.CHECKSUM_AGG CHECKSUM_AGG = T.CHECKSUM_AGG.get();
		public static readonly T.CHOOSE CHOOSE = T.CHOOSE.get();
		public static readonly T.COL_LENGTH COL_LENGTH = T.COL_LENGTH.get();
		public static readonly T.COL_NAME COL_NAME = T.COL_NAME.get();
		public static readonly T.COLLATIONPROPERTY COLLATIONPROPERTY = T.COLLATIONPROPERTY.get();
		public static readonly T.COLUMNPROPERTY COLUMNPROPERTY = T.COLUMNPROPERTY.get();
		public static readonly T.COLUMNS_UPDATED COLUMNS_UPDATED = T.COLUMNS_UPDATED.get();
		public static readonly T.COMPRESS COMPRESS = T.COMPRESS.get();
		public static readonly T.CONCAT CONCAT = T.CONCAT.get();
		public static readonly T.CONCAT_WS CONCAT_WS = T.CONCAT_WS.get();
		public static readonly T.CONNECTIONPROPERTY CONNECTIONPROPERTY = T.CONNECTIONPROPERTY.get();
		public static readonly T.CONTEXT_INFO CONTEXT_INFO = T.CONTEXT_INFO.get();
		public static readonly T.CONVERT CONVERT = T.CONVERT.get();
		public static readonly T.COS COS = T.COS.get();
		public static readonly T.COT COT = T.COT.get();
		public static readonly T.COUNT COUNT = T.COUNT.get();
		public static readonly T.COUNT_BIG COUNT_BIG = T.COUNT_BIG.get();
		public static readonly T.CRYPT_GEN_RANDOM CRYPT_GEN_RANDOM = T.CRYPT_GEN_RANDOM.get();
		public static readonly T.CUME_DIST CUME_DIST = T.CUME_DIST.get();
		public static readonly T.CURRENT_REQUEST_ID CURRENT_REQUEST_ID = T.CURRENT_REQUEST_ID.get();
		public static readonly T.CURRENT_TIMESTAMP CURRENT_TIMESTAMP = T.CURRENT_TIMESTAMP.get();
		public static readonly T.CURRENT_USER CURRENT_USER = T.CURRENT_USER.get();
		public static readonly T.CURSOR_STATUS CURSOR_STATUS = T.CURSOR_STATUS.get();
		public static readonly T.DATABASE_PRINCIPAL_ID DATABASE_PRINCIPAL_ID = T.DATABASE_PRINCIPAL_ID.get();
		public static readonly T.DATABASEPROPERTYEX DATABASEPROPERTYEX = T.DATABASEPROPERTYEX.get();
		public static readonly T.DATALENGTH DATALENGTH = T.DATALENGTH.get();
		public static readonly T.DATE_FORMAT DATE_FORMAT = T.DATE_FORMAT.get();
		public static readonly T.DATEADD DATEADD = T.DATEADD.get();
		public static readonly T.DATEDIFF DATEDIFF = T.DATEDIFF.get();
		public static readonly T.DATEDIFF_BIG DATEDIFF_BIG = T.DATEDIFF_BIG.get();
		public static readonly T.DATEFROMPARTS DATEFROMPARTS = T.DATEFROMPARTS.get();
		public static readonly T.DATENAME DATENAME = T.DATENAME.get();
		public static readonly T.DATEPART DATEPART = T.DATEPART.get();
		public static readonly T.DATETIME2FROMPARTS DATETIME2FROMPARTS = T.DATETIME2FROMPARTS.get();
		public static readonly T.DATETIMEFROMPARTS DATETIMEFROMPARTS = T.DATETIMEFROMPARTS.get();
		public static readonly T.DATETIMEOFFSETFROMPARTS DATETIMEOFFSETFROMPARTS = T.DATETIMEOFFSETFROMPARTS.get();
		public static readonly T.DAY DAY = T.DAY.get();
		public static readonly T.DB_ID DB_ID = T.DB_ID.get();
		public static readonly T.DB_NAME DB_NAME = T.DB_NAME.get();
		public static readonly T.DECOMPRESS DECOMPRESS = T.DECOMPRESS.get();
		public static readonly T.DECRYPTBYASYMKEY DECRYPTBYASYMKEY = T.DECRYPTBYASYMKEY.get();
		public static readonly T.DECRYPTBYCERT DECRYPTBYCERT = T.DECRYPTBYCERT.get();
		public static readonly T.DECRYPTBYKEY DECRYPTBYKEY = T.DECRYPTBYKEY.get();
		public static readonly T.DECRYPTBYKEYAUTOASYMKEY DECRYPTBYKEYAUTOASYMKEY = T.DECRYPTBYKEYAUTOASYMKEY.get();
		public static readonly T.DECRYPTBYKEYAUTOCERT DECRYPTBYKEYAUTOCERT = T.DECRYPTBYKEYAUTOCERT.get();
		public static readonly T.DECRYPTBYPASSPHRASE DECRYPTBYPASSPHRASE = T.DECRYPTBYPASSPHRASE.get();
		public static readonly T.DEGREES DEGREES = T.DEGREES.get();
		public static readonly T.DENSE_RANK DENSE_RANK = T.DENSE_RANK.get();
		public static readonly T.DIFFERENCE DIFFERENCE = T.DIFFERENCE.get();
		public static readonly T.ENCRYPTBYASYMKEY ENCRYPTBYASYMKEY = T.ENCRYPTBYASYMKEY.get();
		public static readonly T.ENCRYPTBYCERT ENCRYPTBYCERT = T.ENCRYPTBYCERT.get();
		public static readonly T.ENCRYPTBYKEY ENCRYPTBYKEY = T.ENCRYPTBYKEY.get();
		public static readonly T.ENCRYPTBYPASSPHRASE ENCRYPTBYPASSPHRASE = T.ENCRYPTBYPASSPHRASE.get();
		public static readonly T.EOMONTH EOMONTH = T.EOMONTH.get();
		public static readonly T.ERROR_LINE ERROR_LINE = T.ERROR_LINE.get();
		public static readonly T.ERROR_MESSAGE ERROR_MESSAGE = T.ERROR_MESSAGE.get();
		public static readonly T.ERROR_NUMBER ERROR_NUMBER = T.ERROR_NUMBER.get();
		public static readonly T.ERROR_PROCEDURE ERROR_PROCEDURE = T.ERROR_PROCEDURE.get();
		public static readonly T.ERROR_SEVERITY ERROR_SEVERITY = T.ERROR_SEVERITY.get();
		public static readonly T.ERROR_STATE ERROR_STATE = T.ERROR_STATE.get();
		public static readonly T.EVENTDATA EVENTDATA = T.EVENTDATA.get();
		public static readonly T.EXP EXP = T.EXP.get();
		public static readonly T.FILE_ID FILE_ID = T.FILE_ID.get();
		public static readonly T.FILE_IDEX FILE_IDEX = T.FILE_IDEX.get();
		public static readonly T.FILE_NAME FILE_NAME = T.FILE_NAME.get();
		public static readonly T.FILEGROUP_ID FILEGROUP_ID = T.FILEGROUP_ID.get();
		public static readonly T.FILEGROUP_NAME FILEGROUP_NAME = T.FILEGROUP_NAME.get();
		public static readonly T.FILEGROUPPROPERTY FILEGROUPPROPERTY = T.FILEGROUPPROPERTY.get();
		public static readonly T.FILEPROPERTY FILEPROPERTY = T.FILEPROPERTY.get();
		public static readonly T.FILETABLEROOTPATH FILETABLEROOTPATH = T.FILETABLEROOTPATH.get();
		public static readonly T.FIRST_VALUE FIRST_VALUE = T.FIRST_VALUE.get();
		public static readonly T.FLOOR FLOOR = T.FLOOR.get();
		public static readonly T.FN_EVENT_DATA FN_EVENT_DATA = T.FN_EVENT_DATA.get();
		public static readonly T.FORMAT FORMAT = T.FORMAT.get();
		public static readonly T.FORMATMESSAGE FORMATMESSAGE = T.FORMATMESSAGE.get();
		public static readonly T.FULLTEXTCATALOGPROPERTY FULLTEXTCATALOGPROPERTY = T.FULLTEXTCATALOGPROPERTY.get();
		public static readonly T.FULLTEXTSERVICEPROPERTY FULLTEXTSERVICEPROPERTY = T.FULLTEXTSERVICEPROPERTY.get();
		public static readonly T.GET_FILESTREAM_TRANSACTION_CONTEXT GET_FILESTREAM_TRANSACTION_CONTEXT = T.GET_FILESTREAM_TRANSACTION_CONTEXT.get();
		public static readonly T.GETANSINULL GETANSINULL = T.GETANSINULL.get();
		public static readonly T.GETDATE GETDATE = T.GETDATE.get();
		public static readonly T.GETUTCDATE GETUTCDATE = T.GETUTCDATE.get();
		public static readonly T.GROUPING GROUPING = T.GROUPING.get();
		public static readonly T.GROUPING_ID GROUPING_ID = T.GROUPING_ID.get();
		public static readonly T.HAS_DBACCESS HAS_DBACCESS = T.HAS_DBACCESS.get();
		public static readonly T.HAS_PERMS_BY_NAME HAS_PERMS_BY_NAME = T.HAS_PERMS_BY_NAME.get();
		public static readonly T.HASHBYTES HASHBYTES = T.HASHBYTES.get();
		public static readonly T.HISTORYLENGTHISEXPIRED HISTORYLENGTHISEXPIRED = T.HISTORYLENGTHISEXPIRED.get();
		public static readonly T.HOST_ID HOST_ID = T.HOST_ID.get();
		public static readonly T.HOST_NAME HOST_NAME = T.HOST_NAME.get();
		public static readonly T.IDENT_CURRENT IDENT_CURRENT = T.IDENT_CURRENT.get();
		public static readonly T.IDENT_INCR IDENT_INCR = T.IDENT_INCR.get();
		public static readonly T.IDENT_SEED IDENT_SEED = T.IDENT_SEED.get();
		public static readonly T.IIF IIF = T.IIF.get();
		public static readonly T.INDEX_COL INDEX_COL = T.INDEX_COL.get();
		public static readonly T.INDEXKEY_PROPERTY INDEXKEY_PROPERTY = T.INDEXKEY_PROPERTY.get();
		public static readonly T.INDEXPROPERTY INDEXPROPERTY = T.INDEXPROPERTY.get();
		public static readonly T.IS_MEMBER IS_MEMBER = T.IS_MEMBER.get();
		public static readonly T.IS_OBJECTSIGNED IS_OBJECTSIGNED = T.IS_OBJECTSIGNED.get();
		public static readonly T.IS_ROLEMEMBER IS_ROLEMEMBER = T.IS_ROLEMEMBER.get();
		public static readonly T.IS_SRVROLEMEMBER IS_SRVROLEMEMBER = T.IS_SRVROLEMEMBER.get();
		public static readonly T.ISDATE ISDATE = T.ISDATE.get();
		public static readonly T.ISDATETIME ISDATETIME = T.ISDATETIME.get();
		public static readonly T.ISJSON ISJSON = T.ISJSON.get();
		public static readonly T.ISLOCKEDISMUSTCHANGE ISLOCKEDISMUSTCHANGE = T.ISLOCKEDISMUSTCHANGE.get();
		public static readonly T.ISNULL ISNULL = T.ISNULL.get();
		public static readonly T.ISNUMERIC ISNUMERIC = T.ISNUMERIC.get();
		public static readonly T.JSON_QUERY JSON_QUERY = T.JSON_QUERY.get();
		public static readonly T.JSON_VALUE JSON_VALUE = T.JSON_VALUE.get();
		public static readonly T.KEY_GUID KEY_GUID = T.KEY_GUID.get();
		public static readonly T.KEY_ID KEY_ID = T.KEY_ID.get();
		public static readonly T.KEY_NAME KEY_NAME = T.KEY_NAME.get();
		public static readonly T.LAG LAG = T.LAG.get();
		public static readonly T.LAST_VALUE LAST_VALUE = T.LAST_VALUE.get();
		public static readonly T.LEAD LEAD = T.LEAD.get();
		public static readonly T.LEFT LEFT = T.LEFT.get();
		public static readonly T.LEN LEN = T.LEN.get();
		public static readonly T.LOCKOUTTIME LOCKOUTTIME = T.LOCKOUTTIME.get();
		public static readonly T.LOG LOG = T.LOG.get();
		public static readonly T.LOG10 LOG10 = T.LOG10.get();
		public static readonly T.LOGINPROPERTY LOGINPROPERTY = T.LOGINPROPERTY.get();
		public static readonly T.LOWER LOWER = T.LOWER.get();
		public static readonly T.LTRIM LTRIM = T.LTRIM.get();
		public static readonly T.MAX MAX = T.MAX.get();
		public static readonly T.MIN MIN = T.MIN.get();
		public static readonly T.MIN_ACTIVE_ROWVERSION MIN_ACTIVE_ROWVERSION = T.MIN_ACTIVE_ROWVERSION.get();
		public static readonly T.MONTH MONTH = T.MONTH.get();
		public static readonly T.NCHAR NCHAR = T.NCHAR.get();
		public static readonly T.NEWID NEWID = T.NEWID.get();
		public static readonly T.NEWSEQUENTIALID NEWSEQUENTIALID = T.NEWSEQUENTIALID.get();
		public static readonly T.NEXT NEXT = T.NEXT.get();
		public static readonly T.NEXT_VALUE NEXT_VALUE = T.NEXT_VALUE.get();
		public static readonly T.NEXT_VALUE_FOR NEXT_VALUE_FOR = T.NEXT_VALUE_FOR.get();
		public static readonly T.NTILE NTILE = T.NTILE.get();
		public static readonly T.OBJECT_DEFINITION OBJECT_DEFINITION = T.OBJECT_DEFINITION.get();
		public static readonly T.OBJECT_ID OBJECT_ID = T.OBJECT_ID.get();
		public static readonly T.OBJECT_NAME OBJECT_NAME = T.OBJECT_NAME.get();
		public static readonly T.OBJECT_SCHEMA_NAME OBJECT_SCHEMA_NAME = T.OBJECT_SCHEMA_NAME.get();
		public static readonly T.OBJECTPROPERTY OBJECTPROPERTY = T.OBJECTPROPERTY.get();
		public static readonly T.OBJECTPROPERTYEX OBJECTPROPERTYEX = T.OBJECTPROPERTYEX.get();
		public static readonly T.OPENDATASOURCE OPENDATASOURCE = T.OPENDATASOURCE.get();
		public static readonly T.OPENJSON OPENJSON = T.OPENJSON.get();
		public static readonly T.OPENQUERY OPENQUERY = T.OPENQUERY.get();
		public static readonly T.OPENROWSET OPENROWSET = T.OPENROWSET.get();
		public static readonly T.OPENXML OPENXML = T.OPENXML.get();
		public static readonly T.ORIGINAL_DB_NAME ORIGINAL_DB_NAME = T.ORIGINAL_DB_NAME.get();
		public static readonly T.ORIGINAL_LOGIN ORIGINAL_LOGIN = T.ORIGINAL_LOGIN.get();
		public static readonly T.PARSE PARSE = T.PARSE.get();
		public static readonly T.PARSENAME PARSENAME = T.PARSENAME.get();
		public static readonly T.PASSWORDHASH PASSWORDHASH = T.PASSWORDHASH.get();
		public static readonly T.PASSWORDLASTSETTIME PASSWORDLASTSETTIME = T.PASSWORDLASTSETTIME.get();
		public static readonly T.PATINDEX PATINDEX = T.PATINDEX.get();
		public static readonly T.PERCENT_RANK PERCENT_RANK = T.PERCENT_RANK.get();
		public static readonly T.PERCENTILE_CONT PERCENTILE_CONT = T.PERCENTILE_CONT.get();
		public static readonly T.PERCENTILE_DISC PERCENTILE_DISC = T.PERCENTILE_DISC.get();
		public static readonly T.PERMISSIONS PERMISSIONS = T.PERMISSIONS.get();
		public static readonly T.PI PI = T.PI.get();
		public static readonly T.POWER POWER = T.POWER.get();
		public static readonly T.PUBLISHINGSERVERNAME PUBLISHINGSERVERNAME = T.PUBLISHINGSERVERNAME.get();
		public static readonly T.PWDCOMPARE PWDCOMPARE = T.PWDCOMPARE.get();
		public static readonly T.PWDENCRYPT PWDENCRYPT = T.PWDENCRYPT.get();
		public static readonly T.QUOTENAME QUOTENAME = T.QUOTENAME.get();
		public static readonly T.RADIANS RADIANS = T.RADIANS.get();
		public static readonly T.RAISERROR RAISERROR = T.RAISERROR.get();
		public static readonly T.RAND RAND = T.RAND.get();
		public static readonly T.RANK RANK = T.RANK.get();
		public static readonly T.REPLACE REPLACE = T.REPLACE.get();
		public static readonly T.REPLICATE REPLICATE = T.REPLICATE.get();
		public static readonly T.REVERSE REVERSE = T.REVERSE.get();
		public static readonly T.RIGHT RIGHT = T.RIGHT.get();
		public static readonly T.ROUND ROUND = T.ROUND.get();
		public static readonly T.ROW_NUMBER ROW_NUMBER = T.ROW_NUMBER.get();
		public static readonly T.ROWCOUNT_BIG ROWCOUNT_BIG = T.ROWCOUNT_BIG.get();
		public static readonly T.RTRIM RTRIM = T.RTRIM.get();
		public static readonly T.SCHEMA_ID SCHEMA_ID = T.SCHEMA_ID.get();
		public static readonly T.SCHEMA_NAME SCHEMA_NAME = T.SCHEMA_NAME.get();
		public static readonly T.SCOPE_IDENTITY SCOPE_IDENTITY = T.SCOPE_IDENTITY.get();
		public static readonly T.SERVERPROPERTY SERVERPROPERTY = T.SERVERPROPERTY.get();
		public static readonly T.SESSION_USER SESSION_USER = T.SESSION_USER.get();
		public static readonly T.SESSIONPROPERTY SESSIONPROPERTY = T.SESSIONPROPERTY.get();
		public static readonly T.SIGN SIGN = T.SIGN.get();
		public static readonly T.SIGNBYASYMKEY SIGNBYASYMKEY = T.SIGNBYASYMKEY.get();
		public static readonly T.SIGNBYCERT SIGNBYCERT = T.SIGNBYCERT.get();
		public static readonly T.SIN SIN = T.SIN.get();
		public static readonly T.SMALLDATETIMEFROMPARTS SMALLDATETIMEFROMPARTS = T.SMALLDATETIMEFROMPARTS.get();
		public static readonly T.SOUNDEX SOUNDEX = T.SOUNDEX.get();
		public static readonly T.SPACE SPACE = T.SPACE.get();
		public static readonly T.SQL_VARIANT_PROPERTY SQL_VARIANT_PROPERTY = T.SQL_VARIANT_PROPERTY.get();
		public static readonly T.SQRT SQRT = T.SQRT.get();
		public static readonly T.SQUARE SQUARE = T.SQUARE.get();
		public static readonly T.STATS_DATE STATS_DATE = T.STATS_DATE.get();
		public static readonly T.STDEV STDEV = T.STDEV.get();
		public static readonly T.STDEVP STDEVP = T.STDEVP.get();
		public static readonly T.STR STR = T.STR.get();
		public static readonly T.STRING_AGG STRING_AGG = T.STRING_AGG.get();
		public static readonly T.STRING_ESCAPE STRING_ESCAPE = T.STRING_ESCAPE.get();
		public static readonly T.STRING_SPLIT STRING_SPLIT = T.STRING_SPLIT.get();
		public static readonly T.STUFF STUFF = T.STUFF.get();
		public static readonly T.SUBSTRING SUBSTRING = T.SUBSTRING.get();
		public static readonly T.SUM SUM = T.SUM.get();
		public static readonly T.SUSER_ID SUSER_ID = T.SUSER_ID.get();
		public static readonly T.SUSER_NAME SUSER_NAME = T.SUSER_NAME.get();
		public static readonly T.SUSER_SID SUSER_SID = T.SUSER_SID.get();
		public static readonly T.SUSER_SNAME SUSER_SNAME = T.SUSER_SNAME.get();
		public static readonly T.SWITCH_TZ SWITCH_TZ = T.SWITCH_TZ.get();
		public static readonly T.SWITCHTZ SWITCHTZ = T.SWITCHTZ.get();
		public static readonly T.SYMKEYPROPERTY SYMKEYPROPERTY = T.SYMKEYPROPERTY.get();
		public static readonly T.CURRENT_TRANSACTION_ID CURRENT_TRANSACTION_ID = T.CURRENT_TRANSACTION_ID.get();
		public static readonly T.SESSION_CONTEXT SESSION_CONTEXT = T.SESSION_CONTEXT.get();
		public static readonly T.SYSDATETIME SYSDATETIME = T.SYSDATETIME.get();
		public static readonly T.SYSDATETIMEOFFSET SYSDATETIMEOFFSET = T.SYSDATETIMEOFFSET.get();
		public static readonly T.SYSTEM_USER SYSTEM_USER = T.SYSTEM_USER.get();
		public static readonly T.SYSUTCDATETIME SYSUTCDATETIME = T.SYSUTCDATETIME.get();
		public static readonly T.TAN TAN = T.TAN.get();
		public static readonly T.TERTIARY_WEIGHTS TERTIARY_WEIGHTS = T.TERTIARY_WEIGHTS.get();
		public static readonly T.TEXTPTR TEXTPTR = T.TEXTPTR.get();
		public static readonly T.TEXTVALID TEXTVALID = T.TEXTVALID.get();
		public static readonly T.TIMEFROMPARTS TIMEFROMPARTS = T.TIMEFROMPARTS.get();
		public static readonly T.TO_DATETIMEOFFSET TO_DATETIMEOFFSET = T.TO_DATETIMEOFFSET.get();
		public static readonly T.TRANSLATE TRANSLATE = T.TRANSLATE.get();
		public static readonly T.TRIGGER_NESTLEVEL TRIGGER_NESTLEVEL = T.TRIGGER_NESTLEVEL.get();
		public static readonly T.TRIM TRIM = T.TRIM.get();
		public static readonly T.TRY_CAST TRY_CAST = T.TRY_CAST.get();
		public static readonly T.TRY_CONVERT TRY_CONVERT = T.TRY_CONVERT.get();
		public static readonly T.TRY_PARSE TRY_PARSE = T.TRY_PARSE.get();
		public static readonly T.TSQL TSQL = T.TSQL.get();
		public static readonly T.TYPE_ID TYPE_ID = T.TYPE_ID.get();
		public static readonly T.TYPE_NAME TYPE_NAME = T.TYPE_NAME.get();
		public static readonly T.TYPEPROPERTY TYPEPROPERTY = T.TYPEPROPERTY.get();
		public static readonly T.UNICODE UNICODE = T.UNICODE.get();
		public static readonly T.UPPER UPPER = T.UPPER.get();
		public static readonly T.USER USER = T.USER.get();
		public static readonly T.USER_ID USER_ID = T.USER_ID.get();
		public static readonly T.USER_NAME USER_NAME = T.USER_NAME.get();
		public static readonly T.VAR VAR = T.VAR.get();
		public static readonly T.VARP VARP = T.VARP.get();
		public static readonly T.VERIFYSIGNEDBYASYMKEY VERIFYSIGNEDBYASYMKEY = T.VERIFYSIGNEDBYASYMKEY.get();
		public static readonly T.VERIFYSIGNEDBYCERT VERIFYSIGNEDBYCERT = T.VERIFYSIGNEDBYCERT.get();
		public static readonly T.XACT_STATE XACT_STATE = T.XACT_STATE.get();
		public static readonly T.YEAR YEAR = T.YEAR.get();
	}

}
