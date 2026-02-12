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

    private static readonly Dictionary<TorrentField, string> FieldMap = new()
    {
        { TorrentField.Id, TorrentFields.ID },
        { TorrentField.Name, TorrentFields.NAME },
        { TorrentField.Availability , TorrentFields.AVAILABILITY },
        { TorrentField.TotalSize, TorrentFields.TOTAL_SIZE },
        { TorrentField.Status, TorrentFields.STATUS },
        { TorrentField.PercentDone, TorrentFields.PERCENT_DONE },
        { TorrentField.RecheckProgress, TorrentFields.RECHECK_PROGRESS },
        { TorrentField.RateDownload, TorrentFields.RATE_DOWNLOAD },
        { TorrentField.RateUpload, TorrentFields.RATE_UPLOAD },
        { TorrentField.UploadRatio, TorrentFields.UPLOAD_RATIO },
        { TorrentField.LeftUntilDone, TorrentFields.LEFT_UNTIL_DONE },
        { TorrentField.SecondsDownloading, TorrentFields.SECONDS_DOWNLOADING },
        { TorrentField.AddedDate, TorrentFields.ADDED_DATE },
        { TorrentField.QueuePosition, TorrentFields.QUEUE_POSITION },
        { TorrentField.DownloadDir, TorrentFields.DOWNLOAD_DIR },
        { TorrentField.Files, TorrentFields.FILES },
        { TorrentField.FileStats, TorrentFields.FILE_STATS },
        { TorrentField.Pieces, TorrentFields.PIECES },
        { TorrentField.PieceCount, TorrentFields.PIECE_COUNT },
        { TorrentField.SequentialDownload, TorrentFields.SEQUENTIAL_DOWNLOAD },
    };

    private static readonly Dictionary<SessionField, string> SessionFieldMap = new()
    {
        { SessionField.SessionId, SessionFields.SESSION_ID },
        { SessionField.Version, SessionFields.VERSION },
        { SessionField.CacheSize, SessionFields.CACHE_SIZE_MB },
        { SessionField.DownloadDir, SessionFields.DOWNLOAD_DIR },
        { SessionField.IncompleteDir, SessionFields.INCOMPLETE_DIR },
        { SessionField.IncompleteDirEnabled, SessionFields.INCOMPLETE_DIR_ENABLED },
        { SessionField.PexEnabled, SessionFields.PEX_ENABLED },
        { SessionField.LpdEnabled, SessionFields.LPD_ENABLED },
        { SessionField.DhtEnabled, SessionFields.DHT_ENABLED },
        { SessionField.UtpEnabled, SessionFields.UTP_ENABLED },
        { SessionField.Encryption, SessionFields.ENCRYPTION },
        { SessionField.Units, SessionFields.UNITS },
        { SessionField.DownloadQueueEnabled, SessionFields.DOWNLOAD_QUEUE_ENABLED },
        { SessionField.DownloadQueueSize, SessionFields.DOWNLOAD_QUEUE_SIZE },
        { SessionField.SeedQueueEnabled, SessionFields.SEED_QUEUE_ENABLED },
        { SessionField.SeedQueueSize, SessionFields.SEED_QUEUE_SIZE },
        { SessionField.PortForwardingEnabled, SessionFields.PORT_FORWARDING_ENABLED },
        { SessionField.PeerPort, SessionFields.PEER_PORT },
        { SessionField.SequentialDownload, SessionFields.SEQUENTIAL_DOWNLOAD },
    };

    private static string? _sessionId;

    private readonly Client _client = new(url, _sessionId, username, password);

    public async Task<long> GetFreeSpaceAsync(string path)
    {
        FreeSpace freeSpace = await _client.FreeSpaceAsync(path);
        return freeSpace.SizeBytes;
    }

    public Task SetTorrentLocationAsync(int id, string destinationPath)
    {
        return _client.TorrentSetLocationAsync([id], destinationPath, true);
    }

    public async Task<SessionModel> GetSessionModelAsync(SessionField[] fields)
    {
        HashSet<SessionField> fieldSet = new(fields) { SessionField.SessionId };
        string[] rpcFields = fieldSet.Select(f => SessionFieldMap[f]).ToArray();

        SessionInfo sessionInfo = await _client.GetSessionInformationAsync(rpcFields);
  
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
            EncryptionMode = sessionInfo.Encryption != null ? 
                Enum.Parse<Encryption>(sessionInfo.Encryption, true)
                : Encryption.Preferred,
            SpeedUnits = sessionInfo.Units?.SpeedBytes ?? 0,
            SizeUnits = sessionInfo.Units?.SizeBytes ?? 0,
            MemoryUnits = sessionInfo.Units?.MemoryBytes ?? 0,
            DownloadQueueEnabled = sessionInfo.DownloadQueueEnabled,
            DownloadQueueSize = sessionInfo.DownloadQueueSize,
            SeedQueueEnabled = sessionInfo.SeedQueueEnabled,
            SeedQueueSize = sessionInfo.SeedQueueSize,
            PortForwardingEnabled = sessionInfo.PortForwardingEnabled,
            PeerPort = sessionInfo.PeerPort
        };
        
        return model;
    }
    
    public Task SetSessionSettingsAsync(SessionSettingsModel model)
    {
        SessionSettings settings = new();

        if (model.CacheSize.HasValue)
            settings.CacheSizeMb = model.CacheSize.Value;
        if (model.CompletePath != null)
            settings.DownloadDirectory = model.CompletePath;
        if (model.InCompletePathEnabled.HasValue)
            settings.IncompleteDirectoryEnabled = model.InCompletePathEnabled.Value;
        if (model.InCompletePath != null)
            settings.IncompleteDirectory = model.InCompletePath;
        if (model.UsePex.HasValue)
            settings.PexEnabled = model.UsePex.Value;
        if (model.UseLpd.HasValue)
            settings.LpdEnabled = model.UseLpd.Value;
        if (model.UseDht.HasValue)
            settings.DhtEnabled = model.UseDht.Value;
        if (model.UseUdp.HasValue)
            settings.UtpEnabled = model.UseUdp.Value;
        if (model.EncryptionMode.HasValue)
            settings.Encryption = model.EncryptionMode.Value.ToString().ToLower();
        if (model.DownloadQueueEnabled.HasValue)
            settings.DownloadQueueEnabled = model.DownloadQueueEnabled.Value;
        if (model.DownloadQueueSize.HasValue)
            settings.DownloadQueueSize = model.DownloadQueueSize.Value;
        if (model.SeedQueueEnabled.HasValue)
            settings.SeedQueueEnabled = model.SeedQueueEnabled.Value;
        if (model.SeedQueueSize.HasValue)
            settings.SeedQueueSize = model.SeedQueueSize.Value;
        if (model.PortForwardingEnabled.HasValue)
            settings.PortForwardingEnabled = model.PortForwardingEnabled.Value;
        if (model.PeerPort.HasValue)
            settings.PeerPort = model.PeerPort.Value;

        return _client.SetSessionSettingsAsync(settings);
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

    public async Task<TorrentModel[]> GetTorrentModelAsync(TorrentField[] fields, int[]? ids = null)
    {
        HashSet<TorrentField> fieldSet = new(fields) { TorrentField.Id };
        string[] rpcFields = fieldSet.Select(f => FieldMap[f]).ToArray();
        object[]? rpcIds = ids?.Select<int, object>(id => id).ToArray();

        TransmissionTorrents torrents = await _client.TorrentGetAsync(rpcFields, rpcIds);
        TorrentInfo[] torrentInfos = torrents.Torrents;

        TorrentModel[] models = new TorrentModel[torrentInfos.Length];

        for (int i = 0; i < models.Length; i++)
        {
            TorrentInfo info = torrentInfos[i];

            models[i] = new TorrentModel
            {
                Id = info.Id,
                QueuePosition = info.QueuePosition,
                Name = info.Name,
                TotalSize = info.TotalSize,
                Progress = info.PercentDone,
                VerifyingProgress = info.RecheckProgress,
                DownloadRate = info.RateDownload,
                UploadRate = info.RateUpload,
                UploadRatio = info.UploadRatio,
                LeftUntilDone = info.LeftUntilDone,
                SecondsDownloading = info.SecondsDownloading,
                Status = (TorrentModel.State)info.Status,
                DownloadDir = info.DownloadDir,
                DateAdded = info.AddedDate,
                SequentialDownload =  info.SequentialDownload
            };

            if (fieldSet.Contains(TorrentField.Files) && info.Files != null)
            {
                TransmissionTorrentFiles[] files = info.Files;
                TransmissionTorrentFileStats[] fileStats = info.FileStats;
                TorrentFileModel[] fileModels = new TorrentFileModel[files.Length];

                for (int j = 0; j < fileModels.Length; j++)
                {
                    fileModels[j] = new TorrentFileModel
                    {
                        Name = files[j].Name,
                        Length = files[j].Length,
                        BytesCompleted = files[j].BytesCompleted,
                        Wanted = fileStats != null && j < fileStats.Length && fileStats[j].Wanted,
                        Priority = fileStats != null && j < fileStats.Length ? (FilePriority)fileStats[j].Priority : FilePriority.Normal,
                        BeginPiece = files[j].BeginPiece,
                        PieceCount = files[j].EndPiece - files[j].BeginPiece
                    };
                }

                models[i].Files = fileModels;
            }

            if (fieldSet.Contains(TorrentField.Availability) && info.Availability != null)
                models[i].Availability = info.Availability;

            if (fieldSet.Contains(TorrentField.Pieces) && !string.IsNullOrEmpty(info.Pieces))
                models[i].Pieces = Convert.FromBase64String(info.Pieces);
        }

        return models;
    }

    public Task SetTorrentSettingsAsync(TorrentSettingsModel model)
    {
        TorrentSettings settings = new()
        {
            Ids = [model.Id]
        };

        if (model.SequentialDownload.HasValue)
            settings.SequentialDownload = model.SequentialDownload.Value;

        if (model.FileSettings != null)
        {
            int[] wanted = model.FileSettings.Where(f => f.Wanted).Select(f => f.Id).ToArray();
            int[] unwanted = model.FileSettings.Where(f => !f.Wanted).Select(f => f.Id).ToArray();

            if (wanted.Length > 0)
                settings.FilesWanted = wanted;

            if (unwanted.Length > 0)
                settings.FilesUnwanted = unwanted;
            
            int[] priorityHigh = model.FileSettings.Where(f => f.Priority == FilePriority.High).Select(f => f.Id).ToArray();
            int[] priorityNormal = model.FileSettings.Where(f => f.Priority == FilePriority.Normal).Select(f => f.Id).ToArray();
            int[] priorityLow = model.FileSettings.Where(f => f.Priority == FilePriority.Low).Select(f => f.Id).ToArray();
            
            if (priorityHigh.Length > 0)
                settings.PriorityHigh = priorityHigh;

            if (priorityNormal.Length > 0)
                settings.PriorityNormal = priorityNormal;

            if (priorityLow.Length > 0)
                settings.PriorityLow = priorityLow;
        }

        return _client.TorrentSetAsync(settings);
    }

    public Task AddTorrentAsync(string metaInfo)
    {
        NewTorrent torrent = new NewTorrent
        {
            Metainfo = metaInfo
        };
        return _client.TorrentAddAsync(torrent);
    }

    public Task StartNowTorrentAsync(int id)
    {
        return _client.TorrentStartNowAsync([id]);
    }

    public Task StartTorrentAsync(int id)
    {
        return _client.TorrentStartAsync([id]);
    }

    public Task StopTorrentAsync(int id)
    {
        return _client.TorrentStopAsync([id]);
    }

    public Task DeleteTorrentAsync(int id, bool deleteFiles)
    {
        return _client.TorrentRemoveAsync([id], deleteFiles);
    }

    public Task VerifyTorrentAsync(int id)
    {
        return _client.TorrentVerifyAsync([id]);
    }

    public Task DeleteAllAsync(int[] ids)
    {
        return _client.TorrentRemoveAsync(ids.Select<int, object>(x => x).ToArray());
    }

    public Task StartAllAsync(int[] ids)
    {
        return _client.TorrentStartAsync(ids.Select<int, object>(x => x).ToArray());
    }

    public Task StopAllAsync(int[] ids)
    {
        return _client.TorrentStopAsync(ids.Select<int, object>(x => x).ToArray());
    }
}
```
