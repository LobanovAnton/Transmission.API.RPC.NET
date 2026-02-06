using System.Text.Json.Serialization;

namespace Transmission.API.RPC.Common;

/// <summary>
/// Base class for request/response
/// </summary>
public abstract class CommunicateBase
{
    [JsonPropertyName("jsonrpc")] 
    [JsonInclude]
    public string JsonRpc  = "2.0";

    /// <summary>
    /// Number (id)
    /// </summary>
    [JsonPropertyName("id")] 
    [JsonInclude] 
    public int Id;
}