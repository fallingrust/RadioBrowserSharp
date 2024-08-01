using RadioBrowserSharp;
using RadioBrowserSharp.Models;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var url = RadioBrowserApi.GetServersAsync().GetAwaiter().GetResult();
            Assert.NotNull(url);

            RadioBrowserApi.SetServerUrl(url);

            var countries = RadioBrowserApi.ListCountriesAsync().GetAwaiter().GetResult();
            Assert.NotNull(countries);
            Assert.NotEmpty(countries);

            var countryCodecs = RadioBrowserApi.ListCountryCodesAsync().GetAwaiter().GetResult();
            Assert.NotNull(countryCodecs);
            Assert.NotEmpty(countryCodecs);

            var codecs = RadioBrowserApi.ListCodecsAsync().GetAwaiter().GetResult();
            Assert.NotNull(codecs);
            Assert.NotEmpty(codecs);

            var states = RadioBrowserApi.ListStatesAsync().GetAwaiter().GetResult();
            Assert.NotNull(states);
            Assert.NotEmpty(states);

            var languages = RadioBrowserApi.ListLanguagesAsync().GetAwaiter().GetResult();
            Assert.NotNull(languages);
            Assert.NotEmpty(languages);

            var tags = RadioBrowserApi.ListTagsAsync().GetAwaiter().GetResult();
            Assert.NotNull(tags);
            Assert.NotEmpty(tags);

            //var radioStates = RadioBrowserApi.ListRadioStationsAsync( SearchType.ByCodec,"AAC").GetAwaiter().GetResult();
            //Assert.NotNull(radioStates);
            //Assert.NotEmpty(radioStates);

            //var allRadioStations = RadioBrowserApi.ListAllRadioStationsAsync().GetAwaiter().GetResult();
            //Assert.NotNull(allRadioStations);
            //Assert.NotEmpty(allRadioStations);

            //var stationCheckResults = RadioBrowserApi.ListStationCheckResultsAsync().GetAwaiter().GetResult();
            //Assert.NotNull(stationCheckResults);
            //Assert.NotEmpty(stationCheckResults);
        }
    }
}