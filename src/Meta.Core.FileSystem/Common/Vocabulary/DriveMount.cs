//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using static metacore;

/// <summary>
/// Designates a file system mount, predicated either on a drive letter or folder path
/// </summary>
public struct DriveMount  
{
    public DriveMount(DriveLetter Location)        
        => this.Location = (Location, none<FolderPath>());

    public DriveMount(FolderPath Location)        
        => this.Location = (none<DriveLetter>(),Location);

    public (Option<DriveLetter> Drive, Option<FolderPath> Folder)  Location { get; }

    public override string ToString()
        => Location.ToString();
}
