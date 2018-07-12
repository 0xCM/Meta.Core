//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Linq;
    using N = SystemNodeIdentifier;

    using static metacore;

    using MetaFlow.WF;
    using MetaFlow.Core;
    using SqlT.Core;

    public enum MessageIdentityKind : byte
    {
        None = 0,
        Dual = 1,
        BySchema = 2,
        BySystem = 3
    }


    public struct SystemMessageIdentity  : IEquatable<SystemMessageIdentity>
    {
        public SystemMessageIdentity(SqlTableTypeName ObjectName)
        {
            this.SchemaName = ObjectName.SchemaName;
            this.MessageTypeName = ObjectName.UnquotedLocalName;
            this.SystemId = SystemIdentifier.Empty;
        }

        public SystemMessageIdentity(SystemIdentifier SystemId, SqlTableTypeName ObjectName)
        {
            this.SchemaName = ObjectName.SchemaName;
            this.MessageTypeName = ObjectName.UnquotedLocalName;
            this.SystemId = SystemId;
        }

        public SystemMessageIdentity(SystemIdentifier SystemId, SqlSchemaName SchemaName, string MessageTypeName)
        {
            this.SchemaName = SchemaName;
            this.MessageTypeName = MessageTypeName;
            this.SystemId = SystemId;
        }

        public SystemMessageIdentity(SqlSchemaName SchemaName, string MessageTypeName)
        {
            this.SchemaName = SchemaName;
            this.MessageTypeName = MessageTypeName;
            this.SystemId = SystemIdentifier.Empty;
        }

        public SystemMessageIdentity(SystemIdentifier SystemId, string MessageTypeName)
        {
            this.SchemaName = SqlSchemaName.Empty;
            this.MessageTypeName = MessageTypeName;
            this.SystemId = SystemId;
        }

        public SqlSchemaName SchemaName { get; }

        public SystemIdentifier SystemId { get; }

        public string MessageTypeName { get; }


        public MessageIdentityKind IdentityKind
        {
            get
            {
                if (not(SchemaName.IsEmpty()) && not(SystemId.IsEmpty))
                    return MessageIdentityKind.Dual;
                else if (not(SchemaName.IsEmpty()))
                    return MessageIdentityKind.BySchema;
                else if (not(SystemId.IsEmpty))
                    return MessageIdentityKind.BySystem;
                else
                    return MessageIdentityKind.None;

            }
        }

        public override string ToString()
        {
            switch(IdentityKind)
            {
                case MessageIdentityKind.Dual:
                    return $"{SystemId}/{SchemaName.UnquotedLocalName}/{MessageTypeName}";
                case MessageIdentityKind.BySystem:
                    return $"{SystemId}/{MessageTypeName}";
                case MessageIdentityKind.BySchema:
                    return $"{SchemaName.UnquotedLocalName}/{MessageTypeName}";
                default:
                    return MessageTypeName;
            }
        }

        public bool Equals(SystemMessageIdentity other)
            => string.Compare(this.ToString(), other.ToString(), true) == 0;

        public override int GetHashCode()
            => this.ToString().GetHashCode();

        public override bool Equals(object obj)
            => obj is SystemMessageIdentity 
            ? Equals((SystemMessageIdentity)obj) 
            : false;

        public SystemMessageIdentity IdentifyBySystem()
            => new SystemMessageIdentity(SystemId, MessageTypeName);
    }


}