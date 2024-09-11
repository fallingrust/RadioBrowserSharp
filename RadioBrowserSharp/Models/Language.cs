using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RadioBrowserSharp.Models
{
    public class Language
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("iso_639")]
        public string? LanguageCode { get; set; }

        [JsonPropertyName("stationcount")]
        public int StationCount { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Language))]
    [JsonSerializable(typeof(IEnumerable<Language>))]
    public partial class LanguageSerializerContext : JsonSerializerContext
    {
    }
}
