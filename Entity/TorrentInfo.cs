using System.Text.Json.Serialization;
using Transmission.API.RPC.Params;

namespace Transmission.API.RPC.Entity;

/// <summary>
/// Torrent information
/// </summary>
public class TorrentInfo
{
    /// <summary>
    /// The torrent's unique Id.
    /// </summary>
    [JsonPropertyName(TorrentFields.ID)]
    public int Id { get; set; }

    /// <summary>
    /// Activity date
    /// </summary>
    [JsonPropertyName(TorrentFields.ACTIVITY_DATE)]
    public long ActivityDate { get; set; }

    /// <summary>
    /// Added date
    /// </summary>
    [JsonPropertyName(TorrentFields.ADDED_DATE)]
    public long AddedDate { get; set; }
        
    [JsonPropertyName(TorrentFields.AVAILABILITY)]
    public int[] Availability { get; set; }

    /// <summary>
    /// Torrents bandwidth priority
    /// </summary>
    [JsonPropertyName(TorrentFields.BANDWIDTH_PRIORITY)]
    public int BandwidthPriority { get; set; }
        
    [JsonPropertyName(TorrentFields.BYTES_COMPLETED)]
    public long[] BytesCompleted { get; set; }

    /// <summary>
    /// Comment
    /// </summary>
    [JsonPropertyName(TorrentFields.COMMENT)]
    public string Comment { get; set; }

    /// <summary>
    /// Corrupt ever
    /// </summary>
    [JsonPropertyName(TorrentFields.CORRUPT_EVER)]
    public long CorruptEver { get; set; }

    /// <summary>
    /// Creator
    /// </summary>
    [JsonPropertyName(TorrentFields.CREATOR)]
    public string Creator { get; set; }

    /// <summary>
    /// Date created
    /// </summary>
    [JsonPropertyName(TorrentFields.DATE_CREATED)]
    public long DateCreated { get; set; }

    /// <summary>
    /// Desired available
    /// </summary>
    [JsonPropertyName(TorrentFields.DESIRED_AVAILABLE)]
    public long DesiredAvailable { get; set; }

    /// <summary>
    /// Done date
    /// </summary>
    [JsonPropertyName(TorrentFields.DONE_DATE)]
    public long DoneDate { get; set; }

    /// <summary>
    /// Download directory
    /// </summary>
    [JsonPropertyName(TorrentFields.DOWNLOAD_DIR)]
    public string DownloadDir { get; set; }

    /// <summary>
    /// Downloaded ever
    /// </summary>
    [JsonPropertyName(TorrentFields.DOWNLOADED_EVER)]
    public long DownloadedEver { get; set; }

    /// <summary>
    /// Download limit
    /// </summary>
    [JsonPropertyName(TorrentFields.DOWNLOAD_LIMIT)]
    public int DownloadLimit { get; set; }

    /// <summary>
    /// Download limited
    /// </summary>
    [JsonPropertyName(TorrentFields.DOWNLOAD_LIMITED)]
    public bool DownloadLimited { get; set; }

    /// <summary>
    /// Edit date
    /// </summary>
    [JsonPropertyName(TorrentFields.EDIT_DATE)]
    public long EditDate { get; set; }

    /// <summary>
    /// Error
    /// </summary>
    [JsonPropertyName(TorrentFields.ERROR)]
    public int Error { get; set; }

    /// <summary>
    /// Error string
    /// </summary>
    [JsonPropertyName(TorrentFields.ERROR_STRING)]
    public string ErrorString { get; set; }

    /// <summary>
    /// ETA
    /// </summary>
    [JsonPropertyName(TorrentFields.ETA)]
    public int Eta { get; set; }

    /// <summary>
    /// ETA idle
    /// </summary>
    [JsonPropertyName(TorrentFields.ETA_IDLE)]
    public int EtaIdle { get; set; }

    /// <summary>
    /// File count
    /// </summary>
    [JsonPropertyName(TorrentFields.FILE_COUNT)]
    public int FileCount { get; set; }

    /// <summary>
    /// Files
    /// </summary>
    [JsonPropertyName(TorrentFields.FILES)]
    public TransmissionTorrentFiles[] Files { get; set; }

