using RadioBrowserSharp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RadioBrowserSharp
{
    public class RadioBrowserApi
    {
        public const string BASE_URL = "all.api.radio-browser.info";
        public const string DEFAULT_URL = "de1.api.radio-browser.info";


        private static string _url = DEFAULT_URL;
        private static readonly Lazy<HttpClient> _client = new Lazy<HttpClient>(() => new HttpClient()
        {
            BaseAddress = new Uri("https://" + _url)
        });

        public static async Task<List<Country>?> ListCountriesAsync(CancellationToken token = default)
        {
            return await GetAsync<List<Country>>("/json/countries", token);
        }

        public static async Task<List<CountryCode>?> ListCountryCodesAsync(CancellationToken token = default)
        {
            return await GetAsync<List<CountryCode>>("/json/countrycodes", token);
        }

        public static async Task<List<Codec>?> ListCodecsAsync(CancellationToken token = default)
        {
            return await GetAsync<List<Codec>>("/json/codecs", token);
        }
       
        public static async Task<List<State>?> ListStatesAsync(CancellationToken token = default)
        {
            return await GetAsync<List<State>>("/json/states", token);
        }

        public static async Task<List<Language>?> ListLanguagesAsync(CancellationToken token = default)
        {
            return await GetAsync<List<Language>>("/json/languages", token);
        }

        public static async Task<List<Tag>?> ListTagsAsync(CancellationToken token = default)
        {
            return await GetAsync<List<Tag>>("/json/tags", token);
        }

        public static async Task<List<RadioStation>?> ListRadioStationsAsync(SearchType searchType,string content, ListStationsParams searchParams, CancellationToken token = default)
        {
            return await GetAsync<List<RadioStation>>($"/json/{searchType.ToString().ToLower()}/{content}{searchParams.ToUrl()}", token);
        }
        public static async Task<List<RadioStation>?> ListAllRadioStationsAsync(ListStationsParams searchParams, CancellationToken token = default)
        {
            return await GetAsync<List<RadioStation>>($"/json/stations{searchParams.ToUrl()}", token);
        }
        public static async Task<List<StationCheckResult>?> ListStationCheckResultsAsync(ListCheckParams listCheckParams, CancellationToken token = default)
        {            
            return await GetAsync<List<StationCheckResult>>($"/json/checks{listCheckParams.ToUrl()}", token);
        }

        public static async Task<List<Click>?> ListClicksAsync(ListClicksParams listClicksParams ,CancellationToken token = default)
        {
            return await GetAsync<List<Click>>($"/json/clicks{listClicksParams.ToUrl()}", token);
        }
        public static async Task<List<RadioStation>> SearchAsync(Dictionary<string,string> searchParams, CancellationToken token = default)
        {
            return await GetAsync<List<RadioStation>>($"/json/stations/search{SearchParams.GetUrl(searchParams)}", token);
        }

        public static async Task<List<RadioStation>> SearchByUUIDAsync(string uuids, CancellationToken token = default)
        {
            return await GetAsync<List<RadioStation>>($"/json/stations/byuuid?uuids={uuids}", token);
        }

        public static async Task<List<RadioStation>> SearchTopClicksAsync(TopParams topParams, CancellationToken token = default)
        {
            return await GetAsync<List<RadioStation>>($"/json/stations/topclick{topParams.ToUrl()}", token);
        }

        public static async Task<List<RadioStation>> SearchTopVotesAsync(TopParams topParams, CancellationToken token = default)
        {
            return await GetAsync<List<RadioStation>>($"/json/stations/topvote{topParams.ToUrl()}", token);
        }

        public static async Task<List<RadioStation>> SearchRecentClickAsync(TopParams topParams, CancellationToken token = default)
        {
            return await GetAsync<List<RadioStation>>($"/json/stations/lastclick{topParams.ToUrl()}", token);
        }
        public static async Task<List<RadioStation>> SearchLastChangeAsync(TopParams topParams, CancellationToken token = default)
        {
            return await GetAsync<List<RadioStation>>($"/json/stations/lastchange{topParams.ToUrl()}", token);
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

        private static async Task<T> GetAsync<T>(string queryUrl, CancellationToken token)
        {
            var response = await _client.Value.GetAsync(queryUrl, token);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }        
    }
}
