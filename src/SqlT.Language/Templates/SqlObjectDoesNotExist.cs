//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Syntax;
    using SqlT.Models;

    [SqlScript(SqlScriptIdentifiers.ObjectDoesNotExist)]
    public class SqlObjectDoesNotExist : SqlQueryScript<SqlObjectDoesNotExist>, ISqlQueryAction
    {
        public SqlObjectDoesNotExist(SqlObjectName ObjectName)
            : base(SQL, ObjectName, DefinedParameters)
        {
            this.ObjectName = ObjectName;
        }

        static readonly SqlScript SQL =
            @"select isnull(
			try_convert(bit, 
				case 
					when object_id('@ObjectName') is null 
						then 1 
					else 0 
				end), 1)";

        static readonly SqlRoutineParameter[] DefinedParameters = new[]
        {
            new SqlRoutineParameter(nameof(ObjectName), SqlNativeTypes.nvarchar.Reference(false,260))
        };

        public class Result
        {
            public bool ObjectDoesNotExist { get; set; }
        }

        public override Option<Type> ResultType
            => typeof(Result);

        [SqlTemplateParameter]
        public SqlObjectName ObjectName { get; private set; }

    }
}
