//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public abstract class ServiceHostDesignator<H, S> : AssemblyDesignator<H>
        where H : ServiceHostDesignator<H, S>, new()
    {

        static string ConventionalName()
        {
            var start = typeof(S).Name;
            var finish = start.TrimStart('I');
            if (!finish.EndsWith("Service"))
                finish = $"{finish}Service";
            return finish;
        }

        protected ServiceHostDesignator(Guid ServiceIdentifier, string ServiceName = null)
        {
            this.ServiceIdentifier = ServiceIdentifier;
            this.ServiceName = ServiceName ?? ConventionalName();
        }

        Guid ServiceIdentifier { get; }

        string ServiceName { get; }

    }
}