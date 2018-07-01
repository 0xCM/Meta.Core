#load "..\Payments.Core.Scripts\tinygen.csx"
using System.Collections.Generic;

var config = new Config
{
    OutputFile = @"..\Payments.Core\Http\Concepts\HttpResultCodes.List.cs",
    Using = new List<string> { "System" },
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