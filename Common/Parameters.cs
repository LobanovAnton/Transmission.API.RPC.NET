using System.Collections.Generic;

namespace Transmission.API.RPC.Common;

public class Parameters: Dictionary<string, object>
{
    internal T GetValue<T>(string name)
    {
        return TryGetValue(name, out var value) ? (T)value : default;
    }
}