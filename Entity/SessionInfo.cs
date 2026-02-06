using System.Text.Json.Serialization;
using Transmission.API.RPC.Params;

namespace Transmission.API.RPC.Entity;

/// <summary>
/// Session information
/// </summary>
public class SessionInfo
{
    /// <summary>
    /// Max global download speed (KBps)
    /// </summary>
    [JsonPropertyName(SessionFields.ALT_SPEED_DOWN)]
    public int? AlternativeSpeedDown { get; set; }

    /// <summary>
    /// True means use the alt speeds
    /// </summary>
    [JsonPropertyName(SessionFields.ALT_SPEED_ENABLED)]
    public bool? AlternativeSpeedEnabled { get; set; }

    /// <summary>
    /// When to turn on alt speeds (units: minutes after midnight)
    /// </summary>
    [JsonPropertyName(SessionFields.ALT_SPEED_TIME_BEGIN)]
    public int? AlternativeSpeedTimeBegin { get; set; }

    /// <summary>
    /// True means the scheduled on/off times are used
    /// </summary>
    [JsonPropertyName(SessionFields.ALT_SPEED_TIME_ENABLED)]
    public bool? AlternativeSpeedTimeEnabled { get; set; }

    /// <summary>
    /// When to turn off alt speeds
    /// </summary>
    [JsonPropertyName(SessionFields.ALT_SPEED_TIME_END)]
    public int? AlternativeSpeedTimeEnd { get; set; }

    /// <summary>
    /// What day(s) to turn on alt speeds
    /// </summary>
    [JsonPropertyName(SessionFields.ALT_SPEED_TIME_DAY)]
    public int? AlternativeSpeedTimeDay { get; set; }

    /// <summary>
    /// Max global upload speed (KBps)
    /// </summary>
    [JsonPropertyName(SessionFields.ALT_SPEED_UP)]
    public int? AlternativeSpeedUp { get; set; }

    /// <summary>
    /// Location of the blocklist to use for "blocklist-update"
    /// </summary>
    [JsonPropertyName(SessionFields.BLOCKLIST_URL)]
    public string BlocklistUrl { get; set; }

    /// <summary>
    /// True means enabled
    /// </summary>
    [JsonPropertyName(SessionFields.BLOCKLIST_ENABLED)]
    public bool? BlocklistEnabled { get; set; }
        
    /// <summary>
    /// Number of rules in the blocklist
    /// </summary>
    [JsonPropertyName(SessionFields.BLOCKLIST_SIZE)]
    public int? BlocklistSize{ get; set; }

    /// <summary>
    /// Maximum size of the disk cache (MB)
    /// </summary>
    [JsonPropertyName(SessionFields.CACHE_SIZE_MB)]
    public int? CacheSizeMb { get; set; }
        
    /// <summary>
    /// Location of transmission's configuration directory
    /// </summary>
    [JsonPropertyName(SessionFields.CONFIG_DIR)]
    public string ConfigDirectory{ get; set; }
        
    [JsonPropertyName(SessionFields.DEFAULT_TRACKERS)]
    public string DefaultTrackers { get; set; }

    /// <summary>
    /// Default path to download torrents
    /// </summary>
    [JsonPropertyName(SessionFields.DOWNLOAD_DIR)]
    public string DownloadDirectory { get; set; }

    /// <summary>
    /// Max number of torrents to download at once (see download-queue-enabled)
    /// </summary>
    [JsonPropertyName(SessionFields.DOWNLOAD_QUEUE_SIZE)]
    public int? DownloadQueueSize { get; set; }

    /// <summary>
    /// If true, limit how many torrents can be downloaded at once
    /// </summary>
    [JsonPropertyName(SessionFields.DOWNLOAD_QUEUE_ENABLED)]
    public bool? DownloadQueueEnabled { get; set; }

    /// <summary>
    /// True means allow dht in public torrents
    /// </summary>
    [JsonPropertyName(SessionFields.DHT_ENABLED)]
    public bool? DhtEnabled { get; set; }

