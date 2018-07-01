//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

/// <summary>
/// Base type for generated file system resources
/// </summary>
public abstract class FileSystemResource
{

    public FolderPath Location
    {
        get
        {
            var type = GetType();
            var segments = MutableList.Create<string>();
            while (type != null && type.Name != "lib")
            {
                segments.Add(type.Name.Replace('_', '-'));
                type = type.DeclaringType;
            }
            segments.Reverse();
            var relativePath = RelativePath.Parse(string.Join("\\", segments));
            var location = CommonFolders.DevAssets + relativePath;
            return location;

        }
    }
}
