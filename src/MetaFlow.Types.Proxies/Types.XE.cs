//This file was generated at 7/9/2018 7:22:04 PM using version 1.1.4.0 the SqT data access toolset.
namespace MetaFlow.XE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using SqlT.Core;

    public sealed class XETableTypeNames
    {
        public const string ArchivedPlatformNotification = "[XE].[ArchivedPlatformNotification]";
        public const string PlatformNotification = "[XE].[PlatformNotification]";
        public const string XEventDataBlock = "[XE].[XEventDataBlock]";
        public const string XEventDataType = "[XE].[XEventDataType]";
        public const string XEventLogFile = "[XE].[XEventLogFile]";
    }

    [SqlRecord("XE", "ArchivedPlatformNotification")]
    public partial class ArchivedPlatformNotification : SqlTableTypeProxy<ArchivedPlatformNotification>, IArchivedPlatformNotification
    {
        [SqlColumn("LogFile", 0), SqlTypeFacets("nvarchar", false)]
        public string LogFile
        {
            get;
            set;
        }

        [SqlColumn("LogFileCreateTS", 1), SqlTypeFacets("datetime2", false)]
        public DateTime LogFileCreateTS
        {
            get;
            set;
        }

        [SqlColumn("LogFileWriteTS", 2), SqlTypeFacets("datetime2", false)]
        public DateTime LogFileWriteTS
        {
            get;
            set;
        }

        [SqlColumn("timestamp", 3), SqlTypeFacets("datetime2", false)]
        public DateTime timestamp
        {
            get;
            set;
        }

        [SqlColumn("message", 4), SqlTypeFacets("nvarchar", false)]
        public string message
        {
            get;
            set;
        }

        [SqlColumn("error_number", 5), SqlTypeFacets("int", false)]
        public int error_number
        {
            get;
            set;
        }

        [SqlColumn("severity", 6), SqlTypeFacets("tinyint", false)]
        public byte severity
        {
            get;
            set;
        }

        [SqlColumn("client_hostname", 7), SqlTypeFacets("nvarchar", true)]
        public string client_hostname
        {
            get;
            set;
        }

        [SqlColumn("client_app_name", 8), SqlTypeFacets("nvarchar", true)]
        public string client_app_name
        {
            get;
            set;
        }

        [SqlColumn("username", 9), SqlTypeFacets("nvarchar", true)]
        public string username
        {
            get;
            set;
        }

        public ArchivedPlatformNotification()
        {
        }

        public ArchivedPlatformNotification(object[] items)
        {
            LogFile = (string)items[0];
            LogFileCreateTS = (DateTime)items[1];
            LogFileWriteTS = (DateTime)items[2];
            timestamp = (DateTime)items[3];
            message = (string)items[4];
            error_number = (int)items[5];
            severity = (byte)items[6];
            client_hostname = (string)items[7];
            client_app_name = (string)items[8];
            username = (string)items[9];
        }

        public ArchivedPlatformNotification(string LogFile, DateTime LogFileCreateTS, DateTime LogFileWriteTS, DateTime timestamp, string message, int error_number, byte severity, string client_hostname, string client_app_name, string username)
        {
            this.LogFile = LogFile;
            this.LogFileCreateTS = LogFileCreateTS;
            this.LogFileWriteTS = LogFileWriteTS;
            this.timestamp = timestamp;
            this.message = message;
            this.error_number = error_number;
            this.severity = severity;
            this.client_hostname = client_hostname;
            this.client_app_name = client_app_name;
            this.username = username;
        }

        public override object[] GetItemArray()
        {
            return new object[] { LogFile, LogFileCreateTS, LogFileWriteTS, timestamp, message, error_number, severity, client_hostname, client_app_name, username };
        }

        public override void SetItemArray(object[] items)
        {
            LogFile = (string)items[0];
            LogFileCreateTS = (DateTime)items[1];
            LogFileWriteTS = (DateTime)items[2];
            timestamp = (DateTime)items[3];
            message = (string)items[4];
            error_number = (int)items[5];
            severity = (byte)items[6];
            client_hostname = (string)items[7];
            client_app_name = (string)items[8];
            username = (string)items[9];
        }
    }

    [SqlRecord("XE", "PlatformNotification")]
    public partial class PlatformNotification : SqlTableTypeProxy<PlatformNotification>, IXEventDataType, IPlatformNotification
    {
        [SqlColumn("timestamp", 0), SqlTypeFacets("datetime2", false)]
        public DateTime timestamp
        {
            get;
            set;
        }

        [SqlColumn("message", 1), SqlTypeFacets("nvarchar", false)]
        public string message
        {
            get;
            set;
        }

        [SqlColumn("error_number", 2), SqlTypeFacets("int", false)]
        public int error_number
        {
            get;
            set;
        }

        [SqlColumn("severity", 3), SqlTypeFacets("tinyint", false)]
        public byte severity
        {
            get;
            set;
        }

        [SqlColumn("client_hostname", 4), SqlTypeFacets("nvarchar", true)]
        public string client_hostname
        {
            get;
            set;
        }

        [SqlColumn("client_app_name", 5), SqlTypeFacets("nvarchar", true)]
        public string client_app_name
        {
            get;
            set;
        }

        [SqlColumn("username", 6), SqlTypeFacets("nvarchar", true)]
        public string username
        {
            get;
            set;
        }

        public PlatformNotification()
        {
        }

        public PlatformNotification(object[] items)
        {
            timestamp = (DateTime)items[0];
            message = (string)items[1];
            error_number = (int)items[2];
            severity = (byte)items[3];
            client_hostname = (string)items[4];
            client_app_name = (string)items[5];
            username = (string)items[6];
        }

        public PlatformNotification(DateTime timestamp, string message, int error_number, byte severity, string client_hostname, string client_app_name, string username)
        {
            this.timestamp = timestamp;
            this.message = message;
            this.error_number = error_number;
            this.severity = severity;
            this.client_hostname = client_hostname;
            this.client_app_name = client_app_name;
            this.username = username;
        }

        public override object[] GetItemArray()
        {
            return new object[] { timestamp, message, error_number, severity, client_hostname, client_app_name, username };
        }

        public override void SetItemArray(object[] items)
        {
            timestamp = (DateTime)items[0];
            message = (string)items[1];
            error_number = (int)items[2];
            severity = (byte)items[3];
            client_hostname = (string)items[4];
            client_app_name = (string)items[5];
            username = (string)items[6];
        }
    }

    [SqlRecord("XE", "XEventDataBlock")]
    public partial class XEventDataBlock : SqlTableTypeProxy<XEventDataBlock>, IXEventDataBlock
    {
        [SqlColumn("object_name", 0), SqlTypeFacets("nvarchar", false)]
        public string object_name
        {
            get;
            set;
        }

        [SqlColumn("file_name", 1), SqlTypeFacets("nvarchar", false)]
        public string file_name
        {
            get;
            set;
        }

        [SqlColumn("file_offset", 2), SqlTypeFacets("int", false)]
        public int file_offset
        {
            get;
            set;
        }

        [SqlColumn("event_data", 3), SqlTypeFacets("xml", true)]
        public string event_data
        {
            get;
            set;
        }

        public XEventDataBlock()
        {
        }

        public XEventDataBlock(object[] items)
        {
            object_name = (string)items[0];
            file_name = (string)items[1];
            file_offset = (int)items[2];
            event_data = (string)items[3];
        }

        public XEventDataBlock(string object_name, string file_name, int file_offset, string event_data)
        {
            this.object_name = object_name;
            this.file_name = file_name;
            this.file_offset = file_offset;
            this.event_data = event_data;
        }

        public override object[] GetItemArray()
        {
            return new object[] { object_name, file_name, file_offset, event_data };
        }

        public override void SetItemArray(object[] items)
        {
            object_name = (string)items[0];
            file_name = (string)items[1];
            file_offset = (int)items[2];
            event_data = (string)items[3];
        }
    }

    [SqlRecord("XE", "XEventDataType")]
    public partial class XEventDataType : SqlTableTypeProxy<XEventDataType>, IXEventDataType
    {
        [SqlColumn("timestamp", 0), SqlTypeFacets("datetime2", false)]
        public DateTime timestamp
        {
            get;
            set;
        }

        public XEventDataType()
        {
        }

        public XEventDataType(object[] items)
        {
            timestamp = (DateTime)items[0];
        }

        public XEventDataType(DateTime timestamp)
        {
            this.timestamp = timestamp;
        }

        public override object[] GetItemArray()
        {
            return new object[] { timestamp };
        }

        public override void SetItemArray(object[] items)
        {
            timestamp = (DateTime)items[0];
        }
    }

    [SqlRecord("XE", "XEventLogFile")]
    public partial class XEventLogFile : SqlTableTypeProxy<XEventLogFile>, IXEventLogFile
    {
        [SqlColumn("FilePath", 0), SqlTypeFacets("nvarchar", false)]
        public string FilePath
        {
            get;
            set;
        }

        [SqlColumn("IsDirectory", 1), SqlTypeFacets("bit", false)]
        public bool IsDirectory
        {
            get;
            set;
        }

        [SqlColumn("CreationTime", 2), SqlTypeFacets("datetime2", false)]
        public DateTime CreationTime
        {
            get;
            set;
        }

        [SqlColumn("LastWriteTime", 3), SqlTypeFacets("datetime2", false)]
        public DateTime LastWriteTime
        {
            get;
            set;
        }

        [SqlColumn("Size", 4), SqlTypeFacets("bigint", false)]
        public long Size
        {
            get;
            set;
        }

        public XEventLogFile()
        {
        }

        public XEventLogFile(object[] items)
        {
            FilePath = (string)items[0];
            IsDirectory = (bool)items[1];
            CreationTime = (DateTime)items[2];
            LastWriteTime = (DateTime)items[3];
            Size = (long)items[4];
        }

        public XEventLogFile(string FilePath, bool IsDirectory, DateTime CreationTime, DateTime LastWriteTime, long Size)
        {
            this.FilePath = FilePath;
            this.IsDirectory = IsDirectory;
            this.CreationTime = CreationTime;
            this.LastWriteTime = LastWriteTime;
            this.Size = Size;
        }

        public override object[] GetItemArray()
        {
            return new object[] { FilePath, IsDirectory, CreationTime, LastWriteTime, Size };
        }

        public override void SetItemArray(object[] items)
        {
            FilePath = (string)items[0];
            IsDirectory = (bool)items[1];
            CreationTime = (DateTime)items[2];
            LastWriteTime = (DateTime)items[3];
            Size = (long)items[4];
        }
    }

    /// <summary>
    /// Declares the columns defined by the XE schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IArchivedPlatformNotification
    {
        [SqlColumn("LogFile", 0), SqlTypeFacets("nvarchar", false)]
        string LogFile
        {
            get;
            set;
        }

        [SqlColumn("LogFileCreateTS", 1), SqlTypeFacets("datetime2", false)]
        DateTime LogFileCreateTS
        {
            get;
            set;
        }

        [SqlColumn("LogFileWriteTS", 2), SqlTypeFacets("datetime2", false)]
        DateTime LogFileWriteTS
        {
            get;
            set;
        }

        [SqlColumn("timestamp", 3), SqlTypeFacets("datetime2", false)]
        DateTime timestamp
        {
            get;
            set;
        }

        [SqlColumn("message", 4), SqlTypeFacets("nvarchar", false)]
        string message
        {
            get;
            set;
        }

        [SqlColumn("error_number", 5), SqlTypeFacets("int", false)]
        int error_number
        {
            get;
            set;
        }

        [SqlColumn("severity", 6), SqlTypeFacets("tinyint", false)]
        byte severity
        {
            get;
            set;
        }

        [SqlColumn("client_hostname", 7), SqlTypeFacets("nvarchar", true)]
        string client_hostname
        {
            get;
            set;
        }

        [SqlColumn("client_app_name", 8), SqlTypeFacets("nvarchar", true)]
        string client_app_name
        {
            get;
            set;
        }

        [SqlColumn("username", 9), SqlTypeFacets("nvarchar", true)]
        string username
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the XE schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IPlatformNotification
    {
        [SqlColumn("timestamp", 0), SqlTypeFacets("datetime2", false)]
        DateTime timestamp
        {
            get;
            set;
        }

        [SqlColumn("message", 1), SqlTypeFacets("nvarchar", false)]
        string message
        {
            get;
            set;
        }

        [SqlColumn("error_number", 2), SqlTypeFacets("int", false)]
        int error_number
        {
            get;
            set;
        }

        [SqlColumn("severity", 3), SqlTypeFacets("tinyint", false)]
        byte severity
        {
            get;
            set;
        }

        [SqlColumn("client_hostname", 4), SqlTypeFacets("nvarchar", true)]
        string client_hostname
        {
            get;
            set;
        }

        [SqlColumn("client_app_name", 5), SqlTypeFacets("nvarchar", true)]
        string client_app_name
        {
            get;
            set;
        }

        [SqlColumn("username", 6), SqlTypeFacets("nvarchar", true)]
        string username
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the XE schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IXEventDataBlock
    {
        [SqlColumn("object_name", 0), SqlTypeFacets("nvarchar", false)]
        string object_name
        {
            get;
            set;
        }

        [SqlColumn("file_name", 1), SqlTypeFacets("nvarchar", false)]
        string file_name
        {
            get;
            set;
        }

        [SqlColumn("file_offset", 2), SqlTypeFacets("int", false)]
        int file_offset
        {
            get;
            set;
        }

        [SqlColumn("event_data", 3), SqlTypeFacets("xml", true)]
        string event_data
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the XE schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IXEventDataType
    {
        [SqlColumn("timestamp", 0), SqlTypeFacets("datetime2", false)]
        DateTime timestamp
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Declares the columns defined by the XE schema
    /// </summary>
    [SqlDataContract()]
    public partial interface IXEventLogFile
    {
        [SqlColumn("FilePath", 0), SqlTypeFacets("nvarchar", false)]
        string FilePath
        {
            get;
            set;
        }

        [SqlColumn("IsDirectory", 1), SqlTypeFacets("bit", false)]
        bool IsDirectory
        {
            get;
            set;
        }

        [SqlColumn("CreationTime", 2), SqlTypeFacets("datetime2", false)]
        DateTime CreationTime
        {
            get;
            set;
        }

        [SqlColumn("LastWriteTime", 3), SqlTypeFacets("datetime2", false)]
        DateTime LastWriteTime
        {
            get;
            set;
        }

        [SqlColumn("Size", 4), SqlTypeFacets("bigint", false)]
        long Size
        {
            get;
            set;
        }
    }
}
// Emission concluded at 7/9/2018 7:22:04 PM
