using System.Text.Json.Serialization;

namespace RadioBrowserSharp.Models
{
    public class Tag
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("stationcount")]
        public int StationCount { get; set; }
    }
}
