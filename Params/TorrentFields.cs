namespace Transmission.API.RPC.Params;

/// <summary>
/// Torrent fields
/// </summary>
public static class TorrentFields
{
    /// <summary>
    /// activityDate
    /// </summary>
    public const string ACTIVITY_DATE = "activity_date";

    /// <summary>
    /// addedDate
    /// </summary>
    public const string ADDED_DATE = "added_date";
        
    public const string AVAILABILITY = "availability";

    /// <summary>
    /// bandwidthPriority
    /// </summary>
    public const string BANDWIDTH_PRIORITY = "bandwidth_priority";
        
    public const string BYTES_COMPLETED = "bytes_completed";
        
    /// <summary>
    /// comment
    /// </summary>
    public const string COMMENT = "comment";

    /// <summary>
    /// corruptEver
    /// </summary>
    public const string CORRUPT_EVER = "corrupt_ever";

    /// <summary>
    /// creator
    /// </summary>
    public const string CREATOR = "creator";

    /// <summary>
    /// dateCreated
    /// </summary>
    public const string DATE_CREATED = "date_created";

    /// <summary>
    /// desiredAvailable
    /// </summary>
    public const string DESIRED_AVAILABLE = "desired_available";

    /// <summary>
    /// doneDate
    /// </summary>
    public const string DONE_DATE = "done_date";

    /// <summary>
    /// downloadDir
    /// </summary>
    public const string DOWNLOAD_DIR = "download_dir";

    /// <summary>
    /// downloadedEver
    /// </summary>
    public const string DOWNLOADED_EVER = "downloaded_ever";

    /// <summary>
    /// downloadLimit
    /// </summary>
    public const string DOWNLOAD_LIMIT = "download_limit";

    /// <summary>
    /// downloadLimited
    /// </summary>
    public const string DOWNLOAD_LIMITED = "download_limited";

    /// <summary>
    /// editDate
    /// </summary>
    public const string EDIT_DATE = "edit_date";

    /// <summary>
    /// error
    /// </summary>
    public const string ERROR = "error";

    /// <summary>
    /// errorString
    /// </summary>
    public const string ERROR_STRING = "error_string";

    /// <summary>
    /// eta
    /// </summary>
    public const string ETA = "eta";

    /// <summary>
    /// etaIdle
    /// </summary>
    public const string ETA_IDLE = "eta_idle";

    /// <summary>
    /// file-count
    /// </summary>
    public const string FILE_COUNT = "file_count";

    /// <summary>
    /// files
    /// </summary>
    public const string FILES = "files";

    /// <summary>
    /// fileStats
    /// </summary>
    public const string FILE_STATS = "file_stats";
        
    public const string GROUP  = "group";

    /// <summary>
    /// hashString
    /// </summary>
    public const string HASH_STRING = "hash_string";

    /// <summary>
    /// haveUnchecked
    /// </summary>
    public const string HAVE_UNCHECKED = "have_unchecked";

    /// <summary>
    /// haveValid
    /// </summary>
    public const string HAVE_VALID = "have_valid";

    /// <summary>
    /// honorsSessionLimits
    /// </summary>
    public const string HONORS_SESSION_LIMITS = "honors_session_limits";

    /// <summary>
    /// id
    /// </summary>
    public const string ID = "id";

    /// <summary>
    /// isFinished
    /// </summary>
    public const string IS_FINISHED = "is_finished";

    /// <summary>
    /// isPrivate
    /// </summary>
    public const string IS_PRIVATE = "is_private";

    /// <summary>
    /// isStalled
    /// </summary>
    public const string IS_STALLED = "is_stalled";

    /// <summary>
    /// labels
    /// </summary>
    public const string LABELS = "labels";

    /// <summary>
    /// leftUntilDone
    /// </summary>
    public const string LEFT_UNTIL_DONE = "left_until_done";

    /// <summary>
    /// magnetLink
    /// </summary>
    public const string MAGNET_LINK = "magnet_link";

