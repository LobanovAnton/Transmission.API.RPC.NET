using System.Text.Json.Serialization;

namespace Transmission.API.RPC.Entity;

/// <summary>
/// Statistic
/// </summary>
public class Statistic
{
    /// <summary>
    /// Active torrent count
    /// </summary>
    [JsonPropertyName("active_torrent_count")]
    public int ActiveTorrentCount { get; set; }

    /// <summary>
    /// Download speed
    /// </summary>
    [JsonPropertyName("download_speed")]
    public int DownloadSpeed{ get; set; }

    /// <summary>
    /// Paused torrent count
    /// </summary>
    [JsonPropertyName("paused_torrent_count")]
    public int PausedTorrentCount{ get; set; }

    /// <summary>
    /// Torrent count
    /// </summary>
    [JsonPropertyName("torrent_count")]
    public int TorrentCount{ get; set; }

    /// <summary>
    /// Upload speed
    /// </summary>
    [JsonPropertyName("upload_speed")]
    public int UploadSpeed{ get; set; }
   
    /// <summary>
    /// Cumulative stats
    /// </summary>
    [JsonPropertyName("cumulative_stats")]
    public CommonStatistic CumulativeStats { get; set; }
 
    /// <summary>
    /// Current stats
    /// </summary>
    [JsonPropertyName("current_stats")]
    public CommonStatistic CurrentStats { get; set; }
}

/// <summary>
/// Common statistic
/// </summary>
public class CommonStatistic
{
    /// <summary>
    /// Uploaded bytes
    /// </summary>
    [JsonPropertyName("uploaded_bytes")]
    public double UploadedBytes{ get; set; }
        
    /// <summary>
    /// Downloaded bytes
    /// </summary>
    [JsonPropertyName("downloaded_bytes")]
    public double DownloadedBytes{ get; set; }

    /// <summary>
    /// Files added
    /// </summary>
    [JsonPropertyName("files_added")]
    public int FilesAdded{ get; set; }

    /// <summary>
    /// Session count
    /// </summary>
    [JsonPropertyName("session_count")]
    public int SessionCount{ get; set; }

    /// <summary>
    /// Seconds active
    /// </summary>
    [JsonPropertyName("seconds_active")]
    public int SecondsActive{ get; set; }
}