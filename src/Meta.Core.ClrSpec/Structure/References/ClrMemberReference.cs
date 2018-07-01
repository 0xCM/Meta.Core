//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

using static ClrStructureSpec;
public static partial class ClrStructureSpec
{
    /// <summary>
    /// Identifies a type member
    /// </summary>
    public sealed class ClrMemberReference : ValueObject<ClrMemberReference>
    {

        public ClrMemberReference(ClrTypeReference DeclaringType, ClrItemIdentifier MemberName)
        {
            this.DeclaringType = DeclaringType;
            this.MemberName = MemberName;
        }

        /// <summary>
        /// The type that declares the member
        /// </summary>
        public ClrTypeReference DeclaringType { get; }

        /// <summary>
        /// The name of the member
        /// </summary>
        public ClrItemIdentifier MemberName { get; }

        public override string ToString()
            => $"{DeclaringType}.{MemberName}";
    }
}