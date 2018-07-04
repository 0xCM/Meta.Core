//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Services;

    using static metacore;


    /// <summary>
    /// Aociates a column metadata source table 
    /// with a facet of the generated type    
    /// </summary>
    public class CSharpPocoColumnBinding
    {

        /// <summary>
        /// The name of a column in the metatable
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// The name of the generated property deterined (in part)
        /// by the facet
        /// </summary>
        public string PropertyName { get; set; }


        /// <summary>
        /// The name of the facet
        /// </summary>
        public string FacetName { get; set; }
    }

    public class CSharpPocoGenerationProfile : CodeGenerationProfile
    {
        public CSharpPocoGenerationProfile()
        {
            this.Properties = new CSharpPocoColumnBinding[] { };
        }


        /// <summary>
        /// The connector to the database that defines the metadata source object
        /// </summary>
        [
            Description("The connector to the database that defines the metadata source object")
        ]
        public SqlConnectionString MetadataConnector { get; set; }

        /// <summary>
        /// A table for which each row determines a generated type
        /// </summary>
        /// <remarks>
        /// This effectively transforms a table definition into a metatype
        /// where each row is a factory for a conforming type
        /// </remarks>
        [
            Description("A table for which each row determines a generated type")
        ]
        public SqlTableName MetadataSource { get; set; }


        /// <summary>
        /// Identifies the name and  order of the columns in the metatable used to generate the desired types
        /// </summary>
        [
            Description("Identifies the name and  order of the columns in the metatable used to generate the desired types")
        ]
        public CSharpPocoColumnBinding[] Properties { get; set; }

        /// <summary>
        /// The name of the column in the metatable that determines the name of the generated type
        /// </summary>
        [
            Description("The name of the column in the metatable that determines the name of the generated type")
        ]
        public SqlColumnName TypeNameColumn { get; }

    }

    class CSharpPocoGenerator : ApplicationService<CSharpPocoGenerator, ICSharpPocoGenerator>
    {

        public CSharpPocoGenerator(IApplicationContext C)
            : base(C)
        {

        }

        public Option<FilePath> GenerateTypes(CSharpPocoGenerationProfile gp)
        {
            var broker = gp.MetadataConnector.GetClientBroker();
            var typeNameColumn = SqlColumnName.Parse(gp.TypeNameColumn);
            var columns = stream(stream(typeNameColumn), gp.Properties.Select(p => SqlColumnName.Parse(p.ColumnName))).ToList();
            var data = broker.Table(gp.MetadataSource).Select(columns);
            if (!data)
                return data.ToNone<FilePath>();

            var frame = data.Require();
            foreach(var row in frame.Rows)
            {

            }

            return none<FilePath>();
        }
    }

}