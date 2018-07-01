//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using static metacore;

using Meta.Core;


public interface ITextFileIO
{
    IO<Unit> Write(string Data, FilePath Target);

    IO<string> Read(FilePath Source);
}


public class TextFileIO : ITextFileIO
{
    static readonly ITextFileIO io = new TextFileIO();    

    IO<string> ITextFileIO.Read(FilePath Source)
        => Source.ReadAllText();

    IO<Unit> ITextFileIO.Write(string Data, FilePath Target)
    {
        var result = Target.Write(Data);
        return result.Succeeded 
            ? IO.Ok(Unit.Value) 
            : IO.Fail<Unit>(result.Message);                
    }

    public static IO<string> Read(FilePath Source)
        => io.Read(Source);

    public static IO<Unit> Write(string Data, FilePath Target)
        => io.Write(Data, Target);

    public static IO<Unit> Copy(FilePath Source, FilePath Target)
        => from data in Read(Source)
           from write in Write(data, Target)
           select write;

}

public static class IO
{
    /// <summary>
    /// Creates a IO initialized with the supplied value
    /// </summary>
    /// <param name="Value">The initial vlue</param>
    /// <returns></returns>
    public static IO<X> Ok<X>(X Value)
        => new IO<X>(Value);

    public static IO<X> Fail<X>(IApplicationMessage Reason)
        => new IO<X>(new Failure(Reason));

}


/// <summary>
/// Basic IO monad
/// </summary>
/// <typeparam name="X">The base space over which the monad is defined</typeparam>
public struct IO<X> 
{

   
    /// <summary>
    /// Implicitly lifts a value from the base space X into the construction space
    /// </summary>
    /// <param name="x">The value to lift</param>
    public static implicit operator IO<X>(X x)
        => new IO<X>(x);

    /// <summary>
    /// Drops a value from the construction space to the base space
    /// </summary>
    /// <param name="x">The value to lift</param>
    public static implicit operator X(IO<X> x)
        => new IO<X>(x);

    /// <summary>
    /// Drops a value from the construction space to the base space
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static X operator ~(IO<X> x)
        => x.Value;

    public IO(X Value)
    {
        this.Value = Value;
        this.Fail = none<Failure>();
    }

    public IO(Failure Fail)
    {
        this.Value = default(X);
        this.Fail = Fail;
    }

    /// <summary>
    /// The encapsulated value
    /// </summary>
    X Value { get; }

    Option<Failure> Fail { get; }

    /// <summary>
    /// Canonical bind
    /// </summary>
    /// <typeparam name="Y">The base space fro the range of the bound function</typeparam>
    public IO<Y> Bind<Y>(Func<X, IO<Y>> f)
        => f(Value);

    /// <summary>
    /// Canonical select
    /// </summary>
    /// <typeparam name="Y">The target base space</typeparam>
    /// <param name="selector"></param>
    /// <returns></returns>
    public IO<Y> Select<Y>(Func<X, Y> selector)
            => selector(Value);

    /// <summary>
    /// Canonical select many
    /// </summary>
    /// <typeparam name="Y">The intermediate base space</typeparam>
    /// <typeparam name="Z">The target base space</typeparam>
    /// <param name="select"></param>
    /// <param name="project"></param>
    /// <returns></returns>
    public IO<Z> SelectMany<Y, Z>(Func<X, IO<Y>> select, Func<X, Y, Z> project)
    {
        var x = Value;
        return select(x).Bind<Z>(y => project(x, y));
    }

}