    /// <summary>
    /// File stats
    /// </summary>
    [JsonPropertyName(TorrentFields.FILE_STATS)]
    public TransmissionTorrentFileStats[] FileStats { get; set; }
        
    [JsonPropertyName(TorrentFields.GROUP)]
    public string Group { get; set; }

    /// <summary>
    /// Hash string
    /// </summary>
    [JsonPropertyName(TorrentFields.HASH_STRING)]
    public string HashString { get; set; }

    /// <summary>
    /// Have unchecked
    /// </summary>
    [JsonPropertyName(TorrentFields.HAVE_UNCHECKED)]
    public long HaveUnchecked { get; set; }

    /// <summary>
    /// Have valid
    /// </summary>
    [JsonPropertyName(TorrentFields.HAVE_VALID)]
    public long HaveValid { get; set; }

    /// <summary>
    /// Honors session limits
    /// </summary>
    [JsonPropertyName(TorrentFields.HONORS_SESSION_LIMITS)]
    public bool HonorsSessionLimits { get; set; }

    /// <summary>
    /// Is finished
    /// </summary>
    [JsonPropertyName(TorrentFields.IS_FINISHED)]
    public bool IsFinished { get; set; }

    /// <summary>
    /// Is private
    /// </summary>
    [JsonPropertyName(TorrentFields.IS_PRIVATE)]
    public bool IsPrivate { get; set; }

    /// <summary>
    /// Is stalled
    /// </summary>
    [JsonPropertyName(TorrentFields.IS_STALLED)]
    public bool IsStalled { get; set; }

    /// <summary>
    /// Labels
    /// </summary>
    [JsonPropertyName(TorrentFields.LABELS)]
    public string[] Labels { get; set; }

    /// <summary>
    /// Left until done
    /// </summary>
    [JsonPropertyName(TorrentFields.LEFT_UNTIL_DONE)]
    public long LeftUntilDone { get; set; }

    /// <summary>
    /// Magnet link
    /// </summary>
    [JsonPropertyName(TorrentFields.MAGNET_LINK)]
    public string MagnetLink { get; set; }

    /// <summary>
    /// Max connected peers
    /// </summary>
    [JsonPropertyName(TorrentFields.MAX_CONNECTED_PEERS)]
    public int MaxConnectedPeers { get; set; }

    /// <summary>
    /// Metadata percent complete
    /// </summary>
    [JsonPropertyName(TorrentFields.METADATA_PERCENT_COMPLETE)]
    public double MetadataPercentComplete { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName(TorrentFields.NAME)]
    public string Name { get; set; }

    /// <summary>
    /// Peer limit
    /// </summary>
    [JsonPropertyName(TorrentFields.PEER_LIMIT)]
    public int PeerLimit { get; set; }

    /// <summary>
    /// Peers
    /// </summary>
    [JsonPropertyName(TorrentFields.PEERS)]
    public TransmissionTorrentPeers[] Peers { get; set; }

    /// <summary>
    /// Peers connected
    /// </summary>
    [JsonPropertyName(TorrentFields.PEERS_CONNECTED)]
    public int PeersConnected { get; set; }

    /// <summary>
    /// Peers from
    /// </summary>
    [JsonPropertyName(TorrentFields.PEERS_FROM)]
    public TransmissionTorrentPeersFrom PeersFrom { get; set; }

    /// <summary>
    /// Peers getting from us
    /// </summary>
    [JsonPropertyName(TorrentFields.PEERS_GETTING_FROM_US)]
    public int PeersGettingFromUs { get; set; }

    /// <summary>
    /// Peers sending to us
    /// </summary>
    [JsonPropertyName(TorrentFields.PEERS_SENDING_TO_US)]
    public int PeersSendingToUs { get; set; }

    /// <summary>
    /// Percent complete
    /// </summary>
    [JsonPropertyName(TorrentFields.PERCENT_COMPLETE)]
    public double PercentComplete { get; set; }

    /// <summary>
    /// Percent done
    /// </summary>
    [JsonPropertyName(TorrentFields.PERCENT_DONE)]
    public double PercentDone { get; set; }

