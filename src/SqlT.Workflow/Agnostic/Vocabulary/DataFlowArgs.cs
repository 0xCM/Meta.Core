//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    



    public class DataFlowArgs : IFlowArgs
    {
        Dictionary<string, NamedValue> _CustomArgs = new Dictionary<string, NamedValue>();

        protected DataFlowArgs()
        { }

        public DataFlowArgs(FlowSettings ControlSettings)
        {
            this.ControlSettings = ControlSettings;

        }

        public FlowSettings ControlSettings { get; set; }


        public Option<NamedValue> GetArgumentValue(string name)
            => _CustomArgs.ContainsKey(name) ? _CustomArgs[name] : null;

        public void SetArgumentValue(NamedValue value)
            => _CustomArgs[value.Name] = value;

        protected Option<NamedValue> GetThisValue([CallerMemberName] string name = null)
            => GetArgumentValue(name);

        protected T GetThisValue<T>([CallerMemberName] string name = null)
            => GetArgumentValue(name).MapValueOrDefault(v => (T)v.Value, default(T));

        public void SetThisValue(object value, [CallerMemberName] string name = null)
            => _CustomArgs[name] = new NamedValue(name, value);

        

    }
}