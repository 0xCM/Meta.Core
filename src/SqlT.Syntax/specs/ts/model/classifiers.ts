namespace c 
{
    export interface syntax_model {}
    
    export interface sql_type
        extends syntax_model  { }


    
    export interface sql_operator
        extends syntax_model { }

    export interface syntax_list<T extends syntax_model>
        extends syntax_model { }

    export interface expression {

    }

    export interface literal_expression extends expression {

    }

}