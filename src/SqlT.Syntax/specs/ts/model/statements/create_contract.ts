type create_message_type_syntax = 
    `CREATE CONTRACT contract_name  
   [ AUTHORIZATION owner_name ]  
      (  {   { message_type_name | [ DEFAULT ] }  
          SENT BY { INITIATOR | TARGET | ANY }   
       } [ ,...n] )`

type contract_name = identifier
type owner_name = identifier

type contract_auth =
    kw.AUTHORIZATION & owner_name

type contract_message_type =
    | message_type_name
    | kw.DEFAULT

type contract_message_sender =
    | kw.INITIATOR
    | kw.TARGET
    | kw.DEFAULT

type contract_message_spec =
    contract_message_type & contract_message_sender


type create_contract =
    kw.CREATE & kw.CONTRACT & contract_name & contract_auth & one_or_more<contract_message_spec>
