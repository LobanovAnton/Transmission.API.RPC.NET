using Transmission.API.RPC.Common;

namespace Transmission.API.RPC.Params;

/// <summary>
/// Settings
/// </summary>
public class SessionSettings : Parameters
{
    /// <summary>
    /// Max global download speed (KBps)
    /// </summary>
    public int? AlternativeSpeedDown 
    {
        get => GetValue<int?>(SessionFields.ALT_SPEED_DOWN);
        set => this[SessionFields.ALT_SPEED_DOWN] = value;
    }

    /// <summary>
    /// True means use the alt speeds
    /// </summary>
    public bool? AlternativeSpeedEnabled
    {
        get => GetValue<bool?>(SessionFields.ALT_SPEED_ENABLED);
        set => this[SessionFields.ALT_SPEED_ENABLED] = value;
    }

    /// <summary>
    /// When to turn on alt speeds (units: minutes after midnight)
    /// </summary>
    public int? AlternativeSpeedTimeBegin
    {
        get => GetValue<int?>(SessionFields.ALT_SPEED_TIME_BEGIN);
        set => this[SessionFields.ALT_SPEED_TIME_BEGIN] = value;
    }

    /// <summary>
    /// True means the scheduled on/off times are used
    /// </summary>
    public bool? AlternativeSpeedTimeEnabled
    {
        get => GetValue<bool?>(SessionFields.ALT_SPEED_TIME_ENABLED);
        set => this[SessionFields.ALT_SPEED_TIME_ENABLED] = value;
    }

    /// <summary>
    /// When to turn off alt speeds
    /// </summary>
    public int? AlternativeSpeedTimeEnd
    {
        get => GetValue<int?>(SessionFields.ALT_SPEED_TIME_END);
        set => this[SessionFields.ALT_SPEED_TIME_END] = value;
    }

    /// <summary>
    /// What day(s) to turn on alt speeds
    /// </summary>
    public int? AlternativeSpeedTimeDay
    {
        get => GetValue<int?>(SessionFields.ALT_SPEED_TIME_DAY);
        set => this[SessionFields.ALT_SPEED_TIME_DAY] = value;
    }

    /// <summary>
    /// Max global upload speed (KBps)
    /// </summary>
    public int? AlternativeSpeedUp
    {
        get => GetValue<int?>(SessionFields.ALT_SPEED_UP);
        set => this[SessionFields.ALT_SPEED_UP] = value;
    }

    /// <summary>
    /// Location of the blocklist to use for "blocklist-update"
    /// </summary>
    public string BlocklistUrl
    {
        get => GetValue<string>(SessionFields.BLOCKLIST_URL);
        set => this[SessionFields.BLOCKLIST_URL] = value;
    }

    /// <summary>
    /// True means enabled
    /// </summary>
    public bool? BlocklistEnabled 
    { 
        get => GetValue<bool?>(SessionFields.BLOCKLIST_ENABLED);
        set => this[SessionFields.BLOCKLIST_ENABLED] = value;
    }

    /// <summary>
    /// Maximum size of the disk cache (MB)
    /// </summary>
    public int? CacheSizeMb
    {
        get => GetValue<int?>(SessionFields.CACHE_SIZE_MB);
        set => this[SessionFields.CACHE_SIZE_MB] = value;
    }
        
    public string DefaultTrackers
    {
        get => GetValue<string>(SessionFields.DEFAULT_TRACKERS);
        set => this[SessionFields.DEFAULT_TRACKERS] = value;
    }

    /// <summary>
    /// Default path to download torrents
    /// </summary>
    public string DownloadDirectory
    {
        get => GetValue<string>(SessionFields.DOWNLOAD_DIR);
        set => this[SessionFields.DOWNLOAD_DIR] = value;
    }

    /// <summary>
    /// Max number of torrents to download at once (see download-queue-enabled)
    /// </summary>
    public int? DownloadQueueSize
    {
        get => GetValue<int?>(SessionFields.DOWNLOAD_QUEUE_SIZE);
        set => this[SessionFields.DOWNLOAD_QUEUE_SIZE] = value;
    }

    /// <summary>
    /// If true, limit how many torrents can be downloaded at once
    /// </summary>
    public bool? DownloadQueueEnabled
    {
        get => GetValue<bool?>(SessionFields.DOWNLOAD_QUEUE_ENABLED);
        set => this[SessionFields.DOWNLOAD_QUEUE_ENABLED] = value;
    }

    /// <summary>
    /// True means allow dht in public torrents
    /// </summary>
    public bool? DhtEnabled
    {
        get => GetValue<bool?>(SessionFields.DHT_ENABLED);
        set => this[SessionFields.DHT_ENABLED] = value;
    }

    /// <summary>
    /// "required", "preferred", "tolerated"
    /// </summary>
    public string Encryption
    {
        get => GetValue<string>(SessionFields.ENCRYPTION);
        set => this[SessionFields.ENCRYPTION] = value;
    }

