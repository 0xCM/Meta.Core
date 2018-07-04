// See: https://docs.microsoft.com/en-us/sql/t-sql/language-elements/expressions-transact-sql

    import a = atoms
    import xpr = expressions
    import op = operators
    import kw = keywords

    class factory 
    {

        static left_paren() : a.left_paren { return "("; }
        static right_paren() : a.right_paren { return ")"; }
        static single_quote() : a.single_quote { return "'"; }
        
        static paren<t>(value : t) : xpr.parenthetical<t>
        {   
            return [this.left_paren(), value, this.right_paren()]
        }

        static squote<t>(value : t) : xpr.single_quoted<t>
        {
            return [this.single_quote(), value, this.single_quote()]
        }
    }
