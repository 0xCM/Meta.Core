//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using static metacore;

using Meta.Core.Workflow;

using System;
using System.Linq;
using System.Collections.Generic;

public struct WorkFlowed<W> : IWorkflowed<W>
{
    public static implicit operator WorkFlowed<W>(W value)
        => new WorkFlowed<W>(stream(value));

    public static implicit operator WorkFlowed<object>(WorkFlowed<W> flow)
        => new WorkFlowed<object>(flow.Payload.Cast<object>(), flow.Description);

    public static implicit operator WorkFlowed<W>(Option<W> optional)
        => optional.MapValueOrElse(
                (payload, message) => new WorkFlowed<W>(stream(payload), message), 
                error => new WorkFlowed<W>(error));

    /// <summary>
    /// Unwraps the payload
    /// </summary>
    /// <param name="x">The workflow value</param>
    /// <returns></returns>
    public static IEnumerable<W> operator ~ (WorkFlowed<W> x)
        => x.Payload;

    /// <summary>
    /// Merges two workflow values
    /// </summary>
    /// <param name="x">The first value</param>
    /// <param name="y">The second value</param>
    /// <returns></returns>
    public static WorkFlowed<W> operator + (WorkFlowed<W> x, WorkFlowed<W> y)
        => new WorkFlowed<W>(x, 
            x.Payload.Concat(y.Succeeded ? y.Payload : stream<W>()));

    /// <summary>
    /// Returns true if the workflow has succeeded and false otherwise
    /// </summary>
    /// <param name="work"></param>
    /// <returns></returns>
    public static bool operator true(WorkFlowed<W> work)
        => work.Succeeded;

    /// <summary>
    /// Returns true if the workflow has failed and false otherwise
    /// </summary>
    /// <param name="work"></param>
    /// <returns></returns>
    public static bool operator false(WorkFlowed<W> work)
        => not(work.Succeeded);

    WorkFlowed(WorkflowEvaluation<W> Evaluation)
    {
        this.Payload = Evaluation.Payload;
        this.Succeeded = Evaluation.Succeeded;
        this.Description = Evaluation.Description;
        this.Antecedent = some(Evaluation.Evaluated as IWorkFlowed);
        this.Evaluated = true;
    }

    public WorkFlowed(IWorkFlowed antecedent, IEnumerable<W> Payload, IAppMessage Description = null)
    {
        this.Payload = Payload;
        this.Description = Description ?? AppMessage.Empty;
        this.Succeeded = true;
        this.Antecedent = some(antecedent);
        this.Evaluated = false;
    }

    public WorkFlowed(IEnumerable<W> Payload, IAppMessage Description = null)
    {
        this.Payload = Payload;
        this.Description = Description ?? AppMessage.Empty;
        this.Succeeded = true;
        this.Antecedent = none<IWorkFlowed>();
        this.Evaluated = false;
    }

    public WorkFlowed(IAppMessage Description)
    {
        this.Description = Description;
        this.Payload = stream<W>();
        this.Succeeded = not(Description.IsError());
        this.Antecedent = none<IWorkFlowed>();
        this.Evaluated = false;
    }

    public WorkFlowed(IWorkFlowed Antecedent, IAppMessage Description)
    {
        this.Description = Description;
        this.Payload = stream<W>();
        this.Succeeded = not(Description.IsError());
        this.Antecedent = some(Antecedent);
        this.Evaluated = false;
    }


    /// <summary>
    /// Specifies whether evaluation has occurred
    /// </summary>
    public bool Evaluated { get; }

    public bool Succeeded {get;}

    /// <summary>
    /// The encapsulated payload
    /// </summary>
    public IEnumerable<W> Payload { get; }
    
    /// <summary>
    /// Specifies the preceding step
    /// </summary>
    public Option<IWorkFlowed> Antecedent { get; }

    public IAppMessage Description { get; }

    IEnumerable<IWorkFlowed> GetAntecedents(IWorkFlowed child)
    {
        var antecedent = child.Antecedent.ValueOrDefault();
        if(isNotNull(antecedent))
        {
            yield return antecedent;
            foreach (var x in GetAntecedents(antecedent))
                yield return x;
        }
    }

