//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;

    using static metacore;


    public class SqlPackageReference
    {


        public SqlPackageReference(IEnumerable<NamedValue> Properties)
        {
            foreach(var p in Properties)
            {
               switch(p.Name)
                {
                    case "FileName":
                        OriginalPath = (string)p.Value;
                        break;
                    case nameof(LogicalName):
                        LogicalName = (string)p.Value;
                        break;
                    case nameof(ExternalParts):
                        ExternalParts = (string)p.Value;
                        break;
                    case nameof(SuppressMissingDependenciesErrors):
                        SuppressMissingDependenciesErrors = parse<bool>((string)p.Value);
                        break;

                }
            }

        }

        public SqlPackageReference(SqlPackageName LogialName, FilePath OriginalPath, bool SuppressMissingDependenciesErrors)
        {
            this.LogicalName = LogicalName;
            this.OriginalPath = OriginalPath;
            this.SuppressMissingDependenciesErrors = SuppressMissingDependenciesErrors;
        }

        public FilePath OriginalPath { get; private set; }

        public SqlPackageName LogicalName { get; private set; }

        public bool SuppressMissingDependenciesErrors { get; private set; }

        public string ExternalParts { get; private set; }

        public override string ToString()
            => LogicalName;
    }


}