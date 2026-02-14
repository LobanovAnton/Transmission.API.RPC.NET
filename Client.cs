using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Transmission.API.RPC.Entity;
using Transmission.API.RPC.Params;

namespace Transmission.API.RPC
{
    /// <summary>
    /// Transmission client
    /// </summary>
#pragma warning disable CS0618 // Type or member is obsolete
    public partial class Client : ITransmissionClient, ITransmissionClientAsync
#pragma warning restore CS0618 // Type or member is obsolete
    {
        private static readonly IHttpClientFactory HttpClientFactory = CreateHttpClientFactory();
        private static readonly MediaTypeHeaderValue JsonMediaType = new(MediaTypeNames.Application.Json);

        private readonly string _authorization;
        private readonly bool _needAuthorization;

        private static IHttpClientFactory CreateHttpClientFactory()
        {
            return new ServiceCollection()
                .AddHttpClient()
                .BuildServiceProvider()
                .GetRequiredService<IHttpClientFactory>();
        }

        /// <summary>
        /// Url to service
        /// </summary>
        public string Url
        {
            get;
            private set;
        }

        /// <summary>
        /// Session ID
        /// </summary>
        public string SessionId
        {
            get;
            private set;
        }

        /// <summary>
        /// Current Tag
        /// </summary>
        public int CurrentTag
        {
            get;
            private set;
        }

        /// <summary>
        /// Initialize client
        /// <example>For example
        /// <code>
        /// new Transmission.API.RPC.Client("https://website.com:9091/transmission/rpc")
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="url">URL to Transmission RPC API. Often it looks like schema://host:port/transmission/rpc </param>
        /// <param name="sessionId">Session ID</param>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        public Client(string url, string sessionId = null, string login = null, string password = null)
        {
            Url = url;
            SessionId = sessionId;

            if (!String.IsNullOrWhiteSpace(login))
            {
                var authBytes = Encoding.UTF8.GetBytes(login + ":" + password);
                var encoded = Convert.ToBase64String(authBytes);

                _authorization = "Basic " + encoded;
                _needAuthorization = true;
            }
        }

        #region Session methods

        /// <summary>
        /// Close current session (API: session-close)
        /// </summary>
        [Obsolete("Use CloseSessionAsync instead")]
        public void CloseSession()
        {
            Task.Run(() => CloseSessionAsync()).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Set information to current session (API: session-set)
        /// </summary>
        /// <param name="settings">New session settings</param>
        [Obsolete("Use SetSessionSettingsAsync instead")]
        public void SetSessionSettings(SessionSettings settings)
        {
            Task.Run(() => SetSessionSettingsAsync(settings)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get session stat
        /// </summary>
        /// <returns>Session stat</returns>
        [Obsolete("Use GetSessionStatisticAsync instead")]
        public Statistic GetSessionStatistic()
        {
            return Task.Run(() => GetSessionStatisticAsync()).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get information of current session (API: session-get)
        /// </summary>
        /// <returns>Session information</returns>
        [Obsolete("Use GetSessionInformationAsync instead")]
        public SessionInfo GetSessionInformation(string[] fields)
        {
            return Task.Run(() => GetSessionInformationAsync(fields)).GetAwaiter().GetResult();
        }

        #endregion

        #region Torrents methods

        /// <summary>
        /// Add torrent (API: torrent-add)
        /// </summary>
        /// <returns>Torrent info (ID, Name and HashString)</returns>
        [Obsolete("Use TorrentAddAsync instead")]
		public AddTorrentInfo TorrentAdd(NewTorrent torrent)
        {
            return Task.Run(() => TorrentAddAsync(torrent)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Set torrent params (API: torrent-set)
        /// </summary>
        /// <param name="settings">Torrent settings</param>
        [Obsolete("Use TorrentSetAsync instead")]
        public void TorrentSet(TorrentSettings settings)
        {
            Task.Run(() => TorrentSetAsync(settings)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get fields of torrents from ids (API: torrent-get)
        /// </summary>
        /// <param name="fields">Fields of torrents</param>
        /// <param name="ids">IDs of torrents (null or empty for get all torrents)</param>
        /// <returns>Torrents info</returns>
        [Obsolete("Use TorrentGetAsync instead")]
        public TransmissionTorrents TorrentGet(string[] fields, object[] ids)
        {
            return Task.Run(() => TorrentGetAsync(fields, ids)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Remove torrents (API: torrent-remove)
        /// </summary>
        /// <param name="ids">Torrents id</param>
        /// <param name="deleteData">Remove data</param>
        [Obsolete("Use TorrentRemoveAsync instead")]
        public void TorrentRemove(object[] ids, bool deleteData = false)
        {
            Task.Run(() => TorrentRemoveAsync(ids, deleteData)).GetAwaiter().GetResult();
        }

        #region Torrent Start
        /// <summary>
        /// Start torrents (API: torrent-start)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        [Obsolete("Use TorrentStartAsync instead")]
        public void TorrentStart(object[] ids)
        {
            Task.Run(() => TorrentStartAsync(ids)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Start recently active torrents (API: torrent-start)
        /// </summary>
        [Obsolete("Use TorrentStartAsync instead")]
        public void TorrentStart()
        {
            Task.Run(() => TorrentStartAsync()).GetAwaiter().GetResult();
        }
        #endregion

        #region Torrent Start Now

        /// <summary>
        /// Start now torrents (API: torrent-start-now)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        [Obsolete("Use TorrentStartNowAsync instead")]
        public void TorrentStartNow(object[] ids)
        {
            Task.Run(() => TorrentStartNowAsync(ids)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Start now recently active torrents (API: torrent-start-now)
        /// </summary>
        [Obsolete("Use TorrentStartNowAsync instead")]
        public void TorrentStartNow()
        {
            Task.Run(() => TorrentStartNowAsync()).GetAwaiter().GetResult();
        }
        #endregion

        #region Torrent Stop
        /// <summary>
        /// Stop torrents (API: torrent-stop)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        [Obsolete("Use TorrentStopAsync instead")]
        public void TorrentStop(object[] ids)
        {
            Task.Run(() => TorrentStopAsync(ids)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Stop recently active torrents (API: torrent-stop)
        /// </summary>
        [Obsolete("Use TorrentStopAsync instead")]
        public void TorrentStop()
        {
            Task.Run(() => TorrentStopAsync()).GetAwaiter().GetResult();
        }
        #endregion

        #region Torrent Reannounce

        [Obsolete("Use TorrentReannounceAsync instead")]
        void ITransmissionClient.TorrentReannounce()
        {
            Task.Run(() => TorrentReannounceAsync()).GetAwaiter().GetResult();
        }

        [Obsolete("Use TorrentReannounceAsync instead")]
        void ITransmissionClient.TorrentReannounce(object[] ids)
        {
            Task.Run(() => TorrentReannounceAsync(ids)).GetAwaiter().GetResult();
        }

        #endregion

        #region Torrent Verify
        /// <summary>
        /// Verify torrents (API: torrent-verify)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        [Obsolete("Use TorrentVerifyAsync instead")]
        public void TorrentVerify(object[] ids)
        {
            Task.Run(() => TorrentVerifyAsync(ids)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Verify recently active torrents (API: torrent-verify)
        /// </summary>
        [Obsolete("Use TorrentVerifyAsync instead")]
        public void TorrentVerify()
        {
            Task.Run(() => TorrentVerifyAsync()).GetAwaiter().GetResult();
        }
        #endregion

        [Obsolete("Use GroupSetAsync instead")]
        void ITransmissionClient.GroupSet(Group group)
        {
            Task.Run(() => GroupSet(group)).GetAwaiter().GetResult();
        }

        [Obsolete("Use GroupGetAsync instead")]
        GroupsInfo ITransmissionClient.GroupGet(string groupName)
        {
            return Task.Run(() => GroupGet(groupName)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Move torrents in queue on top (API: queue-move-top)
        /// </summary>
        /// <param name="ids">Torrents id</param>
        [Obsolete("Use TorrentQueueMoveTopAsync instead")]
        public void TorrentQueueMoveTop(object[] ids)
        {
            Task.Run(() => TorrentQueueMoveTopAsync(ids)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Move up torrents in queue (API: queue-move-up)
        /// </summary>
        /// <param name="ids"></param>
        [Obsolete("Use TorrentQueueMoveUpAsync instead")]
        public void TorrentQueueMoveUp(object[] ids)
        {
            Task.Run(() => TorrentQueueMoveUpAsync(ids)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Move down torrents in queue (API: queue-move-down)
        /// </summary>
        /// <param name="ids"></param>
        [Obsolete("Use TorrentQueueMoveDownAsync instead")]
        public void TorrentQueueMoveDown(object[] ids)
        {
            Task.Run(() => TorrentQueueMoveDownAsync(ids)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Move torrents to bottom in queue  (API: queue-move-bottom)
        /// </summary>
        /// <param name="ids"></param>
        [Obsolete("Use TorrentQueueMoveBottomAsync instead")]
        public void TorrentQueueMoveBottom(object[] ids)
        {
            Task.Run(() => TorrentQueueMoveBottomAsync(ids)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Set new location for torrents files (API: torrent-set-location)
        /// </summary>
        /// <param name="ids">Torrent ids</param>
        /// <param name="location">The new torrent location</param>
        /// <param name="move">Move from previous location</param>
        [Obsolete("Use TorrentSetLocationAsync instead")]
        public void TorrentSetLocation(object[] ids, string location, bool move)
        {
            Task.Run(() => TorrentSetLocationAsync(ids, location, move)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Rename a file or directory in a torrent (API: torrent-rename-path)
        /// </summary>
        /// <param name="id">The torrent whose path will be renamed</param>
        /// <param name="path">The path to the file or folder that will be renamed</param>
        /// <param name="name">The file or folder's new name</param>
        [Obsolete("Use TorrentRenamePathAsync instead")]
		public RenameTorrentInfo TorrentRenamePath(int id, string path, string name)
        {
            return Task.Run(() => TorrentRenamePathAsync(id, path, name)).GetAwaiter().GetResult();
        }

        #endregion

        #region System
        /// <summary>
        /// See if your incoming peer port is accessible from the outside world (API: port-test)
        /// </summary>
        /// <returns>Accessible state</returns>
        [Obsolete("Use PortTestAsync instead")]
        public PortTest PortTest()
        {
            return Task.Run(() => PortTestAsync()).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Update blocklist (API: blocklist-update)
        /// </summary>
        /// <returns>Blocklist size</returns>
        [Obsolete("Use BlocklistUpdateAsync instead")]
        public int BlocklistUpdate()
        {
            return Task.Run(() => BlocklistUpdateAsync()).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get free space is available in a client-specified folder.
        /// </summary>
        /// <param name="path">The directory to query</param>
        [Obsolete("Use FreeSpaceAsync instead")]
        public FreeSpace FreeSpace(string path)
        {
            return Task.Run(() => FreeSpaceAsync(path)).GetAwaiter().GetResult();
        }
        #endregion
    }
}
