//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
  
    public class InstanceExport : ModuleExport
    {
        public InstanceExport(Type ModuleType, Type ClassType, Type InstanceType)
            : base(ModuleType)
        {
            this.ClassType = ClassType;
            this.GenericDefinition = InstanceType;
        }

        public Type ClassType { get; }

        public Type GenericDefinition { get; }

        public Option<ResolvedExport> Resolve(params Type[] args)
            => new ResolvedExport(ModuleType, ClassType, GenericDefinition, GenericDefinition.MakeGenericType(args));

        public override string ToString()
            => $"{ModuleType.Name}::{ClassType.Name}";
    }


}