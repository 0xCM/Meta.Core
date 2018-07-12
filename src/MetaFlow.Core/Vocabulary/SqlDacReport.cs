//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    public class SqlDacReport : ScriptTemplate
    {
        static readonly string TemplateContent
            = "/Action:$(ToolAction) /SourceFile:$(DacPath) /Profile:$(ProfilePath) /OutputPath:$(ReportPath)";

        public SqlDacReport(FilePath DacPath, FilePath ProfilePath, FilePath ReportPath)
            : base(nameof(SqlDacReport), TemplateContent)
        {
            this.DacPath = DacPath;
            this.ProfilePath = ProfilePath;
            this.ReportPath = ReportPath;
            this.ToolAction = "DeployReport";
        }

        public FilePath DacPath { get; set; }

        public FilePath ProfilePath { get; set; }

        public FilePath ReportPath { get; set; }

        public string ToolAction { get; set; }



    }

}
