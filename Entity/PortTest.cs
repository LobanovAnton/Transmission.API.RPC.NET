using System.Text.Json.Serialization;
using Transmission.API.RPC.Arguments;

namespace Transmission.API.RPC.Entity;

public class PortTest
{
    [JsonPropertyName(ApiFields.IP_PROTOCOL)]
    public string IpProtocol { get; set; }
    
    [JsonPropertyName(ApiFields.PORT_IS_OPEN)]
    public bool PortIsOpen { get; set; }
}