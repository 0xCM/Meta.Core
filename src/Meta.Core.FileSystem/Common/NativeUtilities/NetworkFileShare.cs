//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Net;
using System.ComponentModel;
using System.Runtime.InteropServices;

/// <summary>
/// Facilitates transferring files via a share
/// </summary>
/// <remarks>
/// Adapted from: http://stackoverflow.com/questions/295538/how-to-provide-user-name-and-password-when-connecting-to-a-network-share
/// </remarks>
public class NetworkFileShare : IDisposable
{
    string _networkName;

    public static int MapDrive(string DriveLetter, string SharePath, string username = null, string password = null)
    {
        NetResource r = new NetResource();
        r.ResourceType = ResourceType.Disk;
        r.LocalName = DriveLetter + ":";
        r.RemoteName = SharePath;
        r.Provider = null;

        var flags = ConnectFlags.SaveCredentials | ConnectFlags.UpdateProfile;
        return WNetAddConnection2(r, username, password, (int)flags);
    }

    public NetworkFileShare(string networkName, NetworkCredential credentials)
    {
        _networkName = networkName;

        var netResource = new NetResource()
        {
            Scope = ResourceScope.GlobalNetwork,
            ResourceType = ResourceType.Disk,
            DisplayType = ResourceDisplaytype.Share,
            RemoteName = networkName
        };

        var userName = string.IsNullOrEmpty(credentials.Domain)
            ? credentials.UserName
            : string.Format(@"{0}\{1}", credentials.Domain, credentials.UserName);

        var result = WNetAddConnection2(
            netResource,
            credentials.Password,
            userName,
            0);

        if (result != 0)
        {
            throw new Win32Exception(result, "Error connecting to remote share");
        }
    }

    ~NetworkFileShare()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        WNetCancelConnection2(_networkName, 0, true);
    }

    [DllImport("mpr.dll")]
    private static extern int WNetAddConnection2(NetResource netResource, string password, string username, int flags);

    [DllImport("mpr.dll")]
    private static extern int WNetCancelConnection2(string name, int flags,
        bool force);


    [DllImport("mpr.dll")]
    static extern UInt32 WNetAddConnection3(
        IntPtr hWndOwner, ref NetResource netResource, string password, string username,
        uint flags);


    [StructLayout(LayoutKind.Sequential)]
    public class NetResource
    {
        public ResourceScope Scope;
        public ResourceType ResourceType;
        public ResourceDisplaytype DisplayType;
        public int Usage;
        public string LocalName;
        public string RemoteName;
        public string Comment;
        public string Provider;
    }

    public enum ResourceScope : int
    {
        Connected = 1,
        GlobalNetwork,
        Remembered,
        Recent,
        Context
    };

    public enum ResourceType : int
    {
        Any = 0,
        Disk = 1,
        Print = 2,
        Reserved = 8,
    }

    public enum ResourceDisplaytype : int
    {
        Generic = 0x0,
        Domain = 0x01,
        Server = 0x02,
        Share = 0x03,
        File = 0x04,
        Group = 0x05,
        Network = 0x06,
        Root = 0x07,
        Shareadmin = 0x08,
        Directory = 0x09,
        Tree = 0x0a,
        Ndscontainer = 0x0b
    }

    [Flags]
    public enum ConnectFlags : uint
    {
        UpdateProfile = 0x1,
        Interactive = 0x8,
        Prompt = 0x10,
        Redirect = 0x80,
        CommandLine = 0x800,
        SaveCredentials = 0x1000,
    }
}