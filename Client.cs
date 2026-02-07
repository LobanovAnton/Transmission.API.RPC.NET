using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Transmission.API.RPC.Entity;
using Transmission.API.RPC.Params;
using Transmission.API.RPC.Utils;

namespace Transmission.API.RPC
{
    /// <summary>
    /// Transmission client
    /// </summary>
    public partial class Client : ITransmissionClient, ITransmissionClientAsync
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
        public void CloseSession()
        {
            CloseSessionAsync().WaitAndUnwrapException();
        }

        /// <summary>
        /// Set information to current session (API: session-set)
        /// </summary>
        /// <param name="settings">New session settings</param>
        public void SetSessionSettings(SessionSettings settings)
        {
            SetSessionSettingsAsync(settings).WaitAndUnwrapException();
        }

        /// <summary>
        /// Get session stat
        /// </summary>
        /// <returns>Session stat</returns>
        public Statistic GetSessionStatistic()
        {
            var task = GetSessionStatisticAsync();
            task.WaitAndUnwrapException();
            return task.Result;
        }

        /// <summary>
        /// Get information of current session (API: session-get)
        /// </summary>
        /// <returns>Session information</returns>
        public SessionInfo GetSessionInformation(string[] fields)
        {
            var task = GetSessionInformationAsync(fields);
            task.WaitAndUnwrapException();
            return task.Result;
        }

        #endregion

        #region Torrents methods

        /// <summary>
        /// Add torrent (API: torrent-add)
        /// </summary>
        /// <returns>Torrent info (ID, Name and HashString)</returns>
		public AddTorrentInfo TorrentAdd(NewTorrent torrent)
        {
            var task = TorrentAddAsync(torrent);
            task.WaitAndUnwrapException();
            return task.Result;
        }

        /// <summary>
        /// Set torrent params (API: torrent-set)
        /// </summary>
        /// <param name="settings">Torrent settings</param>
        public void TorrentSet(TorrentSettings settings)
        {
            TorrentSetAsync(settings).WaitAndUnwrapException();
        }

        /// <summary>
        /// Get fields of torrents from ids (API: torrent-get)
        /// </summary>
        /// <param name="fields">Fields of torrents</param>
        /// <param name="ids">IDs of torrents (null or empty for get all torrents)</param>
        /// <returns>Torrents info</returns>
        public TransmissionTorrents TorrentGet(string[] fields, object[] ids)
        {
            var task = TorrentGetAsync(fields, ids);
            task.WaitAndUnwrapException();
            return task.Result;
        }

        /// <summary>
        /// Remove torrents (API: torrent-remove)
        /// </summary>
        /// <param name="ids">Torrents id</param>
        /// <param name="deleteData">Remove data</param>
        public void TorrentRemove(object[] ids, bool deleteData = false)
        {
            TorrentRemoveAsync(ids, deleteData).WaitAndUnwrapException();
        }

        #region Torrent Start
        /// <summary>
        /// Start torrents (API: torrent-start)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        public void TorrentStart(object[] ids)
        {
            TorrentStartAsync(ids).WaitAndUnwrapException();
        }

        /// <summary>
        /// Start recently active torrents (API: torrent-start)
        /// </summary>
        public void TorrentStart()
        {
            TorrentStartAsync().WaitAndUnwrapException();
        }
        #endregion

        #region Torrent Start Now

        /// <summary>
        /// Start now torrents (API: torrent-start-now)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        public void TorrentStartNow(object[] ids)
        {
            TorrentStartNowAsync(ids).WaitAndUnwrapException();
        }

        /// <summary>
        /// Start now recently active torrents (API: torrent-start-now)
        /// </summary>
        public void TorrentStartNow()
        {
            TorrentStartNowAsync().WaitAndUnwrapException();
        }
        #endregion

        #region Torrent Stop
        /// <summary>
        /// Stop torrents (API: torrent-stop)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        public void TorrentStop(object[] ids)
        {
            TorrentStopAsync(ids).WaitAndUnwrapException();
        }

        /// <summary>
        /// Stop recently active torrents (API: torrent-stop)
        /// </summary>
        public void TorrentStop()
        {
            TorrentStopAsync().WaitAndUnwrapException();
        }
        #endregion

        #region Torrent Reannounce

        void ITransmissionClient.TorrentReannounceAsync()
        {
            TorrentReannounceAsync().WaitAndUnwrapException();
        }

        void ITransmissionClient.TorrentReannounceAsync(object[] ids)
        {
            TorrentReannounceAsync(ids).WaitAndUnwrapException();
        }

        #endregion

        #region Torrent Verify
        /// <summary>
        /// Verify torrents (API: torrent-verify)
        /// </summary>
        /// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
        public void TorrentVerify(object[] ids)
        {
            TorrentVerifyAsync(ids).WaitAndUnwrapException();
        }
        

        /// <summary>
        /// Verify recently active torrents (API: torrent-verify)
        /// </summary>
        public void TorrentVerify()
        {
            TorrentVerifyAsync().WaitAndUnwrapException();
        }
        #endregion
        
        void ITransmissionClient.GroupSet(Group group)
        {
            GroupSet(group).WaitAndUnwrapException();
        }

        GroupsInfo ITransmissionClient.GroupGet(string groupName)
        {
            var task = GroupGet(groupName);
            task.WaitAndUnwrapException();
            return task.Result;
        }

        /// <summary>
        /// Move torrents in queue on top (API: queue-move-top)
        /// </summary>
        /// <param name="ids">Torrents id</param>
        public void TorrentQueueMoveTop(object[] ids)
        {
            TorrentQueueMoveTopAsync(ids).WaitAndUnwrapException();
        }

        /// <summary>
        /// Move up torrents in queue (API: queue-move-up)
        /// </summary>
        /// <param name="ids"></param>
        public void TorrentQueueMoveUp(object[] ids)
        {
            TorrentQueueMoveUpAsync(ids).WaitAndUnwrapException();
        }

        /// <summary>
        /// Move down torrents in queue (API: queue-move-down)
        /// </summary>
        /// <param name="ids"></param>
        public void TorrentQueueMoveDown(object[] ids)
        {
            TorrentQueueMoveDownAsync(ids).WaitAndUnwrapException();
        }

        /// <summary>
        /// Move torrents to bottom in queue  (API: queue-move-bottom)
        /// </summary>
        /// <param name="ids"></param>
        public void TorrentQueueMoveBottom(object[] ids)
        {
            TorrentQueueMoveBottomAsync(ids).WaitAndUnwrapException();
        }

        /// <summary>
        /// Set new location for torrents files (API: torrent-set-location)
        /// </summary>
        /// <param name="ids">Torrent ids</param>
        /// <param name="location">The new torrent location</param>
        /// <param name="move">Move from previous location</param>
        public void TorrentSetLocation(object[] ids, string location, bool move)
        {
            TorrentSetLocationAsync(ids, location, move).WaitAndUnwrapException();
        }

        /// <summary>
        /// Rename a file or directory in a torrent (API: torrent-rename-path)
        /// </summary>
        /// <param name="id">The torrent whose path will be renamed</param>
        /// <param name="path">The path to the file or folder that will be renamed</param>
        /// <param name="name">The file or folder's new name</param>
		public RenameTorrentInfo TorrentRenamePath(int id, string path, string name)
        {
            var task = TorrentRenamePathAsync(id, path, name);
            task.WaitAndUnwrapException();
            return task.Result;
        }

        #endregion

        #region System
        /// <summary>
        /// See if your incoming peer port is accessible from the outside world (API: port-test)
        /// </summary>
        /// <returns>Accessible state</returns>
        public PortTest PortTest()
        {
            var task = PortTestAsync();
            task.WaitAndUnwrapException();
            return task.Result;
        }

        /// <summary>
        /// Update blocklist (API: blocklist-update)
        /// </summary>
        /// <returns>Blocklist size</returns>
        public int BlocklistUpdate()
        {
            var task = BlocklistUpdateAsync();
            task.WaitAndUnwrapException();
            return task.Result;
        }

        /// <summary>
        /// Get free space is available in a client-specified folder.
        /// </summary>
        /// <param name="path">The directory to query</param>
        public FreeSpace FreeSpace(string path)
        {
            var task = FreeSpaceAsync(path);
            task.WaitAndUnwrapException();
            return task.Result;
        }
        #endregion
    }
}
