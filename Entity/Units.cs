using System.Text.Json.Serialization;

namespace Transmission.API.RPC.Entity;

/// <summary>
/// Units
/// </summary>
public class Units
{
    /// <summary>
    /// Speed units
    /// </summary>
    [JsonPropertyName("speed_units")]
    public string[] SpeedUnits { get; set; }

    /// <summary>
    /// Speed bytes
    /// </summary>
    [JsonPropertyName("speed_bytes")]
    public int SpeedBytes { get; set; }

    /// <summary>
    /// Size units
    /// </summary>
    [JsonPropertyName("size_units")]
    public string[] SizeUnits { get; set; }

    /// <summary>
    /// Size bytes
    /// </summary>
    [JsonPropertyName("size_bytes")]
    public int SizeBytes { get; set; }

    /// <summary>
    /// Memory units
    /// </summary>
    [JsonPropertyName("memory_units")]
    public string[] MemoryUnits { get; set; }

    /// <summary>
    /// Memory bytes
    /// </summary>
    [JsonPropertyName("memory_bytes")]
    public int MemoryBytes { get; set; }
}