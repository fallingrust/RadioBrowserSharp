using System.Text;

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
}
