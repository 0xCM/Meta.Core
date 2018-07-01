//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Messaging
{
    public interface IMessageParser
    {
        object Parse(string canonical);
    }

    public interface IMessageParser<out M>
        where M : new()
    {
        M Parse(string canonical);
    }

    partial class MessageDelegates
    {

        delegate object Parse(string canonical);

        delegate M Parse<out M>(string canonical)
            where M : new()
            ;
    }
}
