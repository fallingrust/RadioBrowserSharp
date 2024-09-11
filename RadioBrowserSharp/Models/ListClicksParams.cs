using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RadioBrowserSharp.Models
{
    public class ListClicksParams
    {
        public string StationUUID { get; set; } = string.Empty;
        public string Lastcheckuuid { get; set; } = string.Empty;
        public int Seconds { get; set; } = 0;
      

        public string ToUrl()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(StationUUID))
            {
                sb.Append("/");
                sb.Append(StationUUID);
            }
            sb.Append("?");

            sb.Append("seconds=");
            sb.Append(Seconds);

            if (!string.IsNullOrWhiteSpace(Lastcheckuuid))
            {
                sb.Append("&lastcheckuuid=");
                sb.Append(Lastcheckuuid);
            }
            return sb.ToString();
        }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ListClicksParams))]
    [JsonSerializable(typeof(IEnumerable<ListClicksParams>))]
    public partial class ListClicksParamsSerializerContext : JsonSerializerContext
    {
    }
}
