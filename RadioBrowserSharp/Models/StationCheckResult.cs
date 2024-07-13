using System.Text.Json.Serialization;

namespace RadioBrowserSharp.Models
{
    public class StationCheckResult
    {
        [JsonPropertyName("stationuuid")]
        public string? StationUUID { get; set; }

        [JsonPropertyName("checkuuid")]
        public string? CheckUUID { get; set; }

        [JsonPropertyName("source")]
        public string? Source { get; set; }

        [JsonPropertyName("codec")]
        public string? Codec { get; set; }

        [JsonPropertyName("bitrate")]
        public int Bitrate { get; set; }

        [JsonPropertyName("hls")]
        public int HLS { get; set; }

        [JsonPropertyName("ok")]
        public int OK { get; set; }

        [JsonPropertyName("timestamp")]
        public string? Timestamp { get; set; }

        [JsonPropertyName("urlcache")]
        public string? UrlCache { get; set; }

        [JsonPropertyName("metainfo_overrides_database")]
        public int MetainfoOverridesDatabase { get; set; }

        [JsonPropertyName("public")]
        public string? Public { get; set; }


        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("tags")]
        public string? Tags { get; set; }

        [JsonPropertyName("countrycode")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("homepage")]
        public string? HomePage { get; set; }

        [JsonPropertyName("favicon")]
        public string? Favicon { get; set; }

        [JsonPropertyName("loadbalancer")]
        public string? LoadBalancer { get; set; }

        [JsonPropertyName("do_not_index")]
        public string? DoNotIndex { get; set; }

        [JsonPropertyName("countrysubdivisioncode")]
        public string? CountrySubDivisionCode { get; set; }

        [JsonPropertyName("server_software")]
        public string? ServerSoftware { get; set; }

        [JsonPropertyName("sampling")]
        public string? Sampling { get; set; }

        [JsonPropertyName("timing_ms")]
        public int TimingMS { get; set; }

        [JsonPropertyName("languagecodes")]
        public string? LanguageCodes { get; set; }

        [JsonPropertyName("ssl_error")]
        public int SSLError { get; set; }

        [JsonPropertyName("geo_lat")]
        public double GeoLat { get; set; }

        [JsonPropertyName("geo_long")]
        public double GeoLong { get; set; }
    }
}
