using RadioBrowserSharp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace RadioBrowserSharp
{
    public class RadioBrowserApi
    {
        public const string BASE_URL = "https://all.api.radio-browser.info";
     
        private static readonly Lazy<HttpClient> _client = new(() => new()
        {
            BaseAddress = new Uri(BASE_URL)
        });

        public static async Task<IEnumerable<Country>?> ListCountriesAsync(Dictionary<string, string> searchParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/countries{searchParams.ToUrl()}", CountrySerializerContext.Default.IEnumerableCountry, token);
        }

        public static async Task<IEnumerable<Codec>?> ListCodecsAsync(Dictionary<string, string> searchParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/codecs{searchParams.ToUrl()}", CodecSerializerContext.Default.IEnumerableCodec, token);
        }
       
        public static async Task<IEnumerable<State>?> ListStatesAsync(string? country, Dictionary<string, string> searchParams, CancellationToken token = default)
        {
            if (!string.IsNullOrWhiteSpace(country))
            {
                return await GetAsync($"/json/states/{country}{searchParams.ToUrl()}", StateSerializerContext.Default.IEnumerableState, token);
            }
            return await GetAsync($"/json/states{searchParams.ToUrl()}",StateSerializerContext.Default.IEnumerableState, token);
        }

        public static async Task<IEnumerable<Language>?> ListLanguagesAsync(Dictionary<string, string> searchParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/languages{searchParams.ToUrl()}", LanguageSerializerContext.Default.IEnumerableLanguage, token);
        }

        public static async Task<IEnumerable<Tag>?> ListTagsAsync(Dictionary<string, string> searchParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/tags{searchParams.ToUrl()}", TagSerializerContext.Default.IEnumerableTag,token);
        }

        public static async Task<IEnumerable<RadioStation>?> SearchStationsByAsync(SearchBy searchType, string searchterm, CancellationToken token = default)
        {
            return await GetAsync($"/json/{searchType.ToString().ToLower()}/{searchterm}",RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }
        public static async Task<IEnumerable<RadioStation>?> ListAllRadioStationsAsync(CancellationToken token = default)
        {
            return await GetAsync($"/json/stations", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }

        public static async Task<IEnumerable<StationCheckResult>?> ListStationCheckResultsAsync(string? stationUUID, Dictionary<string, string> searchParams, CancellationToken token = default)
        {
            if (!string.IsNullOrWhiteSpace(stationUUID))
            {
                return await GetAsync($"/json/checks/{stationUUID}{searchParams.ToUrl()}", StationCheckResultSerializerContext.Default.IEnumerableStationCheckResult, token);
            }
            return await GetAsync($"/json/checks{searchParams.ToUrl()}", StationCheckResultSerializerContext.Default.IEnumerableStationCheckResult, token);
        }

        public static async Task<IEnumerable<Click>?> ListClicksAsync(string? stationUUID, Dictionary<string, string> searchParams, CancellationToken token = default)
        {
            if (!string.IsNullOrWhiteSpace(stationUUID))
            {
                return await GetAsync($"/json/clicks/{stationUUID}{searchParams.ToUrl()}", ClickSerializerContext.Default.IEnumerableClick, token);
            }
            return await GetAsync($"/json/clicks{searchParams.ToUrl()}", ClickSerializerContext.Default.IEnumerableClick, token);
        }

        public static async Task<ClickCounter?> ClickCounterAsync(string stationUUID, CancellationToken token = default)
        {
            return await GetAsync($"/json/url/{stationUUID}", ClickCounterSerializerContext.Default.ClickCounter, token);
        }

        public static async Task<VoteCounter?> VoteCounterAsync(string stationUUID, CancellationToken token = default)
        {
            return await GetAsync($"/json/vote/{stationUUID}", VoteCounterSerializerContext.Default.VoteCounter, token);
        }

        public static async Task<IEnumerable<RadioStation>?> SearchAsync(Dictionary<string,string> searchParams, CancellationToken token = default)
        {
            return await GetAsync($"/json/stations/search{searchParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }

        public static async Task<IEnumerable<RadioStation>?> SearchTopClicksAsync(int count, Dictionary<string, string> searchParams, CancellationToken token = default)
        {
            if (count > 0)
            {
                return await GetAsync($"/json/stations/topclick/{count}{searchParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
            }
            return await GetAsync($"/json/stations/topclick{searchParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }

        public static async Task<IEnumerable<RadioStation>?> SearchTopVotesAsync(int count, Dictionary<string, string> searchParams, CancellationToken token = default)
        {
            if (count > 0)
            {
                return await GetAsync($"/json/stations/topvote/{count}{searchParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
            }
            return await GetAsync($"/json/stations/topvote{searchParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }

        public static async Task<IEnumerable<RadioStation>?> SearchRecentClickAsync(int count, Dictionary<string, string> searchParams, CancellationToken token = default)
        {
            if (count > 0)
            {
                return await GetAsync($"/json/stations/lastclick/{count}{searchParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
            }
            return await GetAsync($"/json/stations/lastclick{searchParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }
      
        public static async Task<IEnumerable<RadioStation>?> SearchLastChangeAsync(int count, Dictionary<string, string> searchParams, CancellationToken token = default)
        {
            if (count > 0)
            {
                return await GetAsync($"/json/stations/lastchange/{count}{searchParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
            }
            return await GetAsync($"/json/stations/lastchange{searchParams.ToUrl()}", RadioStationSerializerContext.Default.IEnumerableRadioStation, token);
        }

        private static async Task<T?> GetAsync<T>(string queryUrl, JsonTypeInfo<T> jsonTypeInfo, CancellationToken token = default)
        {
            var response = await _client.Value.GetAsync(queryUrl, token);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<T>(content, jsonTypeInfo);
        }
    }
}
