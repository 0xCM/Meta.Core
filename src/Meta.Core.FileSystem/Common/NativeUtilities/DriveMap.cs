//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;

using static metacore;

/// <summary>
/// Defines references to unmanaged win API functions that facilitiate drive mapping
/// </summary>
public static class DriveMap
{

    [DllImport("mpr.dll")]
    static extern UInt32 WNetAddConnection2(ref NETRESOURCE lpNetResource, string lpPassword, string lpUsername, uint dwFlags);

    [DllImport("mpr.dll")]
    static extern uint WNetCancelConnection2(string lpName, uint dwFlags, bool bForce);


    /// <summary>
    /// See https://msdn.microsoft.com/en-us/library/windows/desktop/ms681382(v=vs.85).aspx
    /// </summary>
    public static class ErrorCodes
    {
        public const uint ERROR_SUCCESS = 0;
    }

    public static class ConnectionFlags
    {
        /// <summary>
        /// If set, indicates that the mapping should be persistent
        /// </summary>
        public const uint CONNECT_UPDATE_PROFILE = 0x1;

        /// <summary>
        /// If set, indicates that the OS can request user to 
        /// authenticate prior to mapping
        /// </summary>
        public const uint CONNECT_INTERACTIVE = 0x8;

        /// <summary>
        /// If set, indicates that the OS will always allow user to 
        /// provide credentials before default credentials are used
        /// by OS
        /// </summary>
        public const uint CONNECT_PROMPT = 0x10;
        public const uint CONNECT_REDIRECT = 0x80;
        
        /// <summary>
        /// If set, OS must request any required credential information
        /// via the command line
        /// </summary>
        public const uint CONNECT_COMMANDLINE = 0x800;

        public const uint CONNECT_CMD_SAVECRED = 0x1000;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETRESOURCE
    {
        public uint dwScope;
        public uint dwType;
        public uint dwDisplayType;
        public uint dwUsage;
        public string lpLocalName;
        public string lpRemoteName;
        public string lpComment;
        public string lpProvider;
    }

    const uint RESOURCETYPE_DISK = 1;


    /// <summary>
    /// Maps a drive letter to a UNC path
    /// </summary>
    /// <param name="Drive">The drive to map</param>
    /// <param name="UncPath">The unc path to assign to the drive</param>
    /// <remarks>
    /// Adapted from http://www.blackwasp.co.uk/MapDriveLetter.aspx
    /// </remarks>
    public static Option<DriveMount> Map(this DriveLetter Drive, string UncPath, string UserName = null, string UserPass = null)
    {

        var networkResource = new NETRESOURCE();        
        networkResource.dwType = RESOURCETYPE_DISK;
        networkResource.lpLocalName = Drive.ToString();
        networkResource.lpRemoteName = UncPath;
        networkResource.lpProvider = null;
        var result = WNetAddConnection2(ref networkResource, UserName, UserPass, ConnectionFlags.CONNECT_UPDATE_PROFILE);
        return
            result == ErrorCodes.ERROR_SUCCESS
                    ? some(new DriveMount(Drive))
                    : none<DriveMount>(error("WinAPI call failed"));
    }

    /// <summary>
    /// Deletes a mapped drive
    /// </summary>
    /// <param name="Drive"></param>
    /// <returns></returns>
    public static Option<DriveLetter> UnMap(this DriveLetter Drive)
    {
        var result = WNetCancelConnection2(Drive.ToString(), ConnectionFlags.CONNECT_UPDATE_PROFILE, false);
        return 
            result == ErrorCodes.ERROR_SUCCESS 
                    ? some(Drive) 
                    : none<DriveLetter>(error("WinAPI call failed"));        
    }

}