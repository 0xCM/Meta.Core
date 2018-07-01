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

    public class XsdInfo : XsdInfo<XsdInfo>
    {
        public static XsdInfo FromText(string XsdText)
            => new XsdInfo(XsdText);

        public static XsdInfo FromFile(FilePath SrcPath)
            => new XsdInfo(SrcPath);

        public XsdInfo(FilePath SrcPath)
            :base(SrcPath)
        {

        }    

        public XsdInfo(string XsdText)
            : base(XsdText)
        {

        }
    }

}