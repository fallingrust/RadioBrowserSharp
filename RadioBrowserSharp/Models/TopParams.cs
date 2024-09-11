using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RadioBrowserSharp.Models
{
    public class TopParams
    {
        public uint Offset { get; set; } = 0;

        public uint Limit { get; set; } = 100000;

        public bool HideBroken { get; set; } = false;

        public string ToUrl()
        {
            return $"?offst={Offset}&limit={Limit}&hidebroken={HideBroken}";
        }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(TopParams))]
    [JsonSerializable(typeof(IEnumerable<TopParams>))]
    public partial class TopParamsSerializerContext : JsonSerializerContext
    {
    }
}
