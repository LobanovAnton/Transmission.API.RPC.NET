using System.Text.Json.Serialization;
using Transmission.API.RPC.Common;
using Transmission.API.RPC.Entity;

namespace Transmission.API.RPC.Utils;

[JsonSourceGenerationOptions(WriteIndented = false)]
[JsonSerializable(typeof(TransmissionTorrents))]
[JsonSerializable(typeof(AddTorrentInfo))]
[JsonSerializable(typeof(RenameTorrentInfo))]
[JsonSerializable(typeof(SessionInfo))]
[JsonSerializable(typeof(Statistic))]
[JsonSerializable(typeof(GroupsInfo))]
[JsonSerializable(typeof(FreeSpace))]
[JsonSerializable(typeof(PortTest))]
[JsonSerializable(typeof(BlockList))]
[JsonSerializable(typeof(TransmissionRequest))]
[JsonSerializable(typeof(TransmissionResponse))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}