using RadioBrowserSharp.Models;

namespace RadioBrowserSharp.Extensions
{
    public static class SearchByExtension
    {
        public static string ToUrl(this SearchBy searchBy)
        {
            return searchBy switch
            {
                SearchBy.Byuuid => "byuuid",
                SearchBy.ByName => "byname",
                SearchBy.ByNameExact => "bynameexact",
                SearchBy.ByCodec => "bycodec",
                SearchBy.ByCodecExact => "bycodecexact",
                SearchBy.ByCountry => "bycountry",
                SearchBy.ByCountryExact => "bycountryexact",
                SearchBy.ByCountryCodeExact => "bycountrycodeexact",
                SearchBy.ByState => "bystate",
                SearchBy.ByStateExact => "bystateexact",
                SearchBy.ByLanguage => "bylanguage",
                SearchBy.ByLanguageExact => "bylanguageexact",
                SearchBy.ByTag => "bytag",
                SearchBy.ByTagExact => "bytagexact",
                _ => searchBy.ToString().ToLower()
            };

        }
    }
}
