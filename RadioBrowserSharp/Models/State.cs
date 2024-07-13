using System.Text.Json.Serialization;

namespace RadioBrowserSharp.Models
{
    public class State
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("stationcount")]
        public int StationCount { get; set; }
    }
}
