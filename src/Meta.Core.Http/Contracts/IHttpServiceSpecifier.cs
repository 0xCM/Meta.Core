//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Http
{
    /// <summary>
    /// Defines contract for a service specifier, which is a component that
    /// characterizes aspects of an HTTP service that enables 
    /// client/server communication
    /// </summary>
    public interface IHttpServiceSpecifier
    {
        /// <summary>
        /// Gets the <see cref="HttpServiceSpec"/>
        /// </summary>
        /// <returns></returns>
        HttpServiceSpec ServiceSpecification { get; }

        /// <summary>
        /// Gets the component that can create request specifications
        /// </summary>
        /// <returns></returns>
        IHttpRequestSpecifier GetRequestSpecifier();

        /// <summary>
        /// Gets the <see cref="HttpParameterIndex"/>
        /// </summary>
        /// <returns></returns>
        HttpParameterIndex ParameterIndex { get; }
    }

}
