//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Schema;
    using System.IO;

    using static metacore;
   
    public class XsdAttributeGroupRefInfo : XsdElementInfo<XsdAttributeGroupRefInfo>
    {

        readonly XmlSchemaAttributeGroupRef GroupRef;


        public XsdAttributeGroupRefInfo(XmlSchemaAttributeGroupRef GroupRef)
        {
            this.GroupRef = GroupRef;
        }

        public override string Name
            => GroupRef.RefName.Name;
    }
 }