    public IEnumerable<IWorkFlowed> Antecedents
        => GetAntecedents(this);

    public IEnumerable<W> Value
        => Payload;

    public WorkFlowed<W> StripPayload(IAppMessage Reason)
        => new WorkFlowed<W>(this, Reason);

    public WorkFlowed<W> OnSuccess(Func<WorkFlowed<W>, WorkFlowed<W>> flowed)
    {
        if (Succeeded)
            flowed(this);
        return this;
    }

    public WorkFlowed<W> OnFailure(Func<WorkFlowed<W>,WorkFlowed<W>> flowed)
    {
        if (not(Succeeded))
            flowed(this);
        return this;
    }

    /// <summary>
    /// Evaluates the worklow if necessary
    /// </summary>
    /// <returns></returns>
    public WorkFlowed<W> Evaluate()
        => Evaluated
        ? this
        : new WorkFlowed<W>(new WorkflowEvaluation<W>(this));

    public override string ToString()
    {
        if (not(Description.IsEmpty))
            return Description.Format(false);
        else
            return string.Join(";", Payload.Take(5));
    }
}

partial class wf
{
    /// <summary>
    /// Lifts a sequence to monadic space
    /// </summary>
    /// <typeparam name="W">The payload item type</typeparam>
    /// <param name="data">The item sequence to be lifted</param>
    /// <returns></returns>
    public static WorkFlowed<W> lift<W>(IEnumerable<W> data)
        => new WorkFlowed<W>(data);

    /// <summary>
    /// Drops a sequence out of monadic space
    /// </summary>
    /// <typeparam name="W">The payload item type</typeparam>
    /// <param name="flow">The monadic wrapper</param>
    /// <returns></returns>
    public static IEnumerable<W> drop<W>(WorkFlowed<W> flow)
        => flow.Payload;

    /// <summary>
    /// Projects an <see cref="Option{T}"/> onto a <see cref="WorkFlowed{W}"/>
    /// </summary>
    /// <typeparam name="W">The payload item type</typeparam>
    /// <param name="optional"></param>
    /// <returns></returns>
    public static WorkFlowed<W> transform<W>(Option<W> optional)
        => optional;

    /// <summary>
    /// Lifts an atomic value to monadic space
    /// </summary>
    /// <typeparam name="W">The payload item type</typeparam>
    /// <param name="x">The value to be lifted</param>
    /// <returns></returns>
    public static WorkFlowed<W> value<W>(W x)
        => new WorkFlowed<W>(stream(x));

    /// <summary>
    /// Creates the canonical <see cref="WorkFlowed{W}"/> empty value
    /// </summary>
    /// <typeparam name="W">The payload item type</typeparam>
    /// <returns></returns>
    public static WorkFlowed<W> empty<W>()
        => new WorkFlowed<W>(stream<W>());

    /// <summary>
    /// Creates a successful value initialized with a paylod and optional message
    /// </summary>
    /// <typeparam name="W">The payload item type</typeparam>
    /// <param name="payload"></param>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static WorkFlowed<W> flowed<W>(IEnumerable<W> payload, IAppMessage msg = null)
        => new WorkFlowed<W>(payload, msg);

    /// <summary>
    /// Creates a successful value initialized with an antecedent, paylod and optional message
    /// </summary>
    /// <typeparam name="W">The payload item type</typeparam>
    /// <param name="antecedent">The preceding flow</param>
    /// <param name="payload"></param>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static WorkFlowed<W> flowed<W>(IWorkFlowed antecedent, IEnumerable<W> payload, IAppMessage msg = null)
        => new WorkFlowed<W>(antecedent, payload, msg);

    /// <summary>
    /// Creates a failure value with an explanatory message
    /// </summary>
    /// <typeparam name="W">The payload item type</typeparam>
    /// <param name="error">The reason for failure</param>
    /// <returns></returns>
    public static WorkFlowed<W> failed<W>(IAppMessage error)
        => new WorkFlowed<W>(error);

