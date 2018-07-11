//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;

    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    
    [SqlScript(SqlScriptIdentifiers.ObjectExists)]
    public class SqlObjectExists : SqlQueryScript<SqlObjectExists>, ISqlQueryAction
    {

        public SqlObjectExists(SqlObjectName ObjectName)
            : base(SQL, ObjectName, DefinedParameters)
        {
            this.ObjectName = ObjectName;
        }

        static readonly SqlScript SQL = @"select  
		isnull(
			try_convert(bit, 
				case 
					when object_id(@ObjectName) is not null 
						then 1 
					else 0 
				end), 0) as ObjectExists";

        static readonly SqlRoutineParameter[] DefinedParameters = new[]
        {
            new SqlRoutineParameter(nameof(ObjectName), SqlNativeTypes.nvarchar.Reference(false,260))
        };

        public class Result
        {
            public bool ObjectExists { get; set; }
        }

        public override Option<Type> ResultType 
            => typeof(Result);



        [SqlTemplateParameter]
        public SqlObjectName ObjectName { get; private set; }

    }


}