    /// <summary>
    /// Pieces
    /// </summary>
    [JsonPropertyName(TorrentFields.PIECES)]
    public string Pieces { get; set; }

    /// <summary>
    /// Piece count
    /// </summary>
    [JsonPropertyName(TorrentFields.PIECE_COUNT)]
    public int PieceCount { get; set; }

    /// <summary>
    /// Piece size
    /// </summary>
    [JsonPropertyName(TorrentFields.PIECE_SIZE)]
    public long PieceSize { get; set; }

    /// <summary>
    /// Priorities
    /// </summary>
    [JsonPropertyName(TorrentFields.PRIORITIES)]
    public int[] Priorities { get; set; }

    /// <summary>
    /// Primary mime type
    /// </summary>
    [JsonPropertyName(TorrentFields.PRIMARY_MIME_TYPE)]
    public string PrimaryMimeType { get; set; }

    /// <summary>
    /// Queue position
    /// </summary>
    [JsonPropertyName(TorrentFields.QUEUE_POSITION)]
    public int QueuePosition { get; set; }

    /// <summary>
    /// Rate download
    /// </summary>
    [JsonPropertyName(TorrentFields.RATE_DOWNLOAD)]
    public int RateDownload { get; set; }

    /// <summary>
    /// Rate upload
    /// </summary>
    [JsonPropertyName(TorrentFields.RATE_UPLOAD)]
    public int RateUpload { get; set; }

    /// <summary>
    /// Recheck progress
    /// </summary>
    [JsonPropertyName(TorrentFields.RECHECK_PROGRESS)]
    public double RecheckProgress { get; set; }

    /// <summary>
    /// Seconds downloading
    /// </summary>
    [JsonPropertyName(TorrentFields.SECONDS_DOWNLOADING)]
    public int SecondsDownloading { get; set; }

    /// <summary>
    /// Seconds seeding
    /// </summary>
    [JsonPropertyName(TorrentFields.SECONDS_SEEDING)]
    public int SecondsSeeding { get; set; }

    /// <summary>
    /// Seed idle limit
    /// </summary>
    [JsonPropertyName(TorrentFields.SEED_IDLE_LIMIT)]
    public int SeedIdleLimit { get; set; }

    /// <summary>
    /// Seed idle mode
    /// </summary>
    [JsonPropertyName(TorrentFields.SEED_IDLE_MODE)]
    public int SeedIdleMode { get; set; }

    /// <summary>
    /// Seed ratio limit
    /// </summary>
    [JsonPropertyName(TorrentFields.SEED_RATIO_LIMIT)]
    public double SeedRatioLimit { get; set; }

    /// <summary>
    /// Seed ratio mode
    /// </summary>
    [JsonPropertyName(TorrentFields.SEED_RATIO_MODE)]
    public int SeedRatioMode { get; set; }
        
    [JsonPropertyName(TorrentFields.SEQUENTIAL_DOWNLOAD)]
    public bool SequentialDownload { get; set; }
        
    [JsonPropertyName(TorrentFields.SEQUENTIAL_DOWNLOAD_FROM_PIECE)]
    public int SequentialDownloadFromPiece { get; set; }

    /// <summary>
    /// Size when done
    /// </summary>
    [JsonPropertyName(TorrentFields.SIZE_WHEN_DONE)]
    public long SizeWhenDone { get; set; }

