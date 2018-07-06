using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

using System.IO;

public static class SystemNode
{

    public class NodeVariable
    {
        public string VarName { get; set; }
        public string VarValue { get; set; }

    }

    [SqlProcedure]
    public static void SetVar(string VarName, string VarValue)
    {
        try
        {
            Environment.SetEnvironmentVariable(VarName, VarValue, EnvironmentVariableTarget.Machine);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Unexpected error:{e.Message}");

        }
    }

    [SqlFunction(FillRowMethodName = nameof(VarsFill), TableDefinition = VarsSql)]
    public static IEnumerable NodeVars()
    {
        var variables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
        foreach (var key in variables.Keys)
            yield return new NodeVariable
            {
                VarName = key.ToString(),
                VarValue = variables[key].ToString()
            };
    }

    const string VarsSql
        = "VarName nvarchar(250), VarValue nvarchar(4000)";

    public static void VarsFill(object o,
        out SqlString VarName,
        out SqlString VarValue
        
        )
    {
        var v = o as NodeVariable;
        VarName = v.VarName;
        VarValue = v.VarValue;
    }


}