    /// <summary>
    /// "required", "preferred", "tolerated"
    /// </summary>
    [JsonPropertyName(SessionFields.ENCRYPTION)]
    public string Encryption { get; set; }

    /// <summary>
    /// Torrents we're seeding will be stopped if they're idle for this long
    /// </summary>
    [JsonPropertyName(SessionFields.IDLE_SEEDING_LIMIT)]
    public int? IdleSeedingLimit { get; set; }

    /// <summary>
    /// True if the seeding inactivity limit is honored by default
    /// </summary>
    [JsonPropertyName(SessionFields.IDLE_SEEDING_LIMIT_ENABLED)]
    public bool? IdleSeedingLimitEnabled { get; set; }

    /// <summary>
    /// Path for incomplete torrents, when enabled
    /// </summary>
    [JsonPropertyName(SessionFields.INCOMPLETE_DIR)]
    public string IncompleteDirectory { get; set; }

    /// <summary>
    /// True means keep torrents in incomplete-dir until done
    /// </summary>
    [JsonPropertyName(SessionFields.INCOMPLETE_DIR_ENABLED)]
    public bool? IncompleteDirectoryEnabled { get; set; }

    /// <summary>
    /// True means allow Local Peer Discovery in public torrents
    /// </summary>
    [JsonPropertyName(SessionFields.LPD_ENABLED)]
    public bool? LpdEnabled { get; set; }

    /// <summary>
    /// Maximum global number of peers
    /// </summary>
    [JsonPropertyName(SessionFields.PEER_LIMIT_GLOBAL)]
    public int? PeerLimitGlobal { get; set; }

    /// <summary>
    /// Maximum global number of peers
    /// </summary>
    [JsonPropertyName(SessionFields.PEER_LIMIT_PER_TORRENT)]
    public int? PeerLimitPerTorrent { get; set; }

    /// <summary>
    /// True means allow pex in public torrents
    /// </summary>
    [JsonPropertyName(SessionFields.PEX_ENABLED)]
    public bool? PexEnabled { get; set; }

    /// <summary>
    /// Port number
    /// </summary>
    [JsonPropertyName(SessionFields.PEER_PORT)]
    public int? PeerPort { get; set; }

    /// <summary>
    /// True means pick a random peer port on launch
    /// </summary>
    [JsonPropertyName(SessionFields.PEER_PORT_RANDOM_ON_START)]
    public bool? PeerPortRandomOnStart { get; set; }

    /// <summary>
    /// true means enabled
    /// </summary>
    [JsonPropertyName(SessionFields.PORT_FORWARDING_ENABLED)]
    public bool? PortForwardingEnabled { get; set; }

    /// <summary>
    /// Whether to consider idle torrents as stalled
    /// </summary>
    [JsonPropertyName(SessionFields.QUEUE_STALLED_ENABLED)]
    public bool? QueueStalledEnabled { get; set; }

    /// <summary>
    /// Torrents that are idle for N minutes aren't counted toward seed-queue-size or download-queue-size
    /// </summary>
    [JsonPropertyName(SessionFields.QUEUE_STALLED_MINUTES)]
    public int? QueueStalledMinutes { get; set; }

    /// <summary>
    /// True means append ".part" to incomplete files
    /// </summary>
    [JsonPropertyName(SessionFields.RENAME_PARTIAL_FILES)]
    public bool? RenamePartialFiles { get; set; }
        
    [JsonPropertyName(SessionFields.RPC_VERSION_SEMVER)]
    public string RpcVersionSemVer { get; set; }

    /// <summary>
    /// Whether to call the "done" script
    /// </summary>
    [JsonPropertyName(SessionFields.SCRIPT_TORRENT_ADDED_ENABLED)]
    public bool? ScriptTorrentAddedEnabled { get; set; }
        
    [JsonPropertyName(SessionFields.SCRIPT_TORRENT_ADDED_FILENAME)]
    public string ScriptTorrentAddedFilename { get; set; }