    /// <summary>
    /// Torrents we're seeding will be stopped if they're idle for this long
    /// </summary>
    public int? IdleSeedingLimit
    {
        get => GetValue<int?>(SessionFields.IDLE_SEEDING_LIMIT);
        set => this[SessionFields.IDLE_SEEDING_LIMIT] = value;
    }

    /// <summary>
    /// True if the seeding inactivity limit is honored by default
    /// </summary>
    public bool? IdleSeedingLimitEnabled
    {
        get => GetValue<bool?>(SessionFields.IDLE_SEEDING_LIMIT_ENABLED);
        set => this[SessionFields.IDLE_SEEDING_LIMIT_ENABLED] = value;
    }

    /// <summary>
    /// Path for incomplete torrents, when enabled
    /// </summary>
    public string IncompleteDirectory
    {
        get => GetValue<string>(SessionFields.INCOMPLETE_DIR);
        set => this[SessionFields.INCOMPLETE_DIR] = value;
    }

    /// <summary>
    /// True means keep torrents in incomplete-dir until done
    /// </summary>
    public bool? IncompleteDirectoryEnabled
    {
        get => GetValue<bool?>(SessionFields.INCOMPLETE_DIR_ENABLED);
        set => this[SessionFields.INCOMPLETE_DIR_ENABLED] = value;
    }

    /// <summary>
    /// True means allow Local Peer Discovery in public torrents
    /// </summary>
    public bool? LpdEnabled
    {
        get => GetValue<bool?>(SessionFields.LPD_ENABLED);
        set => this[SessionFields.LPD_ENABLED] = value;
    }

    /// <summary>
    /// Maximum global number of peers
    /// </summary>
    public int? PeerLimitGlobal
    {
        get => GetValue<int?>(SessionFields.PEER_LIMIT_GLOBAL);
        set => this[SessionFields.PEER_LIMIT_GLOBAL] = value;
    }

    /// <summary>
    /// Maximum global number of peers
    /// </summary>
    public int? PeerLimitPerTorrent
    {
        get => GetValue<int?>(SessionFields.PEER_LIMIT_PER_TORRENT);
        set => this[SessionFields.PEER_LIMIT_PER_TORRENT] = value;
    }

    /// <summary>
    /// True means allow pex in public torrents
    /// </summary>
    public bool? PexEnabled
    {
        get => GetValue<bool?>(SessionFields.PEX_ENABLED);
        set => this[SessionFields.PEX_ENABLED] = value;
    }

    /// <summary>
    /// Port number
    /// </summary>
    public int? PeerPort
    {
        get => GetValue<int?>(SessionFields.PEER_PORT);
        set => this[SessionFields.PEER_PORT] = value;
    }

    /// <summary>
    /// True means pick a random peer port on launch
    /// </summary>
    public bool? PeerPortRandomOnStart
    {
        get => GetValue<bool?>(SessionFields.PEER_PORT_RANDOM_ON_START);
        set => this[SessionFields.PEER_PORT_RANDOM_ON_START] = value;
    }

    /// <summary>
    /// true means enabled
    /// </summary>
    public bool? PortForwardingEnabled
    {
        get => GetValue<bool?>(SessionFields.PORT_FORWARDING_ENABLED);
        set => this[SessionFields.PORT_FORWARDING_ENABLED] = value;
    }

    /// <summary>
    /// Whether to consider idle torrents as stalled
    /// </summary>
    public bool? QueueStalledEnabled
    {
        get => GetValue<bool?>(SessionFields.QUEUE_STALLED_ENABLED);
        set => this[SessionFields.QUEUE_STALLED_ENABLED] = value;
    }

    /// <summary>
    /// Torrents that are idle for N minutes aren't counted toward seed-queue-size or download-queue-size
    /// </summary>
    public int? QueueStalledMinutes
    {
        get => GetValue<int?>(SessionFields.QUEUE_STALLED_MINUTES);
        set => this[SessionFields.QUEUE_STALLED_MINUTES] = value;
    }

    /// <summary>
    /// True means append ".part" to incomplete files
    /// </summary>
    public bool? RenamePartialFiles
    {
        get => GetValue<bool?>(SessionFields.RENAME_PARTIAL_FILES);
        set => this[SessionFields.RENAME_PARTIAL_FILES] = value;
    }
        
    public bool? ScriptTorrentAddedEnabled
    {
        get => GetValue<bool?>(SessionFields.SCRIPT_TORRENT_ADDED_ENABLED);
        set => this[SessionFields.SCRIPT_TORRENT_ADDED_ENABLED] = value;
    }
        
    public string ScriptTorrentAddedFilename
    {
        get => GetValue<string>(SessionFields.SCRIPT_TORRENT_ADDED_FILENAME);
        set => this[SessionFields.SCRIPT_TORRENT_ADDED_FILENAME] = value;
    }
        
