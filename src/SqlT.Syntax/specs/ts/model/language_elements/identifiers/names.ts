
type column_name = identifier
    
type column_list = zero_or_more<column_name>

type schema_name = identifier

type server_name = identifier

type unqualified_database_name = identifier

type qualified_database_name = [server_name, unqualified_database_name]

type database_name =
    | unqualified_database_name
    | qualified_database_name

type unqualified_object_name = identifier

type schema_qualified_object_name 
    = [schema_name, unqualified_object_name]

type database_qualified_object_name 
    = [unqualified_database_name, schema_name, unqualified_object_name]

type server_qualified_object_name 
    = [server_name, unqualified_database_name, schema_name, unqualified_object_name]

type object_name =
    | unqualified_database_name
    | schema_qualified_object_name
    | database_qualified_object_name
    | server_qualified_object_name