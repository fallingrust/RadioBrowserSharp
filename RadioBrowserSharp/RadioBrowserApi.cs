using RadioBrowserSharp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace RadioBrowserSharp
{
    public class RadioBrowserApi
    {
        public const string BASE_URL = "all.api.radio-browser.info";
        public const string DEFAULT_URL = "de1.api.radio-browser.info";


        private static string _url = DEFAULT_URL;
        private static readonly Lazy<HttpClient> _client = new(() => new()
        {
            BaseAddress = new Uri("https://" + _url)
        });

        public static async Task<IEnumerable<Country>?> ListCountriesAsync(CancellationToken token = default)
        {
            return await GetAsync("/json/countries",CountrySerializerContext.Default.IEnumerableCountry, token);
        }

        public static async Task<IEnumerable<CountryCode>?> ListCountryCodesAsync(CancellationToken token = default)
        {
            return await GetAsync("/json/countrycodes",CountryCodeSerializerContext.Default.IEnumerableCountryCode, token);
        }

        public static async Task<IEnumerable<Codec>?> ListCodecsAsync(CancellationToken token = default)
        {
            return await GetAsync("/json/codecs", CodecSerializerContext.Default.IEnumerableCodec, token);
        }
       
        public static async Task<IEnumerable<State>?> ListStatesAsync(CancellationToken token = default)
        {
            return await GetAsync("/json/states",StateSerializerContext.Default.IEnumerableState, token);
        }

        public static async Task<IEnumerable<Language>?> ListLanguagesAsync(CancellationToken token = default)
        {
            return await GetAsync("/json/languages",LanguageSerializerContext.Default.IEnumerableLanguage, token);
        }

        public static async Task<IEnumerable<Tag>?> ListTagsAsync(CancellationToken token = default)
        {
            return await GetAsync("/json/tags", TagSerializerContext.Default.IEnumerableTag,token);
        }

        public static async Task<IEnumerable<RadioStation>?> ListRadioStationsAsync(SearchType searchType,string content, ListStationsParams searchParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/{searchType.ToString().ToLower()}/{content}{searchParams.ToUrl()}",RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }
        public static async Task<IEnumerable<RadioStation>?> ListAllRadioStationsAsync(ListStationsParams searchParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/stations{searchParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }
        public static async Task<IEnumerable<StationCheckResult>?> ListStationCheckResultsAsync(ListCheckParams listCheckParams, CancellationToken token = default)
        {            
            return await GetAsync($"/json/checks{listCheckParams.ToUrl()}",StationCheckResultSerializerContext.Default.IEnumerableStationCheckResult, token);
        }

        public static async Task<IEnumerable<Click>?> ListClicksAsync(ListClicksParams listClicksParams ,CancellationToken token = default)
        {
            return await GetAsync($"/json/clicks{listClicksParams.ToUrl()}",ClickSerializerContext.Default.IEnumerableClick, token);
        }
        public static async Task<IEnumerable<RadioStation>> SearchAsync(Dictionary<string,string> searchParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/stations/search{SearchParams.GetUrl(searchParams)}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }

        public static async Task<IEnumerable<RadioStation>> SearchByUUIDAsync(string uuids, CancellationToken token = default)
        {
            return await GetAsync($"/json/stations/byuuid?uuids={uuids}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }

        public static async Task<IEnumerable<RadioStation>> SearchTopClicksAsync(TopParams topParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/stations/topclick{topParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }

        public static async Task<IEnumerable<RadioStation>> SearchTopVotesAsync(TopParams topParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/stations/topvote{topParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }

        public static async Task<IEnumerable<RadioStation>> SearchRecentClickAsync(TopParams topParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/stations/lastclick{topParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }
        public static async Task<IEnumerable<RadioStation>> SearchLastChangeAsync(TopParams topParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/stations/lastchange{topParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }


        public static void SetServerUrl(string url)
        {
            _url = url;
        }

        public static async Task<string> GetServersAsync()
        {
            var ips = await Dns.GetHostAddressesAsync(BASE_URL);
            var url = DEFAULT_URL;
            var lastReplayTime = long.MaxValue;
            foreach (var ip in ips)
            {
                var replay = await new Ping().SendPingAsync(ip);
                if (replay != null && replay.Status == IPStatus.Success && replay.RoundtripTime < lastReplayTime)
                {
                    lastReplayTime = replay.RoundtripTime;
                    url = ip.ToString();
                }
            }
            url = (await Dns.GetHostEntryAsync(url))?.HostName;
            if (!string.IsNullOrWhiteSpace(url))
            {
                return url;
            }
            return DEFAULT_URL;
        }

        private static async Task<T> GetAsync<T>(string queryUrl, JsonTypeInfo<T> jsonTypeInfo, CancellationToken token)
        {
            var response = await _client.Value.GetAsync(queryUrl, token);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, jsonTypeInfo);
        }
    }
}
