using System.Text.Json.Serialization;
using Transmission.API.RPC.Arguments;

namespace Transmission.API.RPC.Entity
{
	/// <summary>
    /// Rename torrent result information
    /// </summary>
	public class RenameTorrentInfo
	{ 
        /// <summary>
        /// The torrent's unique Id.
        /// </summary>
        [JsonPropertyName(TorrentFields.ID)]
        public int Id { get; set; }

		/// <summary>
		/// File path.
		/// </summary>
		[JsonPropertyName(ApiFields.PATH)]
		public string Path { get; set; }

		/// <summary>
		/// File name.
		/// </summary>
		[JsonPropertyName(TorrentFields.NAME)]
		public string Name { get; set; }
	}
}
