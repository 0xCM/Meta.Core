var create_message_type_syntax_ref = [
    'https://docs.microsoft.com/en-us/sql/t-sql/statements/create-message-type-transact-sql',
    `CREATE MESSAGE TYPE message_type_name
        [ AUTHORIZATION owner_name ]
        [ VALIDATION = {  NONE
                        | EMPTY
                        | WELL_FORMED_XML
                        | VALID_XML WITH SCHEMA COLLECTION schema_collection_name
                       } ]`
    ]


type message_type_name = identifier    
type schema_collection_name = identifier

type message_type_auth =
    [kw.AUTHORIZATION,  owner_name]

type message_type_validation =
    | kw.NONE
    | kw.EMPTY
    | kw.WELL_FORMED_XML
    | [kw.VALID_XML , kw.WITH , kw.SCHEMA , kw.COLLECTION , schema_collection_name]
    
type create_message_type =
    [message_type_name,  message_type_auth | undefined, message_type_validation | undefined]
    
    
