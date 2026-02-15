using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
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
        private int _currentTag;
        public int CurrentTag => _currentTag;

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
            CloseSessionAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Set information to current session (API: session-set)
        /// </summary>
        /// <param name="settings">New session settings</param>
        [Obsolete("Use SetSessionSettingsAsync instead")]
        public void SetSessionSettings(SessionSettings settings)
        {
            SetSessionSettingsAsync(settings).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get session stat
        /// </summary>
        /// <returns>Session stat</returns>
        [Obsolete("Use GetSessionStatisticAsync instead")]
        public Statistic GetSessionStatistic()
        {
            return GetSessionStatisticAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get information of current session (API: session-get)
        /// </summary>
        /// <returns>Session information</returns>
        [Obsolete("Use GetSessionInformationAsync instead")]
        public SessionInfo GetSessionInformation(string[] fields)
        {
            return GetSessionInformationAsync(fields).GetAwaiter().GetResult();
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
            return TorrentAddAsync(torrent).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Set torrent params (API: torrent-set)
        /// </summary>
        /// <param name="settings">Torrent settings</param>
        [Obsolete("Use TorrentSetAsync instead")]
        public void TorrentSet(TorrentSettings settings)
        {
            TorrentSetAsync(settings).GetAwaiter().GetResult();
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
            return TorrentGetAsync(fields, ids).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Remove torrents (API: torrent-remove)
        /// </summary>
        /// <param name="ids">Torrents id</param>
        /// <param name="deleteData">Remove data</param>
        [Obsolete("Use TorrentRemoveAsync instead")]
        public void TorrentRemove(object[] ids, bool deleteData = false)
        {
            TorrentRemoveAsync(ids, deleteData).GetAwaiter().GetResult();
        }

        #region Torrent Start
        /// <summary>
        /// Start torrents (API: torrent-start)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        [Obsolete("Use TorrentStartAsync instead")]
        public void TorrentStart(object[] ids)
        {
            TorrentStartAsync(ids).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Start recently active torrents (API: torrent-start)
        /// </summary>
        [Obsolete("Use TorrentStartAsync instead")]
        public void TorrentStart()
        {
            TorrentStartAsync().GetAwaiter().GetResult();
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
            TorrentStartNowAsync(ids).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Start now recently active torrents (API: torrent-start-now)
        /// </summary>
        [Obsolete("Use TorrentStartNowAsync instead")]
        public void TorrentStartNow()
        {
            TorrentStartNowAsync().GetAwaiter().GetResult();
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
            TorrentStopAsync(ids).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Stop recently active torrents (API: torrent-stop)
        /// </summary>
        [Obsolete("Use TorrentStopAsync instead")]
        public void TorrentStop()
        {
            TorrentStopAsync().GetAwaiter().GetResult();
        }
        #endregion

        #region Torrent Reannounce

        [Obsolete("Use TorrentReannounceAsync instead")]
        void ITransmissionClient.TorrentReannounce()
        {
            TorrentReannounceAsync().GetAwaiter().GetResult();
        }

        [Obsolete("Use TorrentReannounceAsync instead")]
        void ITransmissionClient.TorrentReannounce(object[] ids)
        {
            TorrentReannounceAsync(ids).GetAwaiter().GetResult();
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
            TorrentVerifyAsync(ids).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Verify recently active torrents (API: torrent-verify)
        /// </summary>
        [Obsolete("Use TorrentVerifyAsync instead")]
        public void TorrentVerify()
        {
            TorrentVerifyAsync().GetAwaiter().GetResult();
        }
        #endregion

        [Obsolete("Use GroupSetAsync instead")]
        void ITransmissionClient.GroupSet(Group group)
        {
            GroupSet(group).GetAwaiter().GetResult();
        }

        [Obsolete("Use GroupGetAsync instead")]
        GroupsInfo ITransmissionClient.GroupGet(string groupName)
        {
            return GroupGet(groupName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Move torrents in queue on top (API: queue-move-top)
        /// </summary>
        /// <param name="ids">Torrents id</param>
        [Obsolete("Use TorrentQueueMoveTopAsync instead")]
        public void TorrentQueueMoveTop(object[] ids)
        {
            TorrentQueueMoveTopAsync(ids).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Move up torrents in queue (API: queue-move-up)
        /// </summary>
        /// <param name="ids"></param>
        [Obsolete("Use TorrentQueueMoveUpAsync instead")]
        public void TorrentQueueMoveUp(object[] ids)
        {
            TorrentQueueMoveUpAsync(ids).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Move down torrents in queue (API: queue-move-down)
        /// </summary>
        /// <param name="ids"></param>
        [Obsolete("Use TorrentQueueMoveDownAsync instead")]
        public void TorrentQueueMoveDown(object[] ids)
        {
            TorrentQueueMoveDownAsync(ids).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Move torrents to bottom in queue  (API: queue-move-bottom)
        /// </summary>
        /// <param name="ids"></param>
        [Obsolete("Use TorrentQueueMoveBottomAsync instead")]
        public void TorrentQueueMoveBottom(object[] ids)
        {
            TorrentQueueMoveBottomAsync(ids).GetAwaiter().GetResult();
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
            TorrentSetLocationAsync(ids, location, move).GetAwaiter().GetResult();
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
            return TorrentRenamePathAsync(id, path, name).GetAwaiter().GetResult();
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
            return PortTestAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Update blocklist (API: blocklist-update)
        /// </summary>
        /// <returns>Blocklist size</returns>
        [Obsolete("Use BlocklistUpdateAsync instead")]
        public int BlocklistUpdate()
        {
            return BlocklistUpdateAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get free space is available in a client-specified folder.
        /// </summary>
        /// <param name="path">The directory to query</param>
        [Obsolete("Use FreeSpaceAsync instead")]
        public FreeSpace FreeSpace(string path)
        {
            return FreeSpaceAsync(path).GetAwaiter().GetResult();
        }
        #endregion
    }
}
