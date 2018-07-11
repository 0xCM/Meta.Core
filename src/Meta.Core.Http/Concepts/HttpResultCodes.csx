#load "tinygen.csx"
#r "/bin/lib/net472/Meta.Core.Floor.dll"

using System.Collections.Generic;


void Test()
{
    Console.WriteLine("test");
}

var config = new Config
{
    OutputFile = @"..\Payments.Core\Http\Concepts\HttpResultCodes.List.cs",
    Using = new string[] { "System" },
    Namespace = "Meta.Core.Http",
    Query = new QuerySpecification
    {
        ConnectionString = DefaultConnectionStrings.Reference,
        Selection =
                @"select TypeCode, CodeName, Description from Reference.HttpResultCode"
    },
    ClassName = "HttpResultCodes",
    ClassTemplate =
@"public partial class $CLASS_NAME$ : ImmutableValueObjectList<HttpResultCode, $CLASS_NAME$>
{
    $CLASS_BODY$
}",
    MemberTemplate =
@"      
/// <Summary>
/// $Description$
/// </Summary>
public static readonly HttpResultCode $CodeName$ = new HttpResultCode(""$CodeName$"",$TypeCode$);"
};

Generator.Generate(config, record =>
    new
    {
        CodeName = record.CodeName,
        TypeCode = record.TypeCode,
        Description = record.Description
    }

);