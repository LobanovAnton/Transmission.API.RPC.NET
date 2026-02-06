using Transmission.API.RPC.Common;

namespace Transmission.API.RPC.Params;

/// <summary>
/// Torrent settings
/// </summary>
public class TorrentSettings : Parameters
{
	/// <summary>
	/// This torrent's bandwidth tr_priority_t
	/// </summary>
	public int? BandwidthPriority
	{
		get => GetValue<int?>(TorrentFields.BANDWIDTH_PRIORITY);
		set => this[TorrentFields.BANDWIDTH_PRIORITY] = value;
	}

	/// <summary>
	/// Maximum download speed (KBps)
	/// </summary>
	public int? DownloadLimit
	{
		get => GetValue<int?>(TorrentFields.DOWNLOAD_LIMIT);
		set => this[TorrentFields.DOWNLOAD_LIMIT] = value;
	}

	/// <summary>
	/// Download limit is honored
	/// </summary>
	public bool? DownloadLimited
	{
		get => GetValue<bool?>(TorrentFields.DOWNLOAD_LIMITED);
		set => this[TorrentFields.DOWNLOAD_LIMITED] = value;
	}

	/// <summary>
	/// Session upload limits are honored
	/// </summary>
	public bool? HonorsSessionLimits
	{
		get => GetValue<bool?>(TorrentFields.HONORS_SESSION_LIMITS);
		set => this[TorrentFields.HONORS_SESSION_LIMITS] = value;
	}

	/// <summary>
	/// Torrent id array
	/// </summary>
	public object[] Ids
	{
		get => GetValue<object[]>(ApiFields.IDS);
		set => this[ApiFields.IDS] = value;
	}
	    
	/// <summary>
	/// New labels of the torrent's
	/// </summary>
	public string[] Labels
	{
		get => GetValue<string[]>(TorrentFields.LABELS);
		set => this[TorrentFields.LABELS] = value;
	}

	/// <summary>
	/// New location of the torrent's content
	/// </summary>
	public string Location
	{
		get => GetValue<string>(ApiFields.LOCATION);
		set => this[ApiFields.LOCATION] = value;
	}

	/// <summary>
	/// Maximum number of peers
	/// </summary>
	public int? PeerLimit
	{
		get => GetValue<int?>(TorrentFields.PEER_LIMIT);
		set => this[TorrentFields.PEER_LIMIT] = value;
	}

	/// <summary>
	/// Position of this torrent in its queue [0...n)
	/// </summary>
	public int? QueuePosition
	{
		get => GetValue<int?>(TorrentFields.QUEUE_POSITION);
		set => this[TorrentFields.QUEUE_POSITION] = value;
	}

	/// <summary>
	/// Torrent-level number of minutes of seeding inactivity
	/// </summary>
	public int? SeedIdleLimit
	{
		get => GetValue<int?>(TorrentFields.SEED_IDLE_LIMIT);
		set => this[TorrentFields.SEED_IDLE_LIMIT] = value;
	}

	/// <summary>
	/// Which seeding inactivity to use
	/// </summary>
	public int? SeedIdleMode
	{
		get => GetValue<int?>(TorrentFields.SEED_IDLE_MODE);
		set => this[TorrentFields.SEED_IDLE_MODE] = value;
	}

	/// <summary>
	/// Torrent-level seeding ratio
	/// </summary>
	public double? SeedRatioLimit
	{
		get => GetValue<double?>(TorrentFields.SEED_RATIO_LIMIT);
		set => this[TorrentFields.SEED_RATIO_LIMIT] = value;
	}

	/// <summary>
	/// Which ratio to use. 
	/// </summary>
	public int? SeedRatioMode
	{
		get => GetValue<int?>(TorrentFields.SEED_RATIO_MODE);
		set => this[TorrentFields.SEED_RATIO_MODE] = value;
	}
	    
	public bool? SequentialDownload
	{
		get => GetValue<bool?>(TorrentFields.SEQUENTIAL_DOWNLOAD);
		set => this[TorrentFields.SEQUENTIAL_DOWNLOAD] = value;
	}
	    
	public int? SequentialDownloadFromPiece
	{
		get => GetValue<int?>(TorrentFields.SEQUENTIAL_DOWNLOAD_FROM_PIECE);
		set => this[TorrentFields.SEQUENTIAL_DOWNLOAD_FROM_PIECE] = value;
	}

	/// <summary>
	/// Maximum upload speed (KBps)
	/// </summary>
	public int? UploadLimit
	{
		get => GetValue<int?>(TorrentFields.UPLOAD_LIMIT);
		set => this[TorrentFields.UPLOAD_LIMIT] = value;
	}

	/// <summary>
	/// Upload limit is honored
	/// </summary>
	public bool? UploadLimited
	{
		get => GetValue<bool?>(TorrentFields.UPLOAD_LIMITED);
		set => this[TorrentFields.UPLOAD_LIMITED] = value;
	}
        
	/// <summary>
	/// String of announce URLs, one per line, with a blank line between tiers
	/// </summary>
	public string[] TrackerList 
	{ 
		get => GetValue<string[]>(TorrentFields.TRACKER_LIST);
		set => this[TorrentFields.TRACKER_LIST] = value;
	}

	/// <summary>
	/// Files wanted
	/// </summary>
	public int[] FilesWanted 
	{ 
		get => GetValue<int[]>(ApiFields.FILES_WANTED);
		set => this[ApiFields.FILES_WANTED] = value;
	}

	/// <summary>
	/// Files unwanted
	/// </summary>
	public int[] FilesUnwanted
	{
		get => GetValue<int[]>(ApiFields.FILES_UNWANTED);
		set => this[ApiFields.FILES_UNWANTED] = value;
	}
		
	public string Group
	{
		get => GetValue<string>(TorrentFields.GROUP);
		set => this[TorrentFields.GROUP] = value;
	}

	/// <summary>
	/// High priority files
	/// </summary>
	public int[] PriorityHigh
	{
		get => GetValue<int[]>(ApiFields.PRIORITY_HIGH);
		set => this[ApiFields.PRIORITY_HIGH] = value;
	}

	/// <summary>
	/// Low priority files
	/// </summary>
	public int[] PriorityLow
	{
		get => GetValue<int[]>(ApiFields.PRIORITY_LOW);
		set => this[ApiFields.PRIORITY_LOW] = value;
	}

	/// <summary>
	/// Normal priority files
	/// </summary>
	public int[] PriorityNormal
	{
		get => GetValue<int[]>(ApiFields.PRIORITY_NORMAL);
		set => this[ApiFields.PRIORITY_NORMAL] = value;
	}
}