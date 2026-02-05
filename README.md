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

```C#
using Transmission.API.RPC.Entity;

// URL might look like "schema://host:port/transmission/rpc" for example "https://website.com:9091/transmission/rpc"
var client = new Client("URL", "PARAM_SESSION_ID", "PARAM_LOGIN", "PARAM_PASS");

var sessionInfo = client.GetSessionInformation(); // All fields or use SessionFields class
var allTorrents = client.TorrentGet(TorrentFields.ALL_FIELDS);
//<...>
```