    /// <summary>
    /// Start date
    /// </summary>
    [JsonPropertyName(TorrentFields.START_DATE)]
    public long StartDate { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    [JsonPropertyName(TorrentFields.STATUS)]
    public int Status { get; set; }

    /// <summary>
    /// Trackers
    /// </summary>
    [JsonPropertyName(TorrentFields.TRACKERS)]
    public TransmissionTorrentTrackers[] Trackers { get; set; }

    /// <summary>
    /// Tracker list:
    /// A string of announce URLs, one per line, with a blank
    /// line between tiers
    /// </summary>
    [JsonPropertyName(TorrentFields.TRACKER_LIST)]
    public string TrackerList { get; set; }

    /// <summary>
    /// Tracker stats
    /// </summary>
    [JsonPropertyName(TorrentFields.TRACKER_STATS)]
    public TransmissionTorrentTrackerStats[] TrackerStats { get; set; }

    /// <summary>
    /// Total size
    /// </summary>
    [JsonPropertyName(TorrentFields.TOTAL_SIZE)]
    public long TotalSize { get; set; }

    /// <summary>
    /// Torrent file
    /// </summary>
    [JsonPropertyName(TorrentFields.TORRENT_FILE)]
    public string TorrentFile { get; set; }

    /// <summary>
    /// Uploaded ever
    /// </summary>
    [JsonPropertyName(TorrentFields.UPLOADED_EVER)]
    public long UploadedEver { get; set; }

    /// <summary>
    /// Upload limit
    /// </summary>
    [JsonPropertyName(TorrentFields.UPLOAD_LIMIT)]
    public int UploadLimit { get; set; }

    /// <summary>
    /// Upload limited
    /// </summary>
    [JsonPropertyName(TorrentFields.UPLOAD_LIMITED)]
    public bool UploadLimited { get; set; }

    /// <summary>
    /// Upload ratio
    /// </summary>
    [JsonPropertyName(TorrentFields.UPLOAD_RATIO)]
    public double UploadRatio { get; set; }

    /// <summary>
    /// Wanted
    /// </summary>
    [JsonPropertyName(TorrentFields.WANTED)]
    public bool[] Wanted { get; set; }

    /// <summary>
    /// Web seeds
    /// </summary>
    [JsonPropertyName(TorrentFields.WEB_SEEDS)]
    public string[] Webseeds { get; set; }

    /// <summary>
    /// Web seeds sending to us
    /// </summary>
    [JsonPropertyName(TorrentFields.WEB_SEEDS_SENDING_TO_US)]
    public int WebseedsSendingToUs { get; set; }
}

/// <summary>
/// Torrent files
/// </summary>
public class TransmissionTorrentFiles
{
    /// <summary>
    /// Bytes completed
    /// </summary>
    [JsonPropertyName(TorrentFields.BYTES_COMPLETED)]
    public long BytesCompleted{ get; set; }

    /// <summary>
    /// Length
    /// </summary>
    [JsonPropertyName(ApiFields.LENGTH)]
    public long Length{ get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonPropertyName(TorrentFields.NAME)]
    public string Name{ get; set; }
        
    [JsonPropertyName("begin_piece")]
    public int BeginPiece{ get; set; }
        
    [JsonPropertyName("end_piece")]
    public int EndPiece{ get; set; }
}

/// <summary>
/// Torrent file stats
/// </summary>
public class TransmissionTorrentFileStats
{
    /// <summary>
    /// Bytes completed
    /// </summary>
    [JsonPropertyName(TorrentFields.BYTES_COMPLETED)]
    public long BytesCompleted{ get; set; }

    /// <summary>
    /// Wanted
    /// </summary>
    [JsonPropertyName(TorrentFields.WANTED)]
    public bool Wanted{ get; set; }

    /// <summary>
    /// Priority
    /// </summary>
    [JsonPropertyName(ApiFields.PRIORITY)]
    public int Priority{ get; set; }
}

/// <summary>
/// Torrent peers
/// </summary>
public class TransmissionTorrentPeers
{
    /// <summary>
    /// Address
    /// </summary>
    [JsonPropertyName("address")]
    public string Address{ get; set; }

    /// <summary>
    /// Client name
    /// </summary>
    [JsonPropertyName("client_name")]
    public string ClientName{ get; set; }

    /// <summary>
    /// Client is choked
    /// </summary>
    [JsonPropertyName("client_is_choked")]
    public bool ClientIsChoked{ get; set; }

    /// <summary>
    /// Client is interested
    /// </summary>
    [JsonPropertyName("client_is_interested")]
    public bool ClientIsInterested{ get; set; }

    /// <summary>
    /// Flag string
    /// </summary>
    [JsonPropertyName("flag_str")]
    public string FlagStr{ get; set; }

    /// <summary>
    /// Is downloading from
    /// </summary>
    [JsonPropertyName("is_downloading_from")]
    public bool IsDownloadingFrom{ get; set; }

