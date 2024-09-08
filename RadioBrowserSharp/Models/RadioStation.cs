using System.Text.Json.Serialization;

namespace RadioBrowserSharp.Models
{
    public class RadioStation
    {

        [JsonPropertyName("changeuuid")]
        public string? ChangeUUID { get; set; }

        [JsonPropertyName("stationuuid")]
        public string? StationUUID { get; set; }

        [JsonPropertyName("serveruuid")]
        public string? ServerUUID { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("url_resolved")]
        public string? UrlResolved { get; set; }

        [JsonPropertyName("homepage")]
        public string? HomePage { get; set; }

        [JsonPropertyName("favicon")]
        public string? Favicon { get; set; }

        [JsonPropertyName("tags")]
        public string? Tags { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("countrycode")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("language")]
        public string? Language { get; set; }

        [JsonPropertyName("languagecodes")]
        public string? LanguageCodes { get; set; }

        [JsonPropertyName("votes")]
        public int Votes { get; set; }

        [JsonPropertyName("lastchangetime")]
        public string? LastChangeTime { get; set; }

        [JsonPropertyName("codec")]
        public string? Codec { get; set; }

        [JsonPropertyName("bitrate")]
        public int Bitrate { get; set; }

        [JsonPropertyName("hls")]
        public int HLS { get; set; }

        [JsonPropertyName("lastcheckok")]
        public int LastCheckOK { get; set; }

        [JsonPropertyName("lastchecktime")]
        public string? LastCheckTime { get; set; }

        [JsonPropertyName("lastcheckoktime")]
        public string? LastCheckOKTime { get; set; }

        [JsonPropertyName("lastlocalchecktime")]
        public string? LastLocalCheckTime { get; set; }

        [JsonPropertyName("clicktimestamp")]
        public string? ClickTimestamp { get; set; }

        [JsonPropertyName("clickcount")]
        public int ClickCount { get; set; }

        [JsonPropertyName("clicktrend")]
        public int ClickTrend { get; set; }

        [JsonPropertyName("ssl_error")]
        public int SSLError { get; set; }

        [JsonPropertyName("geo_lat")]
        public double? GeoLat { get; set; }

        [JsonPropertyName("geo_long")]
        public double? GeoLong { get; set; }

        [JsonPropertyName("has_extended_info")]
        public bool? HasExtendedInfo { get; set; }
    }
}
