using System.Text.Json;
using Transmission.API.RPC.Common;

namespace Transmission.API.RPC.Utils;

public static class ResponseExtension
{
    public static T Deserialize<T>(this TransmissionResponse response)
    {
        return (T)response.Result.Deserialize(typeof(T), SourceGenerationContext.Default);
    }
}