    /// <summary>
    /// maxConnectedPeers
    /// </summary>
    public const string MAX_CONNECTED_PEERS = "max_connected_peers";
        
    /// <summary>
    /// metadataPercentComplete
    /// </summary>
    public const string METADATA_PERCENT_COMPLETE = "metadata_percent_complete";

    /// <summary>
    /// name
    /// </summary>
    public const string NAME = "name";
        
    /// <summary>
    /// peer-limit
    /// </summary>
    public const string PEER_LIMIT = "peer_limit";

    /// <summary>
    /// peers
    /// </summary>
    public const string PEERS = "peers";

    /// <summary>
    /// peersConnected
    /// </summary>
    public const string PEERS_CONNECTED = "peers_connected";

    /// <summary>
    /// peersFrom
    /// </summary>
    public const string PEERS_FROM = "peers_from";

    /// <summary>
    /// peersGettingFromUs
    /// </summary>
    public const string PEERS_GETTING_FROM_US = "peers_getting_from_us";

    /// <summary>
    /// peersSendingToUs
    /// </summary>
    public const string PEERS_SENDING_TO_US = "peers_sending_to_us";

    /// <summary>
    /// percentComplete
    /// </summary>
    public const string PERCENT_COMPLETE = "percent_complete";

    /// <summary>
    /// percentDone
    /// </summary>
    public const string PERCENT_DONE = "percent_done";

    /// <summary>
    /// pieces
    /// </summary>
    public const string PIECES = "pieces";

    /// <summary>
    /// pieceCount
    /// </summary>
    public const string PIECE_COUNT = "piece_count";

    /// <summary>
    /// pieceSize
    /// </summary>
    public const string PIECE_SIZE = "piece_size";

    /// <summary>
    /// priorities
    /// </summary>
    public const string PRIORITIES = "priorities";

    /// <summary>
    /// primary-mime-type
    /// </summary>
    public const string PRIMARY_MIME_TYPE = "primary_mime_type";

    /// <summary>
    /// queuePosition
    /// </summary>
    public const string QUEUE_POSITION = "queue_position";

    /// <summary>
    /// rateDownload
    /// </summary>
    public const string RATE_DOWNLOAD = "rate_download";

    /// <summary>
    /// rateUpload
    /// </summary>
    public const string RATE_UPLOAD = "rate_upload";

    /// <summary>
    /// recheckProgress
    /// </summary>
    public const string RECHECK_PROGRESS = "recheck_progress";

    /// <summary>
    /// secondsDownloading
    /// </summary>
    public const string SECONDS_DOWNLOADING = "seconds_downloading";

    /// <summary>
    /// secondsSeeding
    /// </summary>
    public const string SECONDS_SEEDING = "seconds_seeding";

    /// <summary>
    /// seedIdleLimit
    /// </summary>
    public const string SEED_IDLE_LIMIT = "seed_idle_limit";

    /// <summary>
    /// seedIdleMode
    /// </summary>
    public const string SEED_IDLE_MODE = "seed_idle_mode";

    /// <summary>
    /// seedRatioLimit
    /// </summary>
    public const string SEED_RATIO_LIMIT = "seed_ratio_limit";

    /// <summary>
    /// seedRatioMode
    /// </summary>
    public const string SEED_RATIO_MODE = "seed_ratio_mode";
        
    public const string SEQUENTIAL_DOWNLOAD = "sequential_download";
        
    public const string SEQUENTIAL_DOWNLOAD_FROM_PIECE = "sequential_download_from_piece";

    /// <summary>
    /// sizeWhenDone
    /// </summary>
    public const string SIZE_WHEN_DONE = "size_when_done";

    /// <summary>
    /// startDate
    /// </summary>
    public const string START_DATE = "start_date";

    /// <summary>
    /// status
    /// </summary>
    public const string STATUS = "status";

    /// <summary>
    /// trackers
    /// </summary>
    public const string TRACKERS = "trackers";

    /// <summary>
    /// trackerList
    /// </summary>
    public const string TRACKER_LIST = "tracker_list";

