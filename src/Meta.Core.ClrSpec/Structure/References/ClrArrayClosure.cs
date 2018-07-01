//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static metacore;
public static partial class ClrStructureSpec
{
    public class ClrArrayClosure : ClrCollectionClosure
    {
        IClrTypeName _ItemTypeName { get; }


        public ClrArrayClosure(IClrTypeName ItemTypeName)
            : base(ItemTypeName)
        {
            this._ItemTypeName = ItemTypeName;
        }

        public IClrTypeName ItemTypeName
            => _ItemTypeName;
    }


}