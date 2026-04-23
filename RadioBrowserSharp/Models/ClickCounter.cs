using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RadioBrowserSharp.Models
{
    public class ClickCounter
    {
        [JsonPropertyName("ok")]
        public string? Ok { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("stationuuid")]
        public string? StationUUID { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ClickCounter))]
    [JsonSerializable(typeof(IEnumerable<ClickCounter>))]
    public partial class ClickCounterSerializerContext : JsonSerializerContext
    {
    }
}
