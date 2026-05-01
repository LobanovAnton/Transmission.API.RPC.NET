# Transmission.API.RPC.NET

.NET библиотека для работы с Transmission daemon через JSON-RPC API. NuGet-пакет.

## Build & Pack

```bash
# Build
dotnet build Transmission.API.RPC.csproj

# Create NuGet package
dotnet pack Transmission.API.RPC.csproj -c Release
```

## Overview

- **Target**: .NET 10, библиотека (OutputType: Library)
- **Version**: 4.1.7
- **NuGet ID**: Transmission.API.RPC.NET
- **License**: MIT
- **Зависимость**: Microsoft.Extensions.Http 10.0.3
- **Поддержка сервера**: Transmission 4.1.0+, JSON-RPC 2.0

## Архитектура

### Client

- `Client` (partial class) — основной клиент
  - `Client.cs` — конструктор, sync-методы (deprecated)
  - `Client.Async.cs` — все async-методы + `SendRequestAsync`
- `ITransmissionClientAsync` — основной интерфейс (async)
- `ITransmissionClient` — deprecated sync-интерфейс

### Структура

```
├── Common/              # RPC infrastructure
│   ├── Methods.cs       # RPC method names (constants)
│   ├── Parameters.cs    # Dictionary-based parameters
│   ├── TransmissionRequest.cs
│   └── TransmissionResponse.cs
├── Entity/              # Response models (deserialized from JSON)
│   ├── SessionInfo.cs
│   ├── TorrentInfo.cs
│   ├── Statistic.cs
│   ├── AddTorrentInfo.cs
│   └── ...
├── Params/              # Request models & field constants
│   ├── ApiFields.cs     # Common API field name constants
│   ├── TorrentFields.cs # Torrent field name constants
│   ├── SessionFields.cs # Session field name constants
│   ├── TorrentSettings.cs  # torrent-set params
│   ├── SessionSettings.cs  # session-set params
│   └── ...
└── Utils/
    ├── ResponseExtension.cs     # Deserialize helper
    └── SourceGenerationContext.cs  # System.Text.Json source gen
```

## API Methods

### Session
- `GetSessionInformationAsync(fields)` — session-get
- `SetSessionSettingsAsync(settings)` — session-set
- `GetSessionStatisticAsync()` — session-stats
- `CloseSessionAsync()` — session-close

### Torrents
- `TorrentGetAsync(fields, ids)` — torrent-get (null/empty ids = all)
- `TorrentSetAsync(settings)` — torrent-set
- `TorrentAddAsync(torrent)` — torrent-add
- `TorrentRemoveAsync(ids, deleteData)` — torrent-remove
- `TorrentStartAsync / TorrentStartNowAsync / TorrentStopAsync` — start/stop
- `TorrentVerifyAsync / TorrentReannounceAsync` — verify/reannounce
- `TorrentSetLocationAsync(ids, location, move)` — torrent-set-location
- `TorrentRenamePathAsync(id, path, name)` — torrent-rename-path
- `TorrentQueueMove*Async` — queue management

### System
- `PortTestAsync()` — port-test
- `FreeSpaceAsync(path)` — free-space
- `BlocklistUpdateAsync()` — blocklist-update

### Groups
- `GroupSet(group)` — group-set
- `GroupGet(groupName)` — group-get

## Conventions

- Все async-методы принимают `CancellationToken cancellationToken = default`
- Sync-методы помечены `[Obsolete]` — использовать async
- Сериализация: `System.Text.Json` с source generation (`SourceGenerationContext`)
- HTTP: `IHttpClientFactory` вместо `new HttpClient()`
- Session ID: автоматический retry при 409 Conflict (expired session)
- Auth: Basic Authorization через header
- Field selection: передаётся `string[]` полей (используй константы из `TorrentFields` / `SessionFields`)