    /// <summary>
    /// trackerStats
    /// </summary>
    public const string TRACKER_STATS = "tracker_stats";

    /// <summary>
    /// totalSize
    /// </summary>
    public const string TOTAL_SIZE = "total_size";

    /// <summary>
    /// torrentFile
    /// </summary>
    public const string TORRENT_FILE = "torrent_file";

    /// <summary>
    /// uploadedEver
    /// </summary>
    public const string UPLOADED_EVER = "uploaded_ever";

    /// <summary>
    /// uploadLimit
    /// </summary>
    public const string UPLOAD_LIMIT = "upload_limit";

    /// <summary>
    /// uploadLimited
    /// </summary>
    public const string UPLOAD_LIMITED = "upload_limited";

    /// <summary>
    /// uploadRatio
    /// </summary>
    public const string UPLOAD_RATIO = "upload_ratio";

    /// <summary>
    /// wanted
    /// </summary>
    public const string WANTED = "wanted";

    /// <summary>
    /// webseeds
    /// </summary>
    public const string WEB_SEEDS = "webseeds";

    /// <summary>
    /// webseedsSendingToUs
    /// </summary>
    public const string WEB_SEEDS_SENDING_TO_US = "webseeds_sending_to_us";

    /// <summary>
    /// All fields
    /// </summary>
    public static string[] AllFields
    {
        get
        {
            return new[] 
            {
                #region ALL FIELDS
                ACTIVITY_DATE,
                ADDED_DATE,
                AVAILABILITY,
                BANDWIDTH_PRIORITY,
                BYTES_COMPLETED,
                COMMENT,
                CORRUPT_EVER,
                CREATOR,
                DATE_CREATED,
                DESIRED_AVAILABLE,
                DONE_DATE,
                DOWNLOAD_DIR,
                DOWNLOADED_EVER,
                DOWNLOAD_LIMIT,
                DOWNLOAD_LIMITED,
                EDIT_DATE,
                ERROR,
                ERROR_STRING,
                ETA,
                ETA_IDLE,
                FILE_COUNT,
                FILES,
                FILE_STATS,
                GROUP,
                HASH_STRING,
                HAVE_UNCHECKED,
                HAVE_VALID,
                HONORS_SESSION_LIMITS,
                ID,
                IS_FINISHED,
                IS_PRIVATE,
                IS_STALLED,
                LABELS,
                LEFT_UNTIL_DONE,
                MAGNET_LINK,
                MAX_CONNECTED_PEERS,
                METADATA_PERCENT_COMPLETE,
                NAME,
                PEER_LIMIT,
                PEERS,
                PEERS_CONNECTED,
                PEERS_FROM,
                PEERS_GETTING_FROM_US,
                PEERS_SENDING_TO_US,
                PERCENT_COMPLETE,
                PERCENT_DONE,
                PIECES,
                PIECE_COUNT,
                PIECE_SIZE,
                PRIORITIES,
                PRIMARY_MIME_TYPE,
                QUEUE_POSITION,
                RATE_DOWNLOAD,
                RATE_UPLOAD,
                RECHECK_PROGRESS,
                SECONDS_DOWNLOADING,
                SECONDS_SEEDING,
                SEED_IDLE_LIMIT,
                SEED_IDLE_MODE,
                SEED_RATIO_LIMIT,
                SEED_RATIO_MODE,
                SIZE_WHEN_DONE,
                SEQUENTIAL_DOWNLOAD,
                SEQUENTIAL_DOWNLOAD_FROM_PIECE,
                START_DATE,
                STATUS,
                TRACKERS,
                TRACKER_LIST,
                TRACKER_STATS,
                TOTAL_SIZE,
                TORRENT_FILE,
                UPLOADED_EVER,
                UPLOAD_LIMIT,
                UPLOAD_LIMITED,
                UPLOAD_RATIO,
                WANTED,
                WEB_SEEDS,
                WEB_SEEDS_SENDING_TO_US
                #endregion
            };
        }
    }
}