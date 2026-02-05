using Transmission.API.RPC.Common;

namespace Transmission.API.RPC.Arguments
{
    /// <summary>
    /// Information about the torrent file, that will be added
    /// </summary>
    public class NewTorrent : ParamsBase
    {
        /// <summary>
        /// Pointer to a string of one or more cookies.
        /// </summary>
        public string Cookies
        {
            get => GetValue<string>(ApiFields.COOKIES);
            set => this[ApiFields.COOKIES] = value;
        }

        /// <summary>
        /// Path to download the torrent to
        /// </summary>
        public string DownloadDirectory
        {
            get => GetValue<string>(TorrentFields.DOWNLOAD_DIR);
            set => this[TorrentFields.DOWNLOAD_DIR] = value;
        }

        /// <summary>
        /// filename (relative to the server) or URL of the .torrent file (Priority than the metadata)
        /// </summary>
        public string Filename
        {
            get => GetValue<string>(ApiFields.FILENAME);
            set => this[ApiFields.FILENAME] = value;
        }
        
        public string[] Labels
        {
            get => GetValue<string[]>(TorrentFields.LABELS);
            set => this[TorrentFields.LABELS] = value;
        }

        /// <summary>
        /// base64-encoded .torrent content
        /// </summary>
        public string Metainfo
        {
            get => GetValue<string>(ApiFields.METAINFO);
            set => this[ApiFields.METAINFO] = value;
        }

        /// <summary>
        /// if true, don't start the torrent
        /// </summary>
        public bool? Paused
        {
            get => GetValue<bool?>(ApiFields.PAUSED);
            set => this[ApiFields.PAUSED] = value;
        }

        /// <summary>
        /// maximum number of peers
        /// </summary>
        public int? PeerLimit
        {
            get => GetValue<int?>(TorrentFields.PEER_LIMIT);
            set => this[TorrentFields.PEER_LIMIT] = value;
        }

        /// <summary>
        /// Torrent's bandwidth priority
        /// </summary>
        public int? BandwidthPriority
        {
            get => GetValue<int?>(TorrentFields.BANDWIDTH_PRIORITY);
            set => this[TorrentFields.BANDWIDTH_PRIORITY] = value;
        }

        /// <summary>
        /// Indices of file(s) to download
        /// </summary>
        public int[] FilesWanted
        {
            get => GetValue<int[]>(ApiFields.FILES_WANTED);
            set => this[ApiFields.FILES_WANTED] = value;
        }

        /// <summary>
        /// Indices of file(s) to download
        /// </summary>
        public int[] FilesUnwanted
        {
            get => GetValue<int[]>(ApiFields.FILES_UNWANTED);
            set => this[ApiFields.FILES_UNWANTED] = value;
        }

        /// <summary>
        /// Indices of high-priority file(s)
        /// </summary>
        public int[] PriorityHigh
        {
            get => GetValue<int[]>(ApiFields.PRIORITY_HIGH);
            set => this[ApiFields.PRIORITY_HIGH] = value;
        }

        /// <summary>
        /// Indices of low-priority file(s)
        /// </summary>
        public int[] PriorityLow
        {
            get => GetValue<int[]>(ApiFields.PRIORITY_LOW);
            set => this[ApiFields.PRIORITY_LOW] = value;
        }

        /// <summary>
        /// Indices of normal-priority file(s)
        /// </summary>
        public int[] PriorityNormal
        {
            get => GetValue<int[]>(ApiFields.PRIORITY_NORMAL);
            set => this[ApiFields.PRIORITY_NORMAL] = value;
        }
        
        public bool? SequentialDownload
        {
            get => GetValue<bool?>(TorrentFields.SEQUENTIAL_DOWNLOAD);
            set => this[TorrentFields.SEQUENTIAL_DOWNLOAD] = value;
        }

        public int? SequentialDownloadFromPiece
        {
            get => GetValue<int?>(TorrentFields.SEQUENTIAL_DOWNLOAD_FROM_PIECE);
            set => this[TorrentFields.SEQUENTIAL_DOWNLOAD_FROM_PIECE] = value;
        }
    }
}