    /// <summary>
    /// Whether to call the "done" script
    /// </summary>
    public bool? ScriptTorrentDoneEnabled
    {
        get => GetValue<bool?>(SessionFields.SCRIPT_TORRENT_DONE_ENABLED);
        set => this[SessionFields.SCRIPT_TORRENT_DONE_ENABLED] = value;
    }

    /// <summary>
    /// Filename of the script to run
    /// </summary>
    public string ScriptTorrentDoneFilename
    {
        get => GetValue<string>(SessionFields.SCRIPT_TORRENT_DONE_FILENAME);
        set => this[SessionFields.SCRIPT_TORRENT_DONE_FILENAME] = value;
    }
        
    public bool? ScriptTorrentDoneSeedingEnabled
    {
        get => GetValue<bool?>(SessionFields.SCRIPT_TORRENT_DONE_SEEDING_ENABLED);
        set => this[SessionFields.SCRIPT_TORRENT_DONE_SEEDING_ENABLED] = value;
    }
        
    public string ScriptTorrentDoneSeedingFilename
    {
        get => GetValue<string>(SessionFields.SCRIPT_TORRENT_DONE_SEEDING_FILENAME);
        set => this[SessionFields.SCRIPT_TORRENT_DONE_SEEDING_FILENAME] = value;
    }

    /// <summary>
    /// The default seed ratio for torrents to use
    /// </summary>
    public double? SeedRatioLimit
    {
        get => GetValue<int?>(SessionFields.SEED_RATIO_LIMIT);
        set => this[SessionFields.SEED_RATIO_LIMIT] = value;
    }

    /// <summary>
    /// True if seedRatioLimit is honored by default
    /// </summary>
    public bool? SeedRatioLimited
    {
        get => GetValue<bool?>(SessionFields.SEED_RATIO_LIMITED);
        set => this[SessionFields.SEED_RATIO_LIMITED] = value;
    }

    /// <summary>
    /// Max number of torrents to uploaded at once (see seed-queue-enabled)
    /// </summary>
    public int? SeedQueueSize
    {
        get => GetValue<int?>(SessionFields.SEED_QUEUE_SIZE);
        set => this[SessionFields.SEED_QUEUE_SIZE] = value;
    }

    /// <summary>
    /// If true, limit how many torrents can be uploaded at once
    /// </summary>
    public bool? SeedQueueEnabled
    {
        get => GetValue<bool?>(SessionFields.SEED_QUEUE_ENABLED);
        set => this[SessionFields.SEED_QUEUE_ENABLED] = value;
    }
        
    public bool? SequentialDownload
    {
        get => GetValue<bool?>(SessionFields.SEQUENTIAL_DOWNLOAD);
        set => this[SessionFields.SEQUENTIAL_DOWNLOAD] = value;
    }

    /// <summary>
    /// Max global download speed (KBps)
    /// </summary>
    public int? SpeedLimitDown
    {
        get => GetValue<int?>(SessionFields.SPEED_LIMIT_DOWN);
        set => this[SessionFields.SPEED_LIMIT_DOWN] = value;
    }

    /// <summary>
    /// True means enabled
    /// </summary>
    public bool? SpeedLimitDownEnabled
    {
        get => GetValue<bool?>(SessionFields.SPEED_LIMIT_DOWN_ENABLED);
        set => this[SessionFields.SPEED_LIMIT_DOWN_ENABLED] = value;
    }

    /// <summary>
    ///  max global upload speed (KBps)
    /// </summary>
    public int? SpeedLimitUp
    {
        get => GetValue<int?>(SessionFields.SPEED_LIMIT_UP);
        set => this[SessionFields.SPEED_LIMIT_UP] = value;
    }

    /// <summary>
    /// True means enabled
    /// </summary>
    public bool? SpeedLimitUpEnabled
    {
        get => GetValue<bool?>(SessionFields.SPEED_LIMIT_UP_ENABLED);
        set => this[SessionFields.SPEED_LIMIT_UP_ENABLED] = value;
    }

    /// <summary>
    /// True means added torrents will be started right away
    /// </summary>
    public bool? StartAddedTorrents
    {
        get => GetValue<bool?>(SessionFields.START_ADDED_TORRENTS);
        set => this[SessionFields.START_ADDED_TORRENTS] = value;
    }

    /// <summary>
    /// True means the .torrent file of added torrents will be deleted
    /// </summary>
    public bool? TrashOriginalTorrentFiles
    {
        get => GetValue<bool?>(SessionFields.TRASH_ORIGINAL_TORRENT_FILE);
        set => this[SessionFields.TRASH_ORIGINAL_TORRENT_FILE] = value;
    }

    /// <summary>
    /// True means allow utp
    /// </summary>
    public bool? UtpEnabled
    {
        get => GetValue<bool?> (SessionFields.UTP_ENABLED);
        set => this[SessionFields.UTP_ENABLED] = value;
    }
}