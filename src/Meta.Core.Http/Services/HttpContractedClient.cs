//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using static Outcome;

    /// <summary>
    /// Provides implementation for invoking a contracted HTTP service
    /// </summary>
    public class HttpContractedClient : IDynamicContract
    {
        /// <summary>
        /// Creates realization of a contract via the <see cref="IDynamicContract"/> mechanism
        /// </summary>
        /// <typeparam name="T">The contract type for which a realization will be created</typeparam>
        /// <returns></returns>
        public static T Create<T>(HttpContractedClientOptions options) =>
            DynamicContract.Realize<T>(new HttpContractedClient(typeof(T), options));

        private readonly Type ContractType;
        private readonly IHttpChannel Channel;
        private readonly IHttpRequestSpecifier RequestSpecifier;
        private readonly Uri BaseAddress;

        private HttpContractedClient(Type contractType, HttpContractedClientOptions options)
        {
            this.ContractType = contractType;
            this.Channel = options.Channel;
            this.RequestSpecifier = options.RequestSpecifier;
            this.BaseAddress = Channel.BaseAddress;
        }

        /// <summary>
        /// Maps a service response onto an outcome
        /// </summary>
        /// <param name="response">The response for which an outcome will be derived</param>
        /// <returns></returns>
        private static Outcome<HttpServiceResponse> Interpret(Outcome<HttpReply> response)
        {
            if(response) 
            {
                //system succeeded
                var httpReply = response.Payload;
                return httpReply.Status.ProtocolSucceeded
                    ? success(new HttpServiceResponse(httpReply.Status, httpReply.Data), response.Description)
                    : failure<HttpServiceResponse>(response.Description);
            }
            else
            {
                //system failed
                return failure<HttpServiceResponse>(response.Description);
            }

        }

        /// <summary>
        /// Creates a <see cref="HttpRequestSpec"/> for the identified action
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private HttpRequestSpec Specify(MethodInfo method, object[] parameters) 
            =>  RequestSpecifier.SpecifyRequest(BaseAddress, method, parameters);

        /// <summary>
        /// Invokes the request, receives/formats response and returns it to the caller
        /// </summary>
        /// <param name="method">The method representing the action</param>
        /// <param name="parameters">The parameters to pass in the request</param>
        /// <returns></returns>
        object IDynamicContract.InvokeFunction(MethodInfo method, object[] parameters)
        {
            var spec = Specify(method, parameters);
            var outcome = Channel.Send(spec);
            return Interpret(outcome);;
        }


        void IDynamicContract.InvokeAction(MethodInfo method, object[] parameters)
        {
            //This will only be implemented if we expect to be able to call a service
            //without receiving a response, as in the case of a fire-and-forget notification
            //for instance
            throw new NotImplementedException();
        }

        object IDynamicContract.GetPropertyValue(PropertyInfo property)
        {
            if (property.Name == "BaseUri")
                return BaseAddress;
            else
                throw new NotSupportedException();
        }

        void IDynamicContract.SetPropertyValue(PropertyInfo property, object value)
        {
            throw new NotSupportedException();
        }


        string IDynamicContract.ImplementationName 
            => "Http Service Client (Default)";


    }

}
