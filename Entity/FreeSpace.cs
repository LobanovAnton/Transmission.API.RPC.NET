using System.Text.Json.Serialization;
using Transmission.API.RPC.Arguments;

namespace Transmission.API.RPC.Entity;

public class FreeSpace
{
    [JsonPropertyName(ApiFields.PATH)]
    public string Path { get; set; }
    
    [JsonPropertyName(ApiFields.SIZE_BYTES)]
    public long SizeBytes { get; set; }
    
    [JsonPropertyName(TorrentFields.TOTAL_SIZE)]
    public long TotalSize { get; set; }
}