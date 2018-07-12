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
    using System.Diagnostics.Tracing;

    using Meta.Core;
 
    using static metacore;

    using MetaFlow.Core;
    using MetaFlow.Core.Storage;
    using MetaFlow.WF;

    using SqlT.Core;
   
    class SystemMessageConverter : PlatformService<SystemMessageConverter, ISystemMessageConverter>, ISystemMessageConverter
    {
        IReadOnlyDictionary<SystemMessageIdentity,MessageFormat> FormatDefinitions { get; }

        Option<MessageFormat> LookupFormat(SystemMessageIdentity identity)
            => FormatDefinitions.TryFind(identity);

        IReadOnlyList<SystemMessageIdentity> GetIdentities()
            => (from b in PlatformBroker()
                from types in b.Get(new MessageTypes())
                select map(types, x => x.MessageIdentity())
                ).Require();

        IReadOnlyList<MessageFormat> GetFormats()
            => (from b in PlatformBroker()
                from f in b.Get(new MessageFormats())
                select f).Require();


        public SystemMessageConverter(INodeContext C)
            : base(C)
        {
            var identities = GetIdentities();
            var formats = GetFormats();
            FormatDefinitions = dict(from f in formats
                                     let identity = identities.Single(id => id.SchemaName == f.SchemaName && id.MessageTypeName == f.TypeName)
                                     select (identity.IdentifyBySystem(), f));
        }

        public IAppMessage ToApplicationMessage<TBody>(ISystemEventCapture<TBody> @event)
            where TBody : class, ISystemEvent,new()
        {
            var level = (EventLevel)@event.SeverityLevel;
            var ct = CorrelationToken.Create(ifBlank(@event.CorrelationToken, string.Empty));

            var format = LookupFormat(@event.IdentifyBySystem());
            var template = format.Map(f => f.FormatTemplate, () => "MissingFormat");
            var content = @event.EventBody;
            switch (level)
            {
                case EventLevel.Critical:
                case EventLevel.Error:
                    return error(ct, template, content);

                case EventLevel.Verbose:
                    return babble(ct, template, content);

                case EventLevel.Warning:
                    return warn(ct, template, content);

                case EventLevel.LogAlways:
                case EventLevel.Informational:
                default:
                    return inform(ct, template, content);

            }


        }

    }


}