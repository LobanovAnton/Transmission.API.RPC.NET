using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Transmission.API.RPC.Common
{
	/// <summary>
	/// Transmission request 
	/// </summary>
	public class TransmissionRequest : CommunicateBase
	{
		/// <summary>
		/// Name of the method to invoke
		/// </summary>
		[JsonPropertyName("method")]
		[JsonInclude]
		public string Method;
		
		/// <summary>
		/// Data
		/// </summary>
		[JsonPropertyName("params")]
		[JsonInclude]
		public Dictionary<string, object> Params;

        /// <summary>
        /// Initialize request
        /// </summary>
        /// <param name="method">Method name</param>
        public TransmissionRequest(string method)
        {
            Method = method;
        }

        /// <summary>
        /// Initialize request 
        /// </summary>
        /// <param name="method">Method name</param>
        /// <param name="params">Arguments</param>
		public TransmissionRequest(string method, ParamsBase @params)
		{
			Method = method;
			Params = @params.Data;
		}

        /// <summary>
        /// Initialize request 
        /// </summary>
        /// <param name="method">Method name</param>
        /// <param name="params">Arguments</param>
        public TransmissionRequest(string method, Dictionary<string, object> @params)
        {
            Method = method;
            Params = @params;
        }
	}
}
