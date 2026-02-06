using System.Text.Json.Serialization;

namespace Transmission.API.RPC.Common;

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
	public required string Method;
		
	/// <summary>
	/// Data
	/// </summary>
	[JsonPropertyName("params")]
	[JsonInclude]
	public Parameters Parameters;
}