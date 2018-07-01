using System;
using System.Collections.Generic;
using System.Text;

public abstract class SemanticString<I> : SemanticValue<I, string>
    where I : SemanticString<I>
{

    SemanticString()
        : this(String.Empty)
    {

    }

    protected SemanticString(string Value)
        : base(Value)
    {

    }

    public override bool Equals(I other)
        => this.Value == other.Value;

}

