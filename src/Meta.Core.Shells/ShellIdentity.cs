//-------------------------------------------------------------------------------------------
// PDMS Component Source
// Initial Contributor: Chris Moore, Chris.Moore@RealPage.com
// Subsequent Contributors: <NoneYet/>
// QOTD: Measure thrice before you slice to save your head from the dreaded vice
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
