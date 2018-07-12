//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;
    using System.Reflection;
    using Meta.Core;

    using SqlT;
    using SqlT.Core;
    using SqlT.Services;
    using SqlT.Models;
    using SqlT.Workflow;
    using SqlT.Types;


    using MetaFlow.Core;
    using MetaFlow.WF;

    using static metacore;
    public class SystemMessageTypeInfo
    {
        static IEnumerable<MessageAttribute> MessageAttributes(SqlTableTypeProxyInfo t)
            => map(t.Columns, c => new MessageAttribute
                (
                    SystemId: t.RuntimeType.DefiningSystem(),
                    SchemaName: t.ObjectName.SchemaNamePart,
                    TypeName: t.ObjectName.UnquotedLocalName,
                    ColumnName: c.ColumnName,
                    ColumnPosition: c.Position + 1,
                    DataTypeName: c.SqlType.TypeName.UnquotedLocalName,
                    IsNullable: c.SqlType.IsNullable ?? true,
                    Length: c.SqlType.Length,
                    Precision: c.SqlType.Precision,
                    Scale: c.SqlType.Scale,
                    Description: ifBlank(c.Documentation?.Description, null)
                )
            );

        static IEnumerable<SystemMessageTypeInfo> EventTypeRegistrations(IEnumerable<ClrType> SystemEventTypes)
            => from e in SystemEventTypes
               let pt = PXM.TableType(e)
               let sn = pt.ObjectName.SchemaNamePart
               let tn = pt.ObjectName.UnquotedLocalName
               select new SystemMessageTypeInfo(new MessageTypeRegistration
                (
                    SystemId: e.DefiningSystem(),
                    SchemaName: sn,
                    TypeName: tn,
                    MessageClass: MessageClassKind.Event.ToString(),
                    Description: ifBlank(pt.Documentation?.Description, null)
                ), MessageAttributes(pt));

        static IEnumerable<SystemMessageTypeInfo> CommandTypeRegistrations(IEnumerable<ClrType> SystemCommandTypes)
            => from e in SystemCommandTypes
               let pt = PXM.TableType(e)
               let sn = pt.ObjectName.SchemaNamePart
               let tn = pt.ObjectName.UnquotedLocalName
               select new SystemMessageTypeInfo(new MessageTypeRegistration
                (
                    SystemId: e.DefiningSystem(),
                    SchemaName: sn,
                    TypeName: tn,
                    MessageClass: MessageClassKind.Command.ToString(),
                    Description: ifBlank(pt.Documentation?.Description, null)
                ), MessageAttributes(pt));

        SystemMessageTypeInfo(MessageTypeRegistration Registration, IEnumerable<MessageAttribute> Attributes)
        {
            this.Registration = Registration;
            this.Attributes = rolist(Attributes);
        }

        public static IEnumerable<SystemMessageTypeInfo> Construct(IEnumerable<ClrType> SystemEventTypes,
                 IEnumerable<ClrType> SystemCommandTypes)
                     => EventTypeRegistrations(SystemEventTypes).Union(
                         CommandTypeRegistrations(SystemCommandTypes));

        public MessageTypeRegistration Registration { get; }

        public IReadOnlyList<MessageAttribute> Attributes { get; }
    }


  
}