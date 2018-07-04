//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
public struct ShellIdentity
{
    public ShellIdentity(string Host, string ShellName)
    {
        this.Host = Host;
        this.ShellName = ShellName;
    }

    public string Host { get; }


    public string ShellName { get; }


    public override string ToString()
        => $"{Host}/shells/{ShellName}";

    public override int GetHashCode()
        => ToString().GetHashCode();
}
