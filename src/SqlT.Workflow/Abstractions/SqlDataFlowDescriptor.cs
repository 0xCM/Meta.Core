//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;

    public class SqlDataFlowDescriptor
    {

        public SqlDataFlowDescriptor(Type ImplementingType, Type ArgumentSetType, ISqlProxyAssembly SourceAssembly, ISqlProxyAssembly TargetAssembly)
        {
            this.ArgumentSetType = ArgumentSetType;
            this.ImplementingType = ImplementingType;
            this.SourceAssembly = SourceAssembly;
            this.TargetAssembly = TargetAssembly;
        }

        public Type ArgumentSetType { get; }

        public Type ImplementingType { get; }

        public ISqlProxyAssembly SourceAssembly { get; }

        public ISqlProxyAssembly TargetAssembly { get; }


        public override string ToString()
            => ImplementingType.Uri();
    }
}