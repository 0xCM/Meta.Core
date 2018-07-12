//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    using Meta.Core;
    using Meta.Core.Build;
    using Meta.Core.Project;
    using Meta.Core.Shell;

    using static metacore;

    public sealed class SystemOperationResult : ICorrelated
    {



        public SystemOperationResult(SystemIdentifier System, CorrelationToken Value, bool Succeeded, IAppMessage Description)
        {
            this.CT = Value;
            this.Succeeded = Succeeded;
            this.Message = Description;           
        }

        public IAppMessage Message { get; }

        public bool Succeeded { get; }

        public SystemIdentifier System { get; }
       

        public CorrelationToken? CT { get; }
            
    }






}