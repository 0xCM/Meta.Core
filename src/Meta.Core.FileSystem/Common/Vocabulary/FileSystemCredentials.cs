//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using static metacore;

/// <summary>
/// Defines file system access credentials
/// </summary>
public class FileSystemCredentials : ValueObject<FileSystemCredentials>
{
    FileSystemCredentials() { }

    public FileSystemCredentials(string Domain, string Username, string Password)
    {
        this.Domain = Domain;
        this.Username = Username;
        this.Password = Password;
    }

    public FileSystemCredentials(string Username, string Password)
    {
        this.Username = Username;
        this.Password = Password;
    }

    /// <summary>
    /// The domain name
    /// </summary>
    public string Domain { get; }

    /// <summary>
    /// The username
    /// </summary>
    public string Username { get; }

    /// <summary>
    /// The password
    /// </summary>
    public string Password { get; }

    public override string ToString()
        => isNull(Domain)
        ? $@"({Domain}\{Username},{Password})"
        : $@"({Username},{Password})";
}
