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

    using System.Xml;
    using System.Xml.Schema;
    using System.IO;

    using static metacore;

    /// <summary>
    /// Describes an XSD document
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class XsdInfo<T> where T : XsdInfo<T>
    {

        Option<XmlSchema> ReadSchema()
        {
            try
            {
                using (var textReader = new StringReader(XsdText))
                {
                    return XmlSchema.Read(textReader, (sender, args) => ValidationEventList.Add(args));
                }
            }
            catch(Exception e)
            {
                
                return none<XmlSchema>(e);
            }
        }

        Option<XmlSchema> ReadSchema(FilePath SourceFile)
        {
            try
            {
                using (var reader = new XmlTextReader(SourceFile))
                    return XmlSchema.Read(reader, (sender, args) => ValidationEventList.Add(args));
            }
            catch (Exception e)
            {
                return none<XmlSchema>(e);
            }

        }

        protected IDictionary<string, XsdSimpleTypeInfo> SimpleTypeIndex { get; private set; }
            = new Dictionary<string, XsdSimpleTypeInfo>();

        protected IDictionary<string, XsdAttributeGroupInfo> AttributeGroupIndex { get; private set; }
            = new Dictionary<string, XsdAttributeGroupInfo>();

        protected IDictionary<string, XsdComplexTypeInfo> ComplexTypeIndex { get; private set; }
            = new Dictionary<string, XsdComplexTypeInfo>();

        protected MutableList<ValidationEventArgs> ValidationEventList { get; set; }
            = MutableList.Create<ValidationEventArgs>();

        void DistillSummary(XmlSchema s)
        {
            TargetNamespace = s.TargetNamespace;
            Namespaces = s.Namespaces.ToArray();
            SimpleTypeIndex = map(
                s.GetSimpleTypes(), t => new XsdSimpleTypeInfo(t)).ToDictionary(x => x.Name);

            AttributeGroupIndex = map(s.GetAttributeGroups(),
                g => new XsdAttributeGroupInfo(g,
                    n => SimpleTypeIndex.TryFind(n))).ToDictionary(x => x.Name);

            ComplexTypeIndex = map(
                s.GetComplexTypes(),
                t => new XsdComplexTypeInfo(t,
                    n => SimpleTypeIndex.TryFind(n),
                    n => AttributeGroupIndex.TryFind(n))
                    ).ToDictionary(x => x.Name);

        }

        protected XsdInfo(string XsdText)
        {
            this.XsdText = XsdText;
            Schema = ReadSchema();
            Schema.OnSome(DistillSummary);

        }

        protected XsdInfo(FilePath SourceFile)   
        {
            XsdFile = SourceFile;
            Schema = ReadSchema(SourceFile);
            Schema.OnSome(s =>
            {
                DistillSummary(s);

                var sb = new StringBuilder();
                using (var writer = new StringWriter(sb))
                    s.Write(writer);
                XsdText = sb.ToString();

            }).OnNone(_ =>
            {
                XsdText =  File.ReadAllText(SourceFile,Encoding.UTF8);
            });
            
            
        }
        
        protected Option<XmlSchema> Schema { get; private set; }

        public Option<FilePath> XsdFile { get; }

        public string XsdText { get; private set; }

        public string TargetNamespace { get; private set; }
            = string.Empty;

        public IReadOnlyList<XmlQualifiedName> Namespaces { get; private set; }
            = rolist<XmlQualifiedName>();

        public IEnumerable<XsdSimpleTypeInfo> SimpleTypes
            => SimpleTypeIndex.Values;

        public IEnumerable<XsdComplexTypeInfo> ComplexTypes
            => ComplexTypeIndex.Values;

        public IEnumerable<XsdAttributeGroupInfo> AttributeGroups
             => AttributeGroupIndex.Values;

        public IEnumerable<ValidationEventArgs> ValidationEvents
            => ValidationEventList;

        //public IReadOnlyList<EnumSpec> InferEnums()
        //{
        //    var enums = from t in SimpleTypeIndex.Values
        //                where t.DefinesEnum
        //                let literals = mapi(t.EnumLiterals, (i, l) => (l, (object)(i + 1))).ToArray()
        //                select new EnumSpec(
        //                    t.Name.Replace("Enum", String.Empty),
        //                    ClrType.Reference<int>(),
        //                    literals);
        //    return enums.ToList();
        //}

        public bool IsValid
            => Schema.Exists;

        public Option<IApplicationMessage> ErrorMessage
            => Schema.MapValueOrElse(v => null, message => some(message));

        public override string ToString()
            => TargetNamespace;
    }
}