//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Workflow
{
    using static metacore;

    public delegate WorkFlowed<R> WorkflowTransformer<R>(WorkFlowed<R> input);

    public delegate WorkFlowed<R> WorkfkowWorker<R>();
    public delegate WorkFlowed<R> WorkfkowWorker<in X, R>();
    public delegate WorkFlowed<R> WorkfkowWorker<in X1, in X2, R>();


}