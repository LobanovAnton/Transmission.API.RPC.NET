using System.Text.Json;
using System.Text.Json.Serialization;

namespace Transmission.API.RPC.Common;

public class ErrorData
{
	[JsonPropertyName("error_string")]
	public string ErrorString { get; set; }
}
	
public class TransmissionError
{
	[JsonPropertyName("code")]
	public int Code { get; set; }
		
	[JsonPropertyName("message")]
	public string Message { get; set; }
		
	[JsonPropertyName("data")]
	public ErrorData ErrorData { get; set; }
}
	
/// <summary>
/// Transmission response 
/// </summary>
public class TransmissionResponse : CommunicateBase
{
	[JsonPropertyName("error")] 
	[JsonInclude]
	public TransmissionError Error;
		
	/// <summary>
	/// Data
	/// </summary>
	[JsonPropertyName("result")]
	[JsonInclude]
	public JsonDocument Result;
}