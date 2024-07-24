using System.Collections.Generic;
using System.Text;

namespace RadioBrowserSharp.Models
{
    public class SearchParams
    {
        public const string Name = "name";
        public const string NameExact = "nameExact";
        public const string Country = "country";
        public const string CountryExact = "countryExact";
        public const string CountryCode = "countrycode";
        public const string State = "state";
        public const string StateExact = "stateExact";
        public const string Language = "language";
        public const string LanguageExact = "languageExact";
        public const string Tag = "tag";
        public const string Codec = "codec";
        public const string BitrateMin = "bitrateMin";
        public const string BitrateMax = "bitrateMax";
        public const string HasGeoInfo = "has_geo_info";
        public const string HasExtendedInfo = "has_extended_info";
        public const string IsHttps = "is_https";
        public const string Order = "order";
        public const string Reverse = "reverse";
        public const string Offset = "offset";
        public const string Limit = "limit";
        public const string HideBroken = "hidebroken";

        public static string GetUrl(Dictionary<string, string> searchParams)
        {
            if (searchParams == null || searchParams.Count <= 0) return "";

            var sb = new StringBuilder("?");
          
            foreach (var kv in searchParams)
            {
                sb.Append("&");
                sb.Append(kv.Key);
                sb.Append("=");
                sb.Append(kv.Value);
            }
            return sb.ToString()[1..sb.Length];
        }
    }
}
