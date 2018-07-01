//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;

using static metacore;

/// <summary>
/// Represents a system-relative URI. 
/// </summary>
/// <remarks>
/// See https://en.wikipedia.org/wiki/Uniform_Resource_Identifier
/// </remarks>
public sealed partial class SystemUri : SemanticIdentifier<SystemUri, Uri>, ISystemUri
{
    public static implicit operator string(SystemUri uri)
        => uri?.ToString() ?? string.Empty;

    public static readonly char[] LegalCharacters 
        = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-._~:/?#[]@!$&'()*+,;=`.".ToCharArray();

    public static SystemUri Define
        (
            SchemeSegment scheme = null, 
            HostSegment host = null, 
            PathSegment path = null, 
            QuerySegment query = null
        ) => new SystemUri(scheme, host, path, query);

    public static SchemeSegment ToScheme(string text)
        => new SchemeSegment(text);

    public static HostSegment ToHost(string text = null)
        => String.IsNullOrWhiteSpace(text) 
        ? HostSegment.Default 
        : new HostSegment(text);

    public static PathSegment ToPath(string text)
        => new PathSegment(text);

    public static QuerySegment ToQuery(params (string key, string value)[] criteria)
        => QuerySegment.FromCriteria(criteria);

    static readonly Uri EmptyUri = new Uri("/", UriKind.Relative);

    protected override SystemUri New(string text)
        => new SystemUri(new Uri(text));

    public SchemeSegment Scheme
        => SchemeSegment.Parse(Identifier.Scheme);

    public HostSegment Host
        => HostSegment.Parse(Identifier.Host);


    public PathSegment Path
        => PathSegment.Parse(Identifier.LocalPath);

    public QuerySegment Query
        =>  QuerySegment.Parse(Identifier.Query);

    public SystemUri TrimQuery()
        => new SystemUri
            (scheme: Scheme,
               host: Identifier.Host,
               path: Identifier.LocalPath
            );

    public SystemUri WithNewScheme(SchemeSegment scheme)
        => new SystemUri(
            scheme: scheme,
            host: Identifier.Host,
            path: Identifier.LocalPath,
            query: Identifier.Query
            );

    public SystemUri WithNewSchemeComponent(int idx, string name)
        => new SystemUri(
            scheme: ToScheme(Identifier.Scheme).ReplaceComponent(idx, name),
            host: Identifier.Host,
            path: Identifier.LocalPath,
            query: Identifier.Query
            );


    public SystemUri WithNewQuery(QuerySegment query)
        => new SystemUri(
            scheme: Identifier.Scheme,
            host: Identifier.Host,
            path: Identifier.LocalPath,
            query: query
            );

    public SystemUri WithNewQuery(params (string key, string value)[] criteria)
            => new SystemUri(
                scheme: Identifier.Scheme,
                host: Identifier.Host,
                path: Identifier.LocalPath,
                query: QuerySegment.FromCriteria(criteria)
                );

    public SystemUri WithNewHost(HostSegment host)
        => new SystemUri(
            scheme: Identifier.Scheme,
            host: host,
            path: Identifier.LocalPath,
            query: Identifier.Query
            );

    public SystemUri WithNewPath(PathSegment path)
        => new SystemUri(
            scheme: Identifier.Scheme,
            host: Identifier.Host,
            path: path,
            query: Identifier.Query
            );

    public SystemUri WithAppendedPathComponts(params string[] components)
        => WithNewPath(Path.AppendComponents(components));

    SystemUri()
        :base(EmptyUri)
    {

    }
       
    public SystemUri(Uri uri)

        : base(uri)
    {
    }

    static string render(SchemeSegment scheme)
        => (scheme is null || scheme.IsEmpty) ? string.Empty : $"{scheme}://";

    static string render(HostSegment host)
        => (host is null || host.IsEmpty) ? string.Empty : $"{host}";

    static string render(PathSegment path)
        => (path is null || path.IsEmpty) ? string.Empty : $"{path}";

    static string render(QuerySegment query)
        => (query is null || query.IsEmpty) ? string.Empty : $"{query}";
    
    public SystemUri(SchemeSegment scheme, HostSegment host, PathSegment path = null, QuerySegment query = null)
        : base(new Uri(
              render(scheme)
            + render(host)
            + render(path)
            + render(query)))
    {
        
    }
}

public abstract class SystemUri<T> : ISystemUri, IEquatable<T>
    where T : SystemUri<T>
{

    public static implicit operator SystemUri(SystemUri<T> Uri)
        => Uri.Subject;

    public static implicit operator string(SystemUri<T> Uri)
        => Uri.Subject;

    protected SystemUri Subject { get; }

    protected SystemUri(SystemUri Subject)
    {
        this.Subject = Subject;
    }

    public virtual SystemUri.SchemeSegment Scheme 
        => Subject.Scheme;

    public virtual SystemUri.HostSegment Host 
        => Subject.Host;

    public virtual SystemUri.PathSegment Path 
        => Subject.Path;

    public virtual SystemUri.QuerySegment Query 
        => Subject.Query;

    public bool Equals(T other)
        => other is null 
        ? false 
        : other.Subject.Equals(Subject);

    public override int GetHashCode()
        => Subject.GetHashCode();


}

