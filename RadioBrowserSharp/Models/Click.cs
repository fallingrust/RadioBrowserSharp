using System.Text.Json.Serialization;

namespace RadioBrowserSharp.Models
{
    public class Click
    {
        [JsonPropertyName("stationuuid")]
        public string? StationUUID { get; set; }

        [JsonPropertyName("clickuuid")]
        public string? ClickUUID { get; set; }

        [JsonPropertyName("clicktimestamp")]
        public string? ClickTimestamp { get; set; }

    }
}
