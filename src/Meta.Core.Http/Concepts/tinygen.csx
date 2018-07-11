#r "System.Data"
#r "Microsoft.CSharp.dll"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;

public class QuerySpecification
{
    public virtual string ConnectionString { get; set; }
    public virtual string Selection { get; set; }

}
public class Config
{
    public string Namespace { get; set; }
    public string ClassTemplate { get; set; }
    public string MemberTemplate { get; set; }
    public string ClassName { get; set; }
    public QuerySpecification Query { get; set; }
    public string OutputFile { get; set; }
    public string[] Using { get; set; }

}

static class Generator
{
    static dynamic CreateObject(IEnumerable<Tuple<string, object>> properties)
    {
        var o = (ICollection<KeyValuePair<string, object>>)(new ExpandoObject());
        properties.ToList().ForEach(p =>
            o.Add(new KeyValuePair<string, object>(p.Item1, p.Item2)));
        return o;

    }

    static IEnumerable<IEnumerable<Tuple<string, object>>> ReadData(QuerySpecification query)
    {
        var t = new DataTable();
        using (var c = new SqlConnection(query.ConnectionString))
        {
            c.Open();
            using (var q = new SqlCommand(query.Selection, c))
            using (var a = new SqlDataAdapter(q))
                a.Fill(t);
        }

        var cols = t.Columns.OfType<DataColumn>().Select(x => x.ColumnName).ToList();
        return from row in t.Rows.OfType<DataRow>()
               let bag = cols.Zip(row.ItemArray, (x, y) => Tuple.Create(x, y))
               select bag;

    }

    static IEnumerable<dynamic> GetRecords(Config config)
    {
        foreach (var sets in ReadData(config.Query))
        {
            yield return CreateObject(sets);
        }
    }

    static string Expand(string template, object o)
    {
        var values = from p in o.GetType().GetProperties()
                     select new
                     {
                         Name = p.Name,
                         Value = p.GetValue(o)
                     };
        var result = template;
        foreach (var value in values)
            result = result.Replace($"${value.Name}$", $"{value.Value}");
        return result;

    }

    private static string Indent(string text, int spaces)
    {
        var padding = Enumerable.Range(0, spaces).Select(_ => " ").Aggregate((x, y) => x + y);
        var sb = new StringBuilder();
        using (var reader = new StringReader(text))
        {
            var line = reader.ReadLine();
            while (line != null)
            {
                sb.AppendLine(padding + line.Trim());
                line = reader.ReadLine();
            }
        }
        return sb.ToString();
    }

    public static void Generate(Config config, Func<dynamic,dynamic> transformer)
    {
        var records = GetRecords(config);
        var sb = new StringBuilder();

        foreach (var record in records)
        {
            var field = transformer(record);
            sb.Append(Indent(Expand(config.MemberTemplate, field), 8));
        }

        var c = new
        {
            CLASS_NAME = config.ClassName,
            CLASS_BODY = sb.ToString()
        };
        sb.Clear();
        sb.AppendLine($"//Generated at {DateTime.Now}");
        foreach (var u in config.Using)
            sb.AppendLine($"using {u};");
        sb.AppendLine();
        sb.AppendLine($"namespace {config.Namespace}");
        sb.AppendLine("{");
        sb.AppendLine(Expand(Indent(config.ClassTemplate, 4), c));
        sb.AppendLine("}");

        File.WriteAllText(config.OutputFile, sb.ToString());

    }

    public static void Generate(Config config)
    {
        var records = GetRecords(config);
        var sb = new StringBuilder();

        foreach (var record in records)
        {
            var field = new
            {
                FIELD_NAME = record.CodeIdentifier,
                FIELD_VALUE = record.CodeNumber,
                FIELD_DESCRIPTION = record.Description
            };
            sb.Append(Indent(Expand(config.MemberTemplate, field), 8));
        }

        var c = new
        {
            CLASS_NAME = config.ClassName,
            CLASS_BODY = sb.ToString()
        };
        sb.Clear();
        sb.AppendLine($"//Generated at {DateTime.Now}");
        foreach (var u in config.Using)
            sb.AppendLine($"using {u};");
        sb.AppendLine();
        sb.AppendLine($"namespace {config.Namespace}");
        sb.AppendLine("{");
        sb.AppendLine(Expand(Indent(config.ClassTemplate, 4), c));
        sb.AppendLine("}");

        File.WriteAllText(config.OutputFile, sb.ToString());
    }
}

static class DefaultConnectionStrings
{
    public const string Operations = @"Data Source=PAYDEV;User ID=sqladmin; Password=pass@word1; Initial Catalog=Payments.Acapture.Dev";
    public const string Reference = @"Data Source=PAYDEV;User ID=sqladmin; Password=pass@word1; Initial Catalog=Payments.Reference.Dev";

}