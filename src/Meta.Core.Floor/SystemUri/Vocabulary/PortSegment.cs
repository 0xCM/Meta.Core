//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using static metacore;


public sealed partial class SystemUri : SemanticIdentifier<SystemUri, Uri>
{

    public sealed class PortSegment : SemanticIdentifier<PortSegment, int>, ISystemUriPart
    {

        public static implicit operator PortSegment(int PortNumber)
            => new PortSegment(PortNumber);

        public char Separator
            => ':';

        public string Text
            => ToString();

        protected override PortSegment New(string IdentifierText)
            => new PortSegment(Int32.Parse(IdentifierText));

        public PortSegment()
            : base(0)
        {

        }

        public PortSegment(int PortNumber)
            : base(PortNumber)
        { }

        
    }



}