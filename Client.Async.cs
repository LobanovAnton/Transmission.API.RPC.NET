using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Transmission.API.RPC.Entity;
using Transmission.API.RPC.Common;
using Transmission.API.RPC.Params;
using Transmission.API.RPC.Utils;

namespace Transmission.API.RPC
{
	public partial class Client
	{
		#region Session methods

		/// <summary>
		/// Close current session (API: session-close)
		/// </summary>
		public async Task CloseSessionAsync(CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.SESSION_CLOSE
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Set information to current session (API: session-set)
		/// </summary>
		/// <param name="settings">New session settings</param>
		/// <param name="cancellationToken"></param>
		public async Task SetSessionSettingsAsync(SessionSettings settings, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.SESSION_SET,
				Parameters = settings
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Get session stat
		/// </summary>
		/// <returns>Session stat</returns>
		public async Task<Statistic> GetSessionStatisticAsync(CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.SESSION_STATS
			};

			var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
			var result = response.Deserialize<Statistic>();
			return result;
		}

        /// <summary>
        /// Get information of current session (API: session-get)
        /// </summary>
        /// <returns>Session information</returns>
        public async Task<SessionInfo> GetSessionInformationAsync(string[] fields = null, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.SESSION_GET,
				Parameters = new Parameters { { ApiFields.FIELDS, fields } }
			};

			var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
			var result = response.Deserialize<SessionInfo>();
			return result;
		}

		#endregion

		#region Torrents methods

		/// <summary>
		/// Add torrent (API: torrent-add)
		/// </summary>
		/// <returns>Torrent info (ID, Name and HashString)</returns>
		public async Task<AddTorrentInfo> TorrentAddAsync(NewTorrent torrent, CancellationToken cancellationToken = default)
		{
			if (String.IsNullOrWhiteSpace(torrent.Metainfo) && String.IsNullOrWhiteSpace(torrent.Filename))
				throw new Exception("Either \"filename\" or \"metainfo\" must be included.");

			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_ADD,
				Parameters = torrent
			};

			var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
			var result = response.Deserialize<AddTorrentInfo>();
			return result;
		}

		/// <summary>
		/// Set torrent params (API: torrent-set)
		/// </summary>
		/// <param name="settings">Torrent settings</param>
		/// <param name="cancellationToken"></param>
		public async Task TorrentSetAsync(TorrentSettings settings, CancellationToken cancellationToken = default)
        {
	        var request = new TransmissionRequest
	        {
		        Method = Methods.TORRENT_SET,
		        Parameters = settings
	        };

	        await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get fields of torrents from ids (API: torrent-get)
        /// </summary>
        /// <param name="fields">Fields of torrents</param>
        /// <param name="ids">IDs of torrents (null or empty for get all torrents)</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Torrents info</returns>
        public async Task<TransmissionTorrents> TorrentGetAsync(string[] fields, object[] ids, CancellationToken cancellationToken = default)
		{
			var arguments = new Parameters { { ApiFields.FIELDS, fields } };

			if (ids != null && ids.Length > 0)
				arguments.Add(ApiFields.IDS, ids);

			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_GET,
				Parameters = arguments
			};

			var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
			var result = response.Deserialize<TransmissionTorrents>();
			return result;
		}

		/// <summary>
		/// Remove torrents
		/// </summary>
		/// <param name="ids">Torrents id</param>
		/// <param name="deleteData">Remove data</param>
		/// <param name="cancellationToken"></param>
		public async Task TorrentRemoveAsync(object[] ids, bool deleteData = false, CancellationToken cancellationToken = default)
        {
	        var request = new TransmissionRequest
	        {
		        Method = Methods.TORRENT_REMOVE,
		        Parameters = new Parameters
		        {
			        { ApiFields.IDS, ids },
			        { ApiFields.DELETE_LOCAL_DATA, deleteData }
		        }
	        };

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		#region Torrent Start

		/// <summary>
		/// Start torrents (API: torrent-start)
		/// </summary>
		/// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
		/// <param name="cancellationToken"></param>
		public async Task TorrentStartAsync(object[] ids, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_START,
				Parameters = new Parameters { { ApiFields.IDS, ids } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Start recently active torrents (API: torrent-start)
		/// </summary>
		public async Task TorrentStartAsync(CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_START,
				Parameters = new Parameters { { ApiFields.IDS, ApiFields.RECENTLY_ACTIVE } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		#endregion

		#region Torrent Start Now

		/// <summary>
		/// Start now torrents (API: torrent-start-now)
		/// </summary>
		/// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
		/// <param name="cancellationToken"></param>
		public async Task TorrentStartNowAsync(object[] ids, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_START_NOW,
				Parameters = new Parameters { { ApiFields.IDS, ids } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Start now recently active torrents (API: torrent-start-now)
		/// </summary>
		public async Task TorrentStartNowAsync(CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_START_NOW,
				Parameters = new Parameters { { ApiFields.IDS, ApiFields.RECENTLY_ACTIVE } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		#endregion

		#region Torrent Stop

		/// <summary>
		/// Stop torrents (API: torrent-stop)
		/// </summary>
		/// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
		/// <param name="cancellationToken"></param>
		public async Task TorrentStopAsync(object[] ids, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_STOP,
				Parameters = new Parameters { { ApiFields.IDS, ids } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Stop recently active torrents (API: torrent-stop)
		/// </summary>
		public async Task TorrentStopAsync(CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_STOP,
				Parameters = new Parameters { { ApiFields.IDS, ApiFields.RECENTLY_ACTIVE } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}
		
		#endregion
		
		#region Torrent Reannounce

		public async Task TorrentReannounceAsync(object[] ids, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_REANNOUNCE,
				Parameters = new Parameters { { ApiFields.IDS, ids } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		public async Task TorrentReannounceAsync(CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_REANNOUNCE,
				Parameters = new Parameters { { ApiFields.IDS, ApiFields.RECENTLY_ACTIVE } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}
		
		#endregion

		#region Torrent Verify

		/// <summary>
		/// Verify torrents (API: torrent-verify)
		/// </summary>
		/// <param name="ids">A list of torrent id numbers, sha1 hash strings, or both</param>
		/// <param name="cancellationToken"></param>
		public async Task TorrentVerifyAsync(object[] ids, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_VERIFY,
				Parameters = new Parameters { { ApiFields.IDS, ids } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Verify recently active torrents (API: torrent-verify)
		/// </summary>
		public async Task TorrentVerifyAsync(CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_VERIFY,
				Parameters = new Parameters { { ApiFields.IDS, ApiFields.RECENTLY_ACTIVE } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}
		#endregion

		/// <summary>
		/// Move torrents in queue on top (API: queue-move-top)
		/// </summary>
		/// <param name="ids">Torrents id</param>
		/// <param name="cancellationToken"></param>
		public async Task TorrentQueueMoveTopAsync(object[] ids, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.QUEUE_MOVE_TOP,
				Parameters = new Parameters { { ApiFields.IDS, ids } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Move up torrents in queue (API: queue-move-up)
		/// </summary>
		/// <param name="ids"></param>
		/// <param name="cancellationToken"></param>
		public async Task TorrentQueueMoveUpAsync(object[] ids, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.QUEUE_MOVE_UP,
				Parameters = new Parameters { { ApiFields.IDS, ids } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Move down torrents in queue (API: queue-move-down)
		/// </summary>
		/// <param name="ids"></param>
		/// <param name="cancellationToken"></param>
		public async Task TorrentQueueMoveDownAsync(object[] ids, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.QUEUE_MOVE_DOWN,
				Parameters = new Parameters { { ApiFields.IDS, ids } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Move torrents to bottom in queue  (API: queue-move-bottom)
		/// </summary>
		/// <param name="ids"></param>
		/// <param name="cancellationToken"></param>
		public async Task TorrentQueueMoveBottomAsync(object[] ids, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.QUEUE_MOVE_BOTTOM,
				Parameters = new Parameters { { ApiFields.IDS, ids } }
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Set new location for torrents files (API: torrent-set-location)
		/// </summary>
		/// <param name="ids">Torrent ids</param>
		/// <param name="location">The new torrent location</param>
		/// <param name="move">Move from previous location</param>
		/// <param name="cancellationToken"></param>
		public async Task TorrentSetLocationAsync(object[] ids, string location, bool move, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_SET_LOCATION,
				Parameters = new Parameters
				{
					{ ApiFields.IDS, ids },
					{ ApiFields.LOCATION, location },
					{ ApiFields.MOVE, move }
				}
			};

			await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
		}

		/// <summary>
		/// Rename a file or directory in a torrent (API: torrent-rename-path)
		/// </summary>
		/// <param name="id">The torrent whose path will be renamed</param>
		/// <param name="path">The path to the file or folder that will be renamed</param>
		/// <param name="name">The file or folder's new name</param>
		/// <param name="cancellationToken"></param>
		public async Task<RenameTorrentInfo> TorrentRenamePathAsync(int id, string path, string name, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.TORRENT_RENAME_PATH,
				Parameters = new Parameters
				{
					{ ApiFields.IDS, new[] { id } },
					{ ApiFields.PATH, path },
					{ TorrentFields.NAME, name }
				}
			};

			var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
			var result = response.Deserialize<RenameTorrentInfo>();
			return result;
		}

		#endregion

		#region System

		/// <summary>
		/// See if your incoming peer port is accessible from the outside world (API: port-test)
		/// </summary>
		/// <returns>Accessible state</returns>
		public async Task<PortTest> PortTestAsync(CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.PORT_TEST
			};

			var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

			var data = response.Deserialize<PortTest>();
			return data;
		}

		/// <summary>
		/// Update blocklist (API: blocklist-update)
		/// </summary>
		/// <returns>Blocklist size</returns>
		public async Task<int> BlocklistUpdateAsync(CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.BLOCKLIST_UPDATE
			};

			var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

			var data = response.Deserialize<BlockList>();
			return data.BlockListSize;
		}

		/// <summary>
		/// Get free space is available in a client-specified folder.
		/// </summary>
		/// <param name="path">The directory to query</param>
		/// <param name="cancellationToken"></param>
		public async Task<FreeSpace> FreeSpaceAsync(string path, CancellationToken cancellationToken = default)
		{
			var request = new TransmissionRequest
			{
				Method = Methods.FREE_SPACE,
				Parameters = new Parameters { { ApiFields.PATH, path } }
			};

			var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

			var data = response.Deserialize<FreeSpace>();
			return data;
		}

        #endregion

        public async Task GroupSet(Group group, CancellationToken cancellationToken = default)
        {
	        TransmissionRequest request = new TransmissionRequest
	        {
		        Method = Methods.GROUP_SET,
		        Parameters = group
	        };

	        await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<GroupsInfo> GroupGet(string groupName = null, CancellationToken cancellationToken = default)
        {
	        var request = new TransmissionRequest
	        {
		        Method = Methods.GROUP_GET,
		        Parameters = new Parameters { { TorrentFields.NAME, groupName } }
	        };
	        
	        var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

	        GroupsInfo groupsInfo = response.Deserialize<GroupsInfo>();
	        return groupsInfo;
        }

        private async Task<TransmissionResponse> SendRequestAsync(TransmissionRequest request, CancellationToken cancellationToken)
        {
            TransmissionResponse result = new TransmissionResponse();

            request.Id = Interlocked.Increment(ref _currentTag);

            //Prepare http web request
            using HttpClient httpClient = HttpClientFactory.CreateClient();

            using HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, Url);
            httpRequest.Headers.Add("X-Transmission-Session-Id", SessionId);

            if (_needAuthorization)
                httpRequest.Headers.Add("Authorization", _authorization);

            httpRequest.Content = JsonContent.Create(request, SourceGenerationContext.Default.TransmissionRequest, JsonMediaType);

            //Send request and prepare response
            using var httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            if (httpResponse.IsSuccessStatusCode)
            {
	            result = (TransmissionResponse)await httpResponse.Content.ReadFromJsonAsync(typeof(TransmissionResponse),
		            SourceGenerationContext.Default, cancellationToken).ConfigureAwait(false);

	            if (result == null)
		            throw new JsonException("Transmission response is null");

	            if (result.Error != null)
		            throw new Exception($"Message: {result.Error.Message} Info: {result.Error.ErrorData?.ErrorString}");
            }
            else if (httpResponse.StatusCode == HttpStatusCode.Conflict)
            {
	            if (httpResponse.Headers.Any())
	            {
		            //If session id expired get session id and send request
		            if (httpResponse.Headers.TryGetValues("X-Transmission-Session-Id", out var values))
			            SessionId = values.First();
		            else
			            throw new Exception("Session ID Error");

		            result = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
	            }
            }
            else
	            throw new HttpRequestException(httpResponse.StatusCode.ToString());

            return result;
        }
    }
}
