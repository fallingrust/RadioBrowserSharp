using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RadioBrowserSharp.Models
{
    public class VoteCounter
    {
        [JsonPropertyName("ok")]
        public string? Ok { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(VoteCounter))]
    [JsonSerializable(typeof(IEnumerable<VoteCounter>))]
    public partial class VoteCounterSerializerContext : JsonSerializerContext
    {
    }
}
