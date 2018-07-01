﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Project
{
    public class SqlProject : DevProject<SqlProject>
    {
        public static readonly FileExtension FileExtension = CommonFileExtensions.SqlProject;

        public SqlProject(DevProjectName ProjectName)
            : base(ProjectName)
        { }
    }

}