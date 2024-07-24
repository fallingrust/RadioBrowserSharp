using System.Text;

namespace RadioBrowserSharp.Models
{
    public class ListCheckParams
    {
        public string StationUUID { get; set; } = string.Empty;
        public string Lastcheckuuid { get; set; } = string.Empty;
        public int Seconds { get; set; } = 0;
        public uint Limit { get; set; } = 999999;

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

            sb.Append("&limit=");
            sb.Append(Limit);

            if (!string.IsNullOrWhiteSpace(Lastcheckuuid))
            {
                sb.Append("&lastcheckuuid=");
                sb.Append(Lastcheckuuid);
            }            
            return sb.ToString();
        }
    }
}
