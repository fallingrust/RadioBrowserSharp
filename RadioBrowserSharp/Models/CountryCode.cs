using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RadioBrowserSharp.Models
{
    public class CountryCode
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("stationcount")]
        public int StationCount { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(CountryCode))]
    [JsonSerializable(typeof(IEnumerable<CountryCode>))]
    public partial class CountryCodeSerializerContext : JsonSerializerContext
    {
    }
}