    /// <summary>
    /// Creates a failure value with an antecedent and explanatory message
    /// </summary>
    /// <typeparam name="W">The payload item type</typeparam>
    /// <param name="antecedent">The preceding flow</param>
    /// <param name="error">The reason for failure</param>
    /// <returns></returns>
    public static WorkFlowed<W> failed<W>(IWorkFlowed  antecedent, IAppMessage error)
            => new WorkFlowed<W>(antecedent, error);

    /// <summary>
    /// Creates a failure value with an antecedent and explanatory message derived from a trapped exception
    /// </summary>
    /// <typeparam name="W">The payload item type</typeparam>
    /// <param name="e">The trapped exception</param>
    /// <returns></returns>
    public static WorkFlowed<W> failed<W>(Exception e)
        => new WorkFlowed<W>(error(e));

    /// <summary>
    /// Creates a failure value with an antecedent and explanatory message derived from a trapped exception
    /// </summary>
    /// <typeparam name="W">The payload item type</typeparam>
    /// <param name="antecedent">The abended flow</param>
    /// <param name="e">The trapped exception</param>
    /// <returns></returns>
    public static WorkFlowed<W> failed<W>(IWorkFlowed antecedent, Exception e)
        => new WorkFlowed<W>(antecedent, error(e));
}

public static class WorkFlowed
{
    /// <summary>
    /// The canonical bind operation for the <see cref="WorkFlowed{W}"/> monad
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <param name="x"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    public static WorkFlowed<Y> Bind<X, Y>(this WorkFlowed<X> x, Func<X, WorkFlowed<Y>> f)
        => wf.flowed(x, 
            from y in x.Payload.Select(s => f(s))
                                from z in y.Payload
                                select z);

    /// <summary>
    /// The canonical select operation for the <see cref="WorkFlowed{W}"/> monad
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <param name="x"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static WorkFlowed<Y> Select<X, Y>(this WorkFlowed<X> x, Func<X, Y> selector)
        => wf.flowed(x, x.Payload.Select(selector));

    /// <summary>
    /// The canonical select many operation for the <see cref="WorkFlowed{W}"/> monad
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    /// <typeparam name="Z"></typeparam>
    /// <param name="x"></param>
    /// <param name="selector"></param>
    /// <param name="project"></param>
    /// <returns></returns>
    public static WorkFlowed<Z> SelectMany<X, Y, Z>(this WorkFlowed<X> x, Func<X, WorkFlowed<Y>> selector, Func<X, Y, Z> project)
          => wf.flowed(x.Payload.Select(selector))
                    .Bind(y => wf.flowed(y,
                        from k in x.Payload
                        from z in y.Payload
                        select project(k, z)));
   
    /// <summary>
    /// The canonical filter operation for the <see cref="WorkFlowed{W}"/> monad
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="x"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static WorkFlowed<X> Where<X>(this WorkFlowed<X> x, Func<X, bool> predicate)
        => x ? x.Payload.All(predicate) ? x  : x.StripPayload(inform("Predicate filter"))
        : x;

    /// <summary>
    /// The canonical fold operation for the <see cref="WorkFlowed{W}"/> monad
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="flows"></param>
    /// <returns></returns>
    public static WorkFlowed<X> Reduce<X>(this IEnumerable<WorkFlowed<X>> flows)
    {
        try
        {
            return flows.Aggregate((a, b) => a + b);
        }
        catch(InvalidOperationException)
        {
            //This accounts for the fact that an invalid operation exception is thrown 
            //if Aggregate() is called for an empty sequence; Calling Any() won't do
            //as a check because that forces evaluation 
            return wf.empty<X>();
        }
    }

    /// <summary>
    /// Transforms an optional value into a workflow value
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="optional"></param>
    /// <returns></returns>
    public static WorkFlowed<X> ToWorkFlowed<X>(this Option<X> optional)
        => optional;
    
    /// <summary>
    /// Transforms a workflow value into an option value
    /// </summary>
    /// <typeparam name="X"></typeparam>
    /// <param name="flowed"></param>
    /// <returns></returns>
    public static Option<IEnumerable<X>> ToOption<X>(this WorkFlowed<X> flowed)
        => flowed.Succeeded
        ? some(flowed.Payload, flowed.Description)
        : none<IEnumerable<X>>(flowed.Description);                
}