    /// <summary>
    /// Is encrypted
    /// </summary>
    [JsonPropertyName("is_encrypted")]
    public bool IsEncrypted{ get; set; }
        
    [JsonPropertyName("is_incoming")]
    public bool IsIncoming{ get; set; }

    /// <summary>
    /// Is uploading to
    /// </summary>
    [JsonPropertyName("is_uploading_to")]
    public bool IsUploadingTo{ get; set; }

    /// <summary>
    /// Is UTP
    /// </summary>
    [JsonPropertyName("is_utp")]
    public bool IsUtp{ get; set; }
        
    [JsonPropertyName("peer_id")]
    public string PeerId{ get; set; }

    /// <summary>
    /// Peer is choked
    /// </summary>
    [JsonPropertyName("peer_is_choked")]
    public bool PeerIsChoked{ get; set; }

    /// <summary>
    /// Peer is interested
    /// </summary>
    [JsonPropertyName("peer_is_interested")]
    public bool PeerIsInterested{ get; set; }

    /// <summary>
    /// Port
    /// </summary>
    [JsonPropertyName("port")]
    public int Port{ get; set; }

    /// <summary>
    /// Progress
    /// </summary>
    [JsonPropertyName("progress")]
    public double Progress{ get; set; }

    /// <summary>
    /// Rate to client
    /// </summary>
    [JsonPropertyName("rate_to_client")]
    public int RateToClient{ get; set; }

    /// <summary>
    /// Rate to peer
    /// </summary>
    [JsonPropertyName("rate_to_peer")]
    public int RateToPeer{ get; set; }
}

/// <summary>
/// Torrent peers from
/// </summary>
public class TransmissionTorrentPeersFrom
{
    [JsonPropertyName("from_cache")]
    public int FromCache{ get; set; }
        
    /// <summary>
    /// From DHT
    /// </summary>
    [JsonPropertyName("from_dht")]
    public int FromDht{ get; set; }

    /// <summary>
    /// From incoming
    /// </summary>
    [JsonPropertyName("from_incoming")]
    public int FromIncoming{ get; set; }

    /// <summary>
    /// From LPD
    /// </summary>
    [JsonPropertyName("from_lpd")]
    public int FromLpd{ get; set; }

    /// <summary>
    /// From Ltep
    /// </summary>
    [JsonPropertyName("from_ltep")]
    public int FromLtep{ get; set; }

    /// <summary>
    /// From PEX
    /// </summary>
    [JsonPropertyName("from_pex")]
    public int FromPex{ get; set; }

    /// <summary>
    /// From tracker
    /// </summary>
    [JsonPropertyName("from_tracker")]
    public int FromTracker{ get; set; }
}

/// <summary>
/// Torrent trackers
/// </summary>
public class TransmissionTorrentTrackers
{
    /// <summary>
    /// Announce
    /// </summary>
    [JsonPropertyName("announce")]
    public string Announce{ get; set; }

    /// <summary>
    /// Id
    /// </summary>
    [JsonPropertyName("id")]
    public int Id{ get; set; }

    /// <summary>
    /// Scrape
    /// </summary>
    [JsonPropertyName("scrape")]
    public string Scrape{ get; set; }
        
    [JsonPropertyName("sitename")]
    public string SiteName{ get; set; }

    /// <summary>
    /// Tier
    /// </summary>
    [JsonPropertyName("tier")]
    public int Tier{ get; set; }
}

/// <summary>
/// Torrent tracker stats
/// </summary>
public class TransmissionTorrentTrackerStats
{
    /// <summary>
    /// Announce
    /// </summary>
    [JsonPropertyName("announce")]
    public string Announce{ get; set; }

    /// <summary>
    /// Announce state
    /// </summary>
    [JsonPropertyName("announce_state")]
    public int AnnounceState{ get; set; }

    /// <summary>
    /// Download count
    /// </summary>
    [JsonPropertyName("download_count")]
    public int DownloadCount{ get; set; }
        
    [JsonPropertyName("downloader_count")]
    public int DownloaderCount{ get; set; }

    /// <summary>
    /// Has announced
    /// </summary>
    [JsonPropertyName("has_announced")]
    public bool HasAnnounced{ get; set; }

