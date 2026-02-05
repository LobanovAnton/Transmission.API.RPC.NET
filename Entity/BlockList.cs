using System.Text.Json.Serialization;
using Transmission.API.RPC.Arguments;

namespace Transmission.API.RPC.Entity;

public class BlockList
{
    [JsonPropertyName(SessionFields.BLOCKLIST_SIZE)]
    public int BlockListSize { get; set; }
}