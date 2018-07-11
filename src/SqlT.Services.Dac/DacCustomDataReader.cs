//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Packaging;
    using System.Xml;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Models;

    using CDATA = SqlT.Models.SqlPackageCustomData;

    /// <summary>
    /// Parses data from a dacpac that isn't available via the API
    /// </summary>
    static class DacCustomDataReader
    {
        static string GetXmlFile(Package package, string fileName)
        {
            
            var part = package.GetPart(new Uri(string.Format("/{0}", fileName), UriKind.Relative));
            var stream = part.GetStream();
            return new StreamReader(stream).ReadToEnd();
        }

        /// <summary>
        /// Algorith taken from: https://github.com/GoEddie/Dacpac-References/blob/master/src/GOEddie.Dacpac.References/HeaderParser.cs
        /// </summary>
        static IReadOnlyList<CDATA> ReadCustomData(SqlPackageDesignator h)
        {
            using (var package = Package.Open(h.PackagePath.AbsolutePath, FileMode.Open, FileAccess.Read))
            {
                var xml = GetXmlFile(package, "Model.xml");
                var reader = XmlReader.Create(new StringReader(xml));
                reader.MoveToContent();

                var data = MutableList.Create<CDATA>();
                CDATA currentCustomData = null;
                while (reader.Read())
                {
                    if (reader.Name == "CustomData" && reader.NodeType == XmlNodeType.Element)
                    {
                        var cat = reader.GetAttribute("Category");
                        var type = reader.GetAttribute("Type");
                        currentCustomData = new CDATA(cat, type);
                        data.Add(currentCustomData);
                    }
                    if (reader.Name == "Metadata" && reader.NodeType == XmlNodeType.Element)
                    {
                        var name = reader.GetAttribute("Name");
                        var value = reader.GetAttribute("Value");
                        currentCustomData.AddProperty(name, value);
                    }
                    if (reader.Name == "Header" && reader.NodeType == XmlNodeType.EndElement)
                    {
                        break; //gone too far
                    }
                }
                return data;
            }
        }

        public static SqlPackageCustomDataSet ReadCustomDataSet(SqlPackageDesignator h)
            => new SqlPackageCustomDataSet(h.PackagePath.FileName.RemoveExtension().ToString(), ReadCustomData(h));

    }

}