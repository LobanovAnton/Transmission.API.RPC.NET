using Transmission.API.RPC.Common;

namespace Transmission.API.RPC.Arguments;

public class Group: ParamsBase
{
    public bool? HonorSessionLimit
    {
        get => GetValue<bool?>(TorrentFields.HONORS_SESSION_LIMITS);
        set => this[TorrentFields.HONORS_SESSION_LIMITS] = value;
    }
    
    public string Name
    {
        get => GetValue<string>(TorrentFields.NAME);
        set => this[TorrentFields.NAME] = value;
    }
    
    public int? SpeedLimitDown
    {
        get => GetValue<int?>(SessionFields.SPEED_LIMIT_DOWN);
        set => this[SessionFields.SPEED_LIMIT_DOWN] = value;
    }

    public bool? SpeedLimitDownEnabled
    {
        get => GetValue<bool?>(SessionFields.SPEED_LIMIT_DOWN_ENABLED);
        set => this[SessionFields.SPEED_LIMIT_DOWN_ENABLED] = value;
    }

    public int? SpeedLimitUp
    {
        get => GetValue<int?>(SessionFields.SPEED_LIMIT_UP);
        set => this[SessionFields.SPEED_LIMIT_UP] = value;
    }

    public bool? SpeedLimitUpEnabled
    {
        get => GetValue<bool?>(SessionFields.SPEED_LIMIT_UP_ENABLED);
        set => this[SessionFields.SPEED_LIMIT_UP_ENABLED] = value;
    }
}