using System.Text.Json.Serialization;
using Transmission.API.RPC.Arguments;

namespace Transmission.API.RPC.Entity
{
	public class AddTorrentInfo
	{
		[JsonPropertyName(ApiFields.TORRENT_ADDED)]
		public NewTorrentInfo TorrentAdded { get; set; }
		
		[JsonPropertyName(ApiFields.TORRENT_DUPLICATE)]
		public NewTorrentInfo TorrentDublicate { get; set; }
	}
	
	/// <summary>
	/// Information of added torrent
	/// </summary>
	public class NewTorrentInfo
	{
		/// <summary>
		/// Torrent ID
		/// </summary>
		[JsonPropertyName(TorrentFields.ID)]
		public int Id { get; set; }

		/// <summary>
		/// Torrent name
		/// </summary>
		[JsonPropertyName(TorrentFields.NAME)]
		public string Name { get; set; }

		/// <summary>
		/// Torrent Hash
		/// </summary>
		[JsonPropertyName(TorrentFields.HASH_STRING)]
		public string HashString { get; set; }

	}
}
