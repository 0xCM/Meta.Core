//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using static metacore;

    public delegate object OperationArgParser(ClrType DstType, string SrcValue);


    public class OperationWorkflow
    {


        public OperationWorkflow()
        {
            this.Steps = array<OperationExecSpec>();
        }


        public OperationWorkflow(params OperationExecSpec[] Steps)
        {
            this.Steps = Steps;
        }


        public OperationExecSpec[] Steps { get; set; }

        public OperationWorkflow WithStep(OperationExecSpec Step)
        {
            Steps = array(Steps, Step);
            return this;
        }


        public OperationWorkflow WithSteps(params OperationExecSpec[] Steps)
        {
            Steps = array(stream(Steps), Steps);
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            mapi(Steps, (i, invoke) => sb.AppendLine($"{i}: {invoke}"));
            return sb.ToString();
        }

    }

    public class ServiceWorkflow<S> : OperationWorkflow
    {
        public ServiceWorkflow(S Service, OperationArgParser Parser,  params OperationExecSpec[] Steps)
            : base(Steps)
        {
            this.Service = Service;
            Invocations = rolist(this.Describe<S>().Where(x => x.IsSome()).Values());                               
            this.ServiceDescription = ClrInterfaceDescription.Create<S>();
        }

        public ServiceWorkflow(S Service, params OperationExecSpec[] Steps)
            : this(Service, null, Steps)
        {
            

        }

        public S Service { get; }

        public ClrInterfaceDescription ServiceDescription { get; }

        public Option<OperationArgParser> Parser { get; }

        public IReadOnlyList<ClrMethodCallDescription> Invocations { get; }
            

        public IEnumerable<IOption> Execute()
            => this.Execute(Service,Parser.ValueOrDefault());



    }
}