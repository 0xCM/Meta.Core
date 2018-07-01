//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

using static metacore;

public abstract class ClrElementDescription<D, E> 
    where D : ClrElementDescription<D,E>
    where E : IClrElement
{
    protected ClrElementDescription(E DescribedElement)
    {
        this.DescribedElement = DescribedElement;
    }

    public E DescribedElement { get; }

    public override string ToString()
        => DescribedElement.Name;
}
