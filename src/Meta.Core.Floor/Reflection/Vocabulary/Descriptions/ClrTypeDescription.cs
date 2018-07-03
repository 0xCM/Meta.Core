//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

public abstract class ClrTypeDescription<D, E> : ClrElementDescription<D, E>
    where D : ClrTypeDescription<D, E>
    where E : IClrElement
{
    protected ClrTypeDescription(E DescribedElement)
        : base(DescribedElement)
    { }
}
