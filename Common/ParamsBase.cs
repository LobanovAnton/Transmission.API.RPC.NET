using System.Collections.Generic;

namespace Transmission.API.RPC.Common
{
    /// <summary>
    /// Abstract class for arguments
    /// </summary>
    public abstract class ParamsBase
    {
        internal readonly Dictionary<string, object> Data = new();

        internal object this[string name]
        {
            set => Data[name] = value;
        }

        internal T GetValue<T>(string name)
        {
            return Data.TryGetValue(name, out var value) ? (T)value : default;
        }
    }
}
