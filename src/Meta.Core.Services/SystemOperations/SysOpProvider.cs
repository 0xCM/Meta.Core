//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using static metacore;

    class SysOpProvider : ApplicationService<SysOpProvider, ISysOpProvider>, ISysOpProvider
    {
        public SysOpProvider(IApplicationContext C)
            : base(C)
        {

        }

        public Option<IOperationProvider> RequestOperationSet(Type ComponentType, SystemNode ActiveNode)
        {
            try
            {    
                var constructor = ComponentType.GetConstructor(array(typeof(IApplicationContext), typeof(SystemNode)));
                if (isNull(constructor))
                    return none<IOperationProvider>(error($"Required construct not found"));

                return some((IOperationProvider)constructor.Invoke(array<object>(C, ActiveNode)));
            }
            catch (Exception e)
            {
                return none<IOperationProvider>(e);
            }
        }

        public Option<S> RequestOperationSet<S>(SystemNode ActiveNode)
            where S : SysOpComponent<S>
            => RequestOperationSet(typeof(S), ActiveNode).Map(x => cast<S>(x));
    }
}