    /// <summary>
    /// Has scraped
    /// </summary>
    [JsonPropertyName("has_scraped")]
    public bool HasScraped{ get; set; }

    /// <summary>
    /// Host
    /// </summary>
    [JsonPropertyName("host")]
    public string Host{ get; set; }
        
    /// <summary>
    /// Id
    /// </summary>
    [JsonPropertyName("id")]
    public int Id{ get; set; }

    /// <summary>
    /// Is backup
    /// </summary>
    [JsonPropertyName("is_backup")]
    public bool IsBackup{ get; set; }

    /// <summary>
    /// Last announce peer count
    /// </summary>
    [JsonPropertyName("lasta_announce_peer_count")]
    public int LastAnnouncePeerCount{ get; set; }

    /// <summary>
    /// Last announce result 
    /// </summary>
    [JsonPropertyName("last_announce_result")]
    public string LastAnnounceResult{ get; set; }

    /// <summary>
    /// Last announce succeeded
    /// </summary>
    [JsonPropertyName("last_announce_succeeded")]
    public bool LastAnnounceSucceeded{ get; set; }

    /// <summary>
    /// Last announce start time
    /// </summary>
    [JsonPropertyName("last_announce_start_time")]
    public int LastAnnounceStartTime{ get; set; }

    /// <summary>
    /// Last announce timed out
    /// </summary>
    [JsonPropertyName("last_announce_timed_out")]
    public bool LastAnnounceTimedOut{ get; set; }

    /// <summary>
    /// Last announce time
    /// </summary>
    [JsonPropertyName("lastAnnounceTime")]
    public int LastAnnounceTime{ get; set; }
        
    /// <summary>
    /// Last scrape result
    /// </summary>
    [JsonPropertyName("last_scrape_result")]
    public string LastScrapeResult{ get; set; }

    /// <summary>
    /// Last scrape scceeded
    /// </summary>
    [JsonPropertyName("last_scrape_succeeded")]
    public bool LastScrapeSucceeded{ get; set; }

    /// <summary>
    /// Last scrape start time
    /// </summary>
    [JsonPropertyName("last_scrape_start_time")]
    public int LastScrapeStartTime{ get; set; }

    /// <summary>
    /// Last scrape timed out
    /// </summary>
    [JsonPropertyName("last_scrape_timed_out")]
    public bool LastScrapeTimedOut{ get; set; }

    /// <summary>
    /// Last scrape time
    /// </summary>
    [JsonPropertyName("last_scrape_time")]
    public int LastScrapeTime{ get; set; }

    /// <summary>
    /// Scrape
    /// </summary>
    [JsonPropertyName("scrape")]
    public string Scrape{ get; set; }

    /// <summary>
    /// Tier
    /// </summary>
    [JsonPropertyName("tier")]
    public int Tier{ get; set; }

    /// <summary>
    /// Leecher count
    /// </summary>
    [JsonPropertyName("leecher_count")]
    public int LeecherCount{ get; set; }

    /// <summary>
    /// Next announce time
    /// </summary>
    [JsonPropertyName("next_announce_time")]
    public int NextAnnounceTime{ get; set; }

    /// <summary>
    /// Next scrape time
    /// </summary>
    [JsonPropertyName("next_scrape_time")]
    public int NextScrapeTime{ get; set; }

    /// <summary>
    /// Scrape state
    /// </summary>
    [JsonPropertyName("scrape_state")]
    public int ScrapeState{ get; set; }

    /// <summary>
    /// Seeder count
    /// </summary>
    [JsonPropertyName("seeder_count")]
    public int SeederCount{ get; set; }
        
    [JsonPropertyName("sitename")]
    public string SiteName{ get; set; }
}

/// <summary>
/// Contains arrays of torrents and removed torrents
/// </summary>
public class TransmissionTorrents
{
    /// <summary>
    /// Array of torrents
    /// </summary>
    [JsonPropertyName("torrents")]
    public TorrentInfo[] Torrents{ get; set; }

    /// <summary>
    /// Array of torrent-id numbers of recently-removed torrents
    /// </summary>
    [JsonPropertyName("removed")]
    public TorrentInfo[] Removed{ get; set; }
}