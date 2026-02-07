using System.Text.Json.Serialization;
using Transmission.API.RPC.Params;

namespace Transmission.API.RPC.Entity;

public class GroupsInfo
{
    [JsonPropertyName(TorrentFields.GROUP)]
    public GroupInfo[] Group { get; set; }
}

public class GroupInfo
{
    [JsonPropertyName(TorrentFields.HONORS_SESSION_LIMITS)]
    public bool HonorSessionLimits { get; set; }
    
    [JsonPropertyName(TorrentFields.NAME)]
    public string Name { get; set; }
    
    [JsonPropertyName(SessionFields.SPEED_LIMIT_DOWN)]
    public float SpeedLimitDown { get; set; }
    
    [JsonPropertyName(SessionFields.SPEED_LIMIT_DOWN_ENABLED)]
    public bool SpeedLimitDownEnabled { get; set; }
    
    [JsonPropertyName(SessionFields.SPEED_LIMIT_UP)]
    public float SpeedLimitUp { get; set; }
    
    [JsonPropertyName(SessionFields.SPEED_LIMIT_UP_ENABLED)]
    public bool SpeedLimitUpEnabled { get; set; }
}