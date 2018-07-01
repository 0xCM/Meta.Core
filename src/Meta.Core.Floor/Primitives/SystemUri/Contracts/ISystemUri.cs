//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
public interface ISystemUri
{
    SystemUri.SchemeSegment Scheme { get; }

    SystemUri.HostSegment Host { get; }

    SystemUri.PathSegment Path { get; }

    SystemUri.QuerySegment Query { get; }
}

