//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Reflection;

    using Meta.Core;
    using SqlT.Syntax;

    using static metacore;

    /// <summary>
    /// Base type for <see cref="ISqlScript"/> realizations
    /// </summary>
    /// <typeparam name="T">The derived subtype</typeparam>
    public abstract class SqlScript<T> : ISqlScript
        where T : SqlScript<T>
    {

        /// <summary>
        /// Identifies script parameters of the form $(Parameter)
        /// </summary>
        static readonly Regex ParamType1 = new Regex(@"\$\((?<Name>(\w)*)\)", RegexOptions.Compiled);

        /// <summary>
        /// Identifies script parameters of the form @Parameter
        /// </summary>
        static readonly Regex ParamType2 = new Regex(@"@(?<Name>[a-zA-Z_]*)", RegexOptions.Compiled);

        /// <summary>
        /// Gets the names of script parameters  of the form $(Param) 
        /// </summary>
        static IReadOnlyList<SqlParameterName> GetPlaceholderNames(string ScriptText)
            => ParamType1.Matches(ScriptText).OfType<Match>()
                        .Select(m => m.GroupValue("Name"))
                        .Distinct()
                        .Select(x => new SqlParameterName(x))
                        .ToList();

        /// <summary>
        /// Gets the names of script parameters  of the form @Param
        /// </summary>
        static IReadOnlyList<SqlParameterName> GetStandardNames(string ScriptText)
            => ParamType2.Matches(ScriptText).OfType<Match>()
                        .Select(m => m.GroupValue("Name"))
                        .Distinct()
                        .Select(x => new SqlParameterName(x))
                        .ToList();

        /// <summary>
        /// Searches for standard placeholders to deduce the parameters required by the script
        /// </summary>
        /// <param name="ScriptText">The script text</param>
        /// <returns></returns>
        static IReadOnlyList<SqlParameterName> InferParameterNames(string ScriptText)
            => GetPlaceholderNames(ScriptText)
                .Union(GetStandardNames(ScriptText))
                .ToList();

                
        protected SqlScript(FilePath SourceFile, string ScriptText)
        {
            this.SourceFile = SourceFile;
            this.ScriptId = new SqlIdentifier(SourceFile.FileName.RemoveExtension(),false);
            this.ScriptName = SourceFile.FileName.Value;
            this.ScriptText = ScriptText;
            this.ParameterNames = rolist<SqlParameterName>();
        }

        protected SqlScript(SqlScriptName ScriptName, SqlIdentifier ScriptIdentifier, string ScriptText)
        {
            this.ScriptName = ScriptName;
            this.ScriptId = ScriptIdentifier ?? new SqlIdentifier(ScriptName.UnqualifiedName, false);
            this.ScriptText = ScriptText;
            this.ParameterNames = InferParameterNames(ScriptText);
        }

        protected SqlScript(SqlScriptName ScriptName, string ScriptText) 
            :this(ScriptName, null, ScriptText)

        {

        }

        protected SqlScript(SqlScriptName ScriptName, SqlIdentifier ScriptIdentifier,
            string ScriptText, IEnumerable<SqlParameterName> ParameterNames) 
            : this(ScriptName, ScriptIdentifier, ScriptText)
        {
            this.ScriptId  = ScriptIdentifier  ?? new SqlIdentifier(ScriptName.UnqualifiedName,false);

            if (ParameterNames != null)
                this.ParameterNames = ParameterNames.ToList();
            else
                this.ParameterNames = rolist<SqlParameterName>();
        }

        protected SqlScript(Option<FilePath> SourceFile,  SqlScriptName ScriptName, string ScriptIdentifier, 
            string ScriptText, IReadOnlyList<SqlParameterName> ParameterNames)
        {
            this.SourceFile = SourceFile;
            this.ScriptName = ScriptName;
            this.ScriptId = ScriptIdentifier ?? ScriptName.UnqualifiedName;
            this.ScriptText = ScriptText;
            this.ParameterNames = ParameterNames;
        }

        /// <summary>
        /// If applicable, the file from which the script was loaded
        /// </summary>
        public Option<FilePath> SourceFile { get; }

        /// <summary>
        /// The label/display name of the script
        /// </summary>
        public SqlScriptName ScriptName { get; }

        /// <summary>
        /// A legal SQL identifier that designates the script
        /// </summary>
        public string ScriptId { get; }

        /// <summary>
        /// The script body
        /// </summary>
        public string ScriptText { get; }

        /// <summary>
        /// Specifies the scrip's named parameters, if any
        /// </summary>
        public IReadOnlyList<SqlParameterName> ParameterNames { get; }

        /// <summary>
        /// Determines whether the script defines a given parameter
        /// </summary>
        /// <param name="name">The name of the parameter to check</param>
        /// <returns></returns>
        public bool AcceptsParameter(SqlParameterName name)
            => ParameterNames.Contains(name);

        /// <summary>
        /// Specifies whether the name for the script is nonempty
        /// </summary>
        public bool IsNamed
            => not(ScriptName.IsEmpty());

        /// <summary>
        /// A lousy equality implementation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
            => (obj as SqlScript)?.ScriptText == ScriptText;

        public override int GetHashCode()
            => ScriptText.GetHashCode();

        public override string ToString()
            => ScriptText;
    }

    public sealed class SqlScript :  SqlScript<SqlScript>
    {
        /// <summary>
        /// The singular value representing an empty script
        /// </summary>
        public static readonly SqlScript Empty
            = new SqlScript(String.Empty);

        public static implicit operator SqlScript(string ScriptText)
            => Create(ScriptText ?? string.Empty);

        public static implicit operator string(SqlScript script)
            => script?.ScriptText ?? string.Empty;

        /// <summary>
        /// Concatentates two scripts, maintaining the attributes of the first script 
        /// and discarding those of the second
        /// </summary>
        /// <param name="L">The first script</param>
        /// <param name="R">The second script</param>
        /// <returns></returns>
        public static SqlScript operator +(SqlScript L, SqlScript R)
            => (L == null || R == null)
            ? Empty
            : new SqlScript(L?.ScriptName ?? string.Empty,
                            L?.ScriptId ?? string.Empty,
                            $"{L?.ScriptText ?? string.Empty} {R.ScriptText ?? string.Empty}");

        /// <summary>
        /// Basic value formatter
        /// </summary>
        /// <param name="value">The value to be formatted</param>
        /// <returns></returns>
        public static string FormatScriptValue(object value)
        {
            if (value == null)
                return "null";
            else
            {
                var type = value.GetType();
                if (type.IsDbNull())
                    return "null";
                else if (type.IsBool())
                    return cast<bool>(value) == false ? "0" : "1";
                else if (type.IsDateTime())
                    return cast<DateTime>(value).ToString("yyyy-MM-dd HH:mm:ss.fff").EncloseWithin(@"'", @"'");
                else if (type.IsChar())
                    return cast<char>(value) == '\'' ? @"''" : value.ToString();
                else if (type.IsString())
                    return String.Format("'{0}'", cast<string>(value).Replace("'", @"''"));
                else if (type.IsGuid())
                    return value.ToString().EncloseWithin(@"'", @"'");
                return value.ToString();
            }
        }

        /// <summary>
        /// Formats a core data value for use within a script
        /// </summary>
        /// <param name="value">The value to format</param>
        /// <returns></returns>
        public static string FormatScriptValue(CoreDataValue value)
        {
            if (value.ValueAsText == null)
                return null;

            return FormatScriptValue(value.ToClrValue());
        }

        /// <summary>
        /// Hydrates a script via the <see cref="ISqlScript"/> contract
        /// </summary>
        /// <param name="src">The source script</param>
        /// <returns></returns>
        public static SqlScript FromContract(ISqlScript src)
            => new SqlScript(src.ScriptName, src.ScriptId, src.ScriptText, src.ParameterNames);

        /// <summary>
        /// Constructs a script from text
        /// </summary>
        /// <param name="ScriptText"></param>
        /// <param name="args"></param>
        /// <param name="formatFunc"></param>
        /// <returns></returns>
        public static SqlScript FromText(string ScriptText, object args, Func<object, string> formatFunc)
        {
            var script = new SqlScript(ScriptText);

            var text = ScriptText;
            if (args != null)
            {
                foreach (var property in args.GetType().GetProperties())
                {
                    var paramName = new SqlParameterName(property.Name);
                    if (script.AcceptsParameter(paramName))
                    {

                        var val = property.GetValue(args);
                        if (val != null)
                        {
                            var valfmt = formatFunc?.Invoke(val) ?? val.ToString();
                            text = text.Replace(paramName, valfmt);
                        }
                    }
                }
            }
            return new SqlScript(text);
        }

        public static SqlScript FromText(string ScriptText)
            => FromText(ScriptText, null, null);

        public static SqlScript FromText(string ScriptText, object args)
            => FromText(ScriptText, args, arg => arg?.ToString() ?? String.Empty);


        /// <summary>
        /// Creates an unsourced/anonymous script
        /// </summary>
        /// <param name="ScriptText">The script body</param>
        /// <returns></returns>
        public static SqlScript Create(string ScriptText)
            => new SqlScript(ScriptText);
                                
        /// <summary>
        /// Creates a named script
        /// </summary>
        /// <param name="ScriptName">The name of the script</param>
        /// <param name="ScriptText">The script body</param>
        /// <returns></returns>
        public static SqlScript Create(SqlScriptName ScriptName, string ScriptText)
            => new SqlScript(ScriptName, ScriptText);

        /// <summary>
        /// Hydrates a script from assembly resources
        /// </summary>
        /// <param name="SourceAssembly">The assembly that defines the script resource</param>
        /// <param name="ScriptName">The resource identifier</param>
        /// <param name="parameters">Script parameters as applicable</param>
        /// <returns></returns>
        public static Option<SqlScript> FromResources
            (
                Assembly SourceAssembly,
                SqlScriptName ScriptName,
                object parameters = null
            )
        {
            var provider = AssemblyResourceProvider.Get(SourceAssembly);
            var text = provider.TryFindTextResource(ScriptName);

            return text.Map(t =>
                parameters == null
                    ? new SqlScript(ScriptName, t.Text)
                    : new SqlScript(ScriptName, FromText(t.Text, parameters))
            );

        }

        /// <summary>
        /// Hydrates a script from core assembly resources
        /// </summary>
        /// <param name="ScriptName">The resource identifier</param>
        /// <param name="parameters">Script parameters as applicable</param>
        /// <returns></returns>
        public static Option<SqlScript> FromResources(SqlScriptName ScriptName, object parameters = null) 
            => FromResources(SqlTCore.Assembly, ScriptName, parameters);

        /// <summary>
        /// Hydrates a script from a file
        /// </summary>
        /// <param name="ScriptPath">The path to the script file</param>
        /// <param name="parameters">Script parameters as applicable</param>
        /// <returns></returns>
        public static Option<SqlScript> FromFile(FilePath ScriptPath, object parameters = null)
            =>  from sql in ScriptPath.TryReadAllText()           
                select parameters == null
                    ? new SqlScript(ScriptPath, sql)
                    : new SqlScript(ScriptPath, FromText(sql, parameters));

        /// <summary>
        /// Hydrates an anonymous/unsourced script
        /// </summary>
        /// <param name="ScriptText">The script text</param>
        public SqlScript(string ScriptText)
            : base(SqlScriptName.Empty, null, ScriptText ?? string.Empty)
        {
        }

        /// <summary>
        /// Hydrates a named script
        /// </summary>
        /// <param name="ScriptName">The name of the script</param>
        /// <param name="ScriptText">The script text</param>
        public SqlScript(SqlScriptName ScriptName, string ScriptText)
            : base(ScriptName, null, ScriptText ?? string.Empty)
        {

        }

        SqlScript
        (
            Option<FilePath> SourceFile,
            SqlScriptName ScriptName,
            SqlIdentifier ScriptIdentifier,
            string ScriptText,
            IReadOnlyList<SqlParameterName> ParameterNames
        ): base(SourceFile, ScriptName, ScriptIdentifier, ScriptText, ParameterNames)
        {
        }

        SqlScript(FilePath ScriptPath, string ScriptText)
            : base(ScriptPath, ScriptText)
        {

        }

        public SqlScript(SqlScriptName ScriptName, SqlIdentifier ScriptIdentifier, string ScriptText, 
            IEnumerable<SqlParameterName> ParameterNames = null)
            : base(ScriptName, ScriptIdentifier, ScriptText, ParameterNames)
        {

        }

        public SqlScript ApplyArguments(object args, Func<object,string> formatter)
            => new SqlScript(ScriptName, ScriptId, FromText(ScriptText, args, formatter));

        /// <summary>
        /// Returns a new script with the same state but with a new name
        /// </summary>
        /// <param name="NewName">The new name</param>
        /// <returns></returns>
        public SqlScript Rename(SqlScriptName NewName)
            => new SqlScript(SourceFile, NewName, ScriptId, ScriptText, ParameterNames);
    }
}