    /// <summary>
    /// Whether to call the "done" script
    /// </summary>
    [JsonPropertyName(SessionFields.SCRIPT_TORRENT_DONE_ENABLED)]
    public bool? ScriptTorrentDoneEnabled { get; set; }
        
    /// <summary>
    /// Filename of the script to run
    /// </summary>
    [JsonPropertyName(SessionFields.SCRIPT_TORRENT_DONE_FILENAME)]
    public string ScriptTorrentDoneFilename { get; set; }
        
    [JsonPropertyName(SessionFields.SCRIPT_TORRENT_DONE_SEEDING_ENABLED)]
    public bool? ScriptTorrentDoneSeedingEnabled { get; set; }
        
    [JsonPropertyName(SessionFields.SCRIPT_TORRENT_DONE_SEEDING_FILENAME)]
    public string ScriptTorrentDoneSeedingFilename { get; set; }

    /// <summary>
    /// The default seed ratio for torrents to use
    /// </summary>
    [JsonPropertyName(SessionFields.SEED_RATIO_LIMIT)]
    public double? SeedRatioLimit { get; set; }

    /// <summary>
    /// True if seedRatioLimit is honored by default
    /// </summary>
    [JsonPropertyName(SessionFields.SEED_RATIO_LIMITED)]
    public bool? SeedRatioLimited { get; set; }

    /// <summary>
    /// Max number of torrents to uploaded at once (see seed-queue-enabled)
    /// </summary>
    [JsonPropertyName(SessionFields.SEED_QUEUE_SIZE)]
    public int? SeedQueueSize { get; set; }

    /// <summary>
    /// If true, limit how many torrents can be uploaded at once
    /// </summary>
    [JsonPropertyName(SessionFields.SEED_QUEUE_ENABLED)]
    public bool? SeedQueueEnabled { get; set; }
        
    /// <summary>
    /// Session ID
    /// </summary>
    [JsonPropertyName(SessionFields.SEQUENTIAL_DOWNLOAD)]
    public bool SequentialDownload { get; set; }
        
    /// <summary>
    /// Session ID
    /// </summary>
    [JsonPropertyName(SessionFields.SESSION_ID)]
    public string SessionId { get; set; }

    /// <summary>
    /// Max global download speed (KBps)
    /// </summary>
    [JsonPropertyName(SessionFields.SPEED_LIMIT_DOWN)]
    public float? SpeedLimitDown { get; set; }

    /// <summary>
    /// True means enabled
    /// </summary>
    [JsonPropertyName(SessionFields.SPEED_LIMIT_DOWN_ENABLED)]
    public bool? SpeedLimitDownEnabled { get; set; }

    /// <summary>
    ///  max global upload speed (KBps)
    /// </summary>
    [JsonPropertyName(SessionFields.SPEED_LIMIT_UP)]
    public float? SpeedLimitUp { get; set; }

    /// <summary>
    /// True means enabled
    /// </summary>
    [JsonPropertyName(SessionFields.SPEED_LIMIT_UP_ENABLED)]
    public bool? SpeedLimitUpEnabled { get; set; }

    /// <summary>
    /// True means added torrents will be started right away
    /// </summary>
    [JsonPropertyName(SessionFields.START_ADDED_TORRENTS)]
    public bool? StartAddedTorrents { get; set; }

    /// <summary>
    /// True means the .torrent file of added torrents will be deleted
    /// </summary>
    [JsonPropertyName(SessionFields.TRASH_ORIGINAL_TORRENT_FILE)]
    public bool? TrashOriginalTorrentFiles { get; set; }

    /// <summary>
    /// Units
    /// </summary>
    [JsonPropertyName(SessionFields.UNITS)]
    public Units Units { get; set; }

    /// <summary>
    /// True means allow utp
    /// </summary>
    [JsonPropertyName(SessionFields.UTP_ENABLED)]
    public bool? UtpEnabled { get; set; }

    /// <summary>
    /// Long version string "$version ($revision)"
    /// </summary>
    [JsonPropertyName(SessionFields.VERSION)]
    public string Version{ get; set; }
}