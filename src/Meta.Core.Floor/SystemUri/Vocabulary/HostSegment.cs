//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;


public sealed partial class SystemUri : SemanticIdentifier<SystemUri, Uri>
{
    public sealed class HostSegment : SemanticIdentifier<HostSegment, string>, ISystemUriPart
    {
        public static implicit operator string(HostSegment segment)
            => segment?.ToString() ?? string.Empty;

        public static readonly HostSegment Default = new HostSegment();

        public static implicit operator HostSegment(SystemNode node)
            => new HostSegment(node.NodeName);

        public static implicit operator HostSegment(string name)
            => new HostSegment(name);

        HostSegment()
            : base(string.Empty)
        { }

        public HostSegment(string name)
            : base(name)
        { }

        protected override HostSegment New(string name)
            => new HostSegment(name);

        public char Separator
            => '.';

        public string Text
            => ToString();

    }



}

