Transmission-API-RPC
========================

#### Modern Transmission RPC packet for .net10
#### Support Transmission server >= 4.1.0 (rpc_version_semver 6.0.0) and JSON-RPC 2.0
#### If your server version is less than 4.1.0 please use original old packet
[Transmission.API.RPC](https://www.nuget.org/packages/Transmission.API.RPC)

Documentation
-------------
[Official Transmission RPC specs](https://github.com/transmission/transmission/blob/4.1.0/docs/rpc-spec.md) 

C# implementation of the Transmission RPC API.

| Command              | Not Implemented | Implemented|
|----------------------|:-:|:-:|
| torrent_start        |   | x |
| torrent_start_now    |   | x |
| torrent_stop         |   | x |
| torrent_verify       |   | x |
| torrent_reannounce   |   | x |
| torrent_set          |   | x |
| torrent_get          |   | x |
| torrent_add          |   | x |
| torrent_remove       |   | x |
| torrent_set_location |   | x |
| torrent_rename_path  |   | x |
| group_set            |   | x |
| group_get            |   | x |
| session_set          |   | x |
| session_get          |   | x |
| session_stats        |   | x |
| blocklist_update     |   | x |
| port_test            |   | x |
| session_close        |   | x |
| queue_move_top       |   | x |
| queue_move_up        |   | x |
| queue_move_down      |   | x |
| queue_move_bottom    |   | x |
| free_space           |   | x |

How to use
----------

Install Nuget Package: `PM> Install-Package Transmission.API.RPC.NET`

Example from TransmissionNet project:

```C#
using Transmission.API.RPC;
using Transmission.API.RPC.Params;
using Transmission.API.RPC.Entity;

namespace TransmissionNet.TorrentProviders;

public class TransmissionTorrentProvider(string url, string username, string password) : ITorrentProvider
{
    private const string Provider = "Transmission";

    private static readonly string[] TorrentModelFields =
    [
        TorrentFields.ID,
        TorrentFields.NAME,
        TorrentFields.TOTAL_SIZE,
        TorrentFields.STATUS,
        TorrentFields.PERCENT_DONE,
        TorrentFields.RECHECK_PROGRESS,
        TorrentFields.RATE_DOWNLOAD,
        TorrentFields.RATE_UPLOAD,
        TorrentFields.UPLOAD_RATIO,
        TorrentFields.LEFT_UNTIL_DONE,
        TorrentFields.SECONDS_DOWNLOADING,
        TorrentFields.ADDED_DATE,
        TorrentFields.QUEUE_POSITION,
        TorrentFields.DOWNLOAD_DIR
    ];

    private static readonly string[] SessionModelFields =
    [
        SessionFields.SESSION_ID,
        SessionFields.VERSION,
        SessionFields.CACHE_SIZE_MB,
        SessionFields.DOWNLOAD_DIR,
        SessionFields.INCOMPLETE_DIR,
        SessionFields.INCOMPLETE_DIR_ENABLED,
        SessionFields.PEX_ENABLED,
        SessionFields.LPD_ENABLED,
        SessionFields.DHT_ENABLED,
        SessionFields.UTP_ENABLED,
        SessionFields.ENCRYPTION,
        SessionFields.UNITS,
        SessionFields.DOWNLOAD_QUEUE_ENABLED,
        SessionFields.DOWNLOAD_QUEUE_SIZE,
        SessionFields.SEED_QUEUE_ENABLED,
        SessionFields.SEED_QUEUE_SIZE,
        SessionFields.PORT_FORWARDING_ENABLED,
        SessionFields.PEER_PORT
    ];

    private static string? _sessionId;

    private readonly Client _client = new(url, _sessionId, username, password);

    public async Task<long> GetFreeSpaceAsync(string path)
    {
        FreeSpace freeSpace = await _client.FreeSpaceAsync(path);
        return freeSpace.SizeBytes;
    }

    public async Task<SessionModel> GetSessionModelAsync()
    {
        SessionInfo sessionInfo = await _client.GetSessionInformationAsync(SessionModelFields);
  
        _sessionId = sessionInfo.SessionId;
        
        SessionModel model = new SessionModel
        {
            Version = $"{Provider} {sessionInfo.Version}",
            CacheSize = sessionInfo.CacheSizeMb,
            CompletePath = sessionInfo.DownloadDirectory,
            InCompletePathEnabled = sessionInfo.IncompleteDirectoryEnabled,
            InCompletePath = sessionInfo.IncompleteDirectory,
            UsePex = sessionInfo.PexEnabled,
            UseLpd = sessionInfo.LpdEnabled,
            UseDht = sessionInfo.DhtEnabled,
            UseUdp = sessionInfo.UtpEnabled,
            EncryptionMode = Enum.Parse<Encryption>(sessionInfo.Encryption, true),
            SpeedUnits = sessionInfo.Units.SpeedBytes,
            SizeUnits = sessionInfo.Units.SizeBytes,
            MemoryUnits = sessionInfo.Units.MemoryBytes,
            DownloadQueueEnabled = sessionInfo.DownloadQueueEnabled,
            DownloadQueueSize = sessionInfo.DownloadQueueSize,
            SeedQueueEnabled = sessionInfo.SeedQueueEnabled,
            SeedQueueSize = sessionInfo.SeedQueueSize,
            PortForwardingEnabled = sessionInfo.PortForwardingEnabled,
            PeerPort = sessionInfo.PeerPort
        };
        
        return model;
    }
    
    public async Task SetSessionModelAsync(SessionModel sessionModel)
    {
        SessionSettings settings = new()
        {
            CacheSizeMb = sessionModel.CacheSize,
            DownloadDirectory = sessionModel.CompletePath,
            IncompleteDirectoryEnabled = sessionModel.InCompletePathEnabled,
            IncompleteDirectory = sessionModel.InCompletePath,
            PexEnabled = sessionModel.UsePex,
            LpdEnabled = sessionModel.UseLpd,
            DhtEnabled = sessionModel.UseDht,
            UtpEnabled = sessionModel.UseUdp,
            Encryption = sessionModel.EncryptionMode.ToString().ToLower(),
            DownloadQueueEnabled = sessionModel.DownloadQueueEnabled,
            DownloadQueueSize = sessionModel.DownloadQueueSize,
            SeedQueueEnabled = sessionModel.SeedQueueEnabled,
            SeedQueueSize = sessionModel.SeedQueueSize,
            PortForwardingEnabled = sessionModel.PortForwardingEnabled,
            PeerPort = sessionModel.PeerPort
        };

        await _client.SetSessionSettingsAsync(settings);
    }

    public async Task<StatisticModel> GetStatisticModelAsync()
    {
        Statistic statistic = await _client.GetSessionStatisticAsync();

        CommonStatisticModel currentStat = new();
        CommonStatisticModel cumulativeStat = new();
        
        currentStat.DownloadedBytes = statistic.CurrentStats.DownloadedBytes;
        currentStat.UploadedBytes = statistic.CurrentStats.UploadedBytes;
        currentStat.SecondsActive = statistic.CurrentStats.SecondsActive;
        currentStat.FilesAdded = statistic.CurrentStats.FilesAdded;
        currentStat.SessionCount = statistic.CurrentStats.SessionCount;
        
        cumulativeStat.DownloadedBytes = statistic.CumulativeStats.DownloadedBytes;
        cumulativeStat.UploadedBytes = statistic.CumulativeStats.UploadedBytes;
        cumulativeStat.SecondsActive = statistic.CumulativeStats.SecondsActive;
        cumulativeStat.FilesAdded = statistic.CumulativeStats.FilesAdded;
        cumulativeStat.SessionCount = statistic.CumulativeStats.SessionCount;
        
        return new StatisticModel
        {
            DownloadSpeed = statistic.DownloadSpeed,
            UploadSpeed = statistic.UploadSpeed,
            ActiveTorrentCount = statistic.ActiveTorrentCount,
            PausedTorrentCount = statistic.PausedTorrentCount,
            TorrentCount = statistic.TorrentCount,
            CurrentStats = currentStat,
            CumulativeStats = cumulativeStat
        };
    }

    public async Task<TorrentModel[]> GetTorrentModelAsync()
    {
        TransmissionTorrents torrents = await _client.TorrentGetAsync(TorrentModelFields, null);
        TorrentInfo[] torrentInfos = torrents.Torrents;
        
        TorrentModel[] models = new TorrentModel[torrentInfos.Length];

        for (int i = 0; i < models.Length; i++)
        {
            models[i] = new TorrentModel
            {
                Id = torrentInfos[i].Id,
                QueuePosition = torrentInfos[i].QueuePosition,
                Name = torrentInfos[i].Name,
                TotalSize = torrentInfos[i].TotalSize,
                Progress = torrentInfos[i].PercentDone,
                VerifyingProgress = torrentInfos[i].RecheckProgress,
                DownloadRate = torrentInfos[i].RateDownload,
                UploadRate = torrentInfos[i].RateUpload,
                UploadRatio = torrentInfos[i].UploadRatio,
                LeftUntilDone = torrentInfos[i].LeftUntilDone,
                SecondsDownloading = torrentInfos[i].SecondsDownloading,
                Status = (TorrentModel.State)torrentInfos[i].Status,
                DownloadDir = torrentInfos[i].DownloadDir,
                DateAdded = torrentInfos[i].AddedDate
            };
        }
        
        return models;
    }

    public async Task AddTorrentAsync(string metaInfo)
    {
        NewTorrent torrent = new NewTorrent
        {
            Metainfo = metaInfo
        };
        await _client.TorrentAddAsync(torrent);
    }

    public async Task StartNowTorrentAsync(TorrentModel model)
    {
        await _client.TorrentStartNowAsync([model.Id]);
    }

    public async Task StartTorrentAsync(TorrentModel model)
    {
        await _client.TorrentStartAsync([model.Id]);
    }

    public async Task StopTorrentAsync(TorrentModel model)
    {
        await _client.TorrentStopAsync([model.Id]);
    }

    public async Task DeleteTorrentAsync(TorrentModel model, bool deleteFiles)
    {
        await _client.TorrentRemoveAsync([model.Id], deleteFiles);
    }

    public async Task VerifyTorrentAsync(TorrentModel model)
    {
        await _client.TorrentVerifyAsync([model.Id]);
    }

    public async Task DeleteAllAsync(IList<TorrentModel> models)
    {
        await _client.TorrentRemoveAsync(models.Select<TorrentModel, object>(x => x.Id).ToArray());
    }

    public async Task StartAllAsync(IList<TorrentModel> models)
    {
        await _client.TorrentStartAsync(models.Select<TorrentModel, object>(x => x.Id).ToArray());
    }

    public async Task StopAllAsync(IList<TorrentModel> models)
    {
        await _client.TorrentStopAsync(models.Select<TorrentModel, object>(x => x.Id).ToArray());
    }
}
```
