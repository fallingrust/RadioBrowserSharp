﻿using System.Text.Json.Serialization;
namespace RadioBrowserSharp.Models
{
    public class Country
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("iso_3166_1")]
        public string? CountryCode { get; set; }
       
        [JsonPropertyName("stationcount")]
        public int StationCount { get; set; }
    }
}