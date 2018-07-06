//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;

    using kwt = SqlKeywordTypes;
    using sxc = contracts;

    public class datepart_selection : du
        <
            kwt.YEAR,
            kwt.QUARTER,
            kwt.MONTH,
            kwt.DAYOFYEAR,
            kwt.DAY,
            kwt.WEEK,
            kwt.WEEKDAY,
            kwt.HOUR,
            kwt.MINUTE,
            kwt.SECOND,
            kwt.MILLISECOND
        >, sxc.scalar_expression
    {

        public static implicit operator datepart_selection(kwt.YEAR x)
            => new datepart_selection(x);

        public static implicit operator datepart_selection(kwt.QUARTER x)
            => new datepart_selection(x);

        public static implicit operator datepart_selection(kwt.MONTH x)
            => new datepart_selection(x);

        public static implicit operator datepart_selection(kwt.DAYOFYEAR x)
            => new datepart_selection(x);

        public static implicit operator datepart_selection(kwt.DAY x)
            => new datepart_selection(x);

        public static implicit operator datepart_selection(kwt.WEEK x)
            => new datepart_selection(x);

        public static implicit operator datepart_selection(kwt.WEEKDAY x)
            => new datepart_selection(x);

        public static implicit operator datepart_selection(kwt.HOUR x)
            => new datepart_selection(x);

        public static implicit operator datepart_selection(kwt.MINUTE x)
            => new datepart_selection(x);

        public static implicit operator datepart_selection(kwt.SECOND x)
            => new datepart_selection(x);

        public static implicit operator datepart_selection(kwt.MILLISECOND x)
            => new datepart_selection(x);

        public datepart_selection(kwt.YEAR x)
            : base(x)
        { }

        public datepart_selection(kwt.QUARTER x)
            : base(x)
        { }


        public datepart_selection(kwt.MONTH x)
            : base(x)
        { }

        public datepart_selection(kwt.DAYOFYEAR x)
            : base(x)
        { }

        public datepart_selection(kwt.DAY x)
            : base(x)
        { }

        public datepart_selection(kwt.WEEK x)
            : base(x)
        { }

        public datepart_selection(kwt.WEEKDAY x)
            : base(x)
        { }

        public datepart_selection(kwt.HOUR x)
            : base(x)
        { }

        public datepart_selection(kwt.MINUTE x)
            : base(x)
        { }

        public datepart_selection(kwt.SECOND x)
            : base(x)
        { }

        public datepart_selection(kwt.MILLISECOND x)
            : base(x)
        { }

    }
}
