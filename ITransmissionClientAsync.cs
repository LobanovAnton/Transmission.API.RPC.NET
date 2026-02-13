using System.Threading;
using System.Threading.Tasks;
using Transmission.API.RPC.Entity;
using Transmission.API.RPC.Params;

namespace Transmission.API.RPC
{
    /// <summary>
    /// Interface for async transmission client
    /// </summary>
    public interface ITransmissionClientAsync
    {

        /// <summary>
        /// Update blocklist (API: blocklist-update)
        /// </summary>
        /// <returns>Blocklist size</returns>
        Task<int> BlocklistUpdateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Close current session (API: session-close)
        /// </summary>
        Task CloseSessionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get free space is available in a client-specified folder.
        /// </summary>
        /// <param name="path">The directory to query</param>
        Task<FreeSpace> FreeSpaceAsync(string path, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get information of current session (API: session-get)
        /// </summary>
        /// <returns>Session information</returns>
        Task<SessionInfo> GetSessionInformationAsync(string[] fields = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get session stat
        /// </summary>
        /// <returns>Session stat</returns>
        Task<Statistic> GetSessionStatisticAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// See if your incoming peer port is accessible from the outside world (API: port-test)
        /// </summary>
        /// <returns>Accessible state</returns>
        Task<PortTest> PortTestAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Set information to current session (API: session-set)
        /// </summary>
        /// <param name="settings">New session settings</param>
        Task SetSessionSettingsAsync(SessionSettings settings, CancellationToken cancellationToken = default);

        /// <summary>
        /// Add torrent (API: torrent-add)
        /// </summary>
        /// <returns>Torrent info (ID, Name and HashString)</returns>
        Task<AddTorrentInfo> TorrentAddAsync(NewTorrent torrent, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get fields of torrents from ids (API: torrent-get)
        /// </summary>
        /// <param name="fields">Fields of torrents</param>
        /// <param name="ids">IDs of torrents (null or empty for get all torrents)</param>
        /// <returns>Torrents info</returns>
        Task<TransmissionTorrents> TorrentGetAsync(string[] fields, object[] ids, CancellationToken cancellationToken = default);

        /// <summary>
        /// Move torrents to bottom in queue  (API: queue-move-bottom)
        /// </summary>
        /// <param name="ids"></param>
        Task TorrentQueueMoveBottomAsync(object[] ids, CancellationToken cancellationToken = default);

        /// <summary>
        /// Move down torrents in queue (API: queue-move-down)
        /// </summary>
        /// <param name="ids"></param>
        Task TorrentQueueMoveDownAsync(object[] ids, CancellationToken cancellationToken = default);

        /// <summary>
        /// Move torrents in queue on top (API: queue-move-top)
        /// </summary>
        /// <param name="ids">Torrents id</param>
        Task TorrentQueueMoveTopAsync(object[] ids, CancellationToken cancellationToken = default);

        /// <summary>
        /// Move up torrents in queue (API: queue-move-up)
        /// </summary>
        /// <param name="ids"></param>
        Task TorrentQueueMoveUpAsync(object[] ids, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove torrents
        /// </summary>
        /// <param name="ids">Torrents id</param>
        /// <param name="deleteData">Remove local data</param>
        Task TorrentRemoveAsync(object[] ids, bool deleteData = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Rename a file or directory in a torrent (API: torrent-rename-path)
        /// </summary>
        /// <param name="id">The torrent whose path will be renamed</param>
        /// <param name="path">The path to the file or folder that will be renamed</param>
        /// <param name="name">The file or folder's new name</param>
        Task<RenameTorrentInfo> TorrentRenamePathAsync(int id, string path, string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Set torrent params (API: torrent-set)
        /// </summary>
        /// <param name="settings">Torrent settings</param>
        Task TorrentSetAsync(TorrentSettings settings, CancellationToken cancellationToken = default);

        /// <summary>
        /// Set new location for torrents files (API: torrent-set-location)
        /// </summary>
        /// <param name="ids">Torrent ids</param>
        /// <param name="location">The new torrent location</param>
        /// <param name="move">Move from previous location</param>
        Task TorrentSetLocationAsync(object[] ids, string location, bool move, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start recently active torrents (API: torrent-start)
        /// </summary>
        Task TorrentStartAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Start torrents (API: torrent-start)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        Task TorrentStartAsync(object[] ids, CancellationToken cancellationToken = default);

        /// <summary>
        /// Start now recently active torrents (API: torrent-start-now)
        /// </summary>
        Task TorrentStartNowAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Start now torrents (API: torrent-start-now)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        Task TorrentStartNowAsync(object[] ids, CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop recently active torrents (API: torrent-stop)
        /// </summary>
        Task TorrentStopAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Stop torrents (API: torrent-stop)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        Task TorrentStopAsync(object[] ids, CancellationToken cancellationToken = default);

        Task TorrentReannounceAsync(CancellationToken cancellationToken = default);

        Task TorrentReannounceAsync(object[] ids, CancellationToken cancellationToken = default);

        /// <summary>
        /// Verify recently active torrents (API: torrent-verify)
        /// </summary>
        Task TorrentVerifyAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Verify torrents (API: torrent-verify)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        Task TorrentVerifyAsync(object[] ids, CancellationToken cancellationToken = default);

        Task GroupSet(Group group, CancellationToken cancellationToken = default);

        Task<GroupsInfo> GroupGet(string groupName = null, CancellationToken cancellationToken = default);
    }
}
