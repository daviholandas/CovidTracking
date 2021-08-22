using System;
using System.Text.Json.Serialization;
using BoxTI.Challenge.CovidTracking.WebApi.Configs;

namespace BoxTI.Challenge.CovidTracking.WebApi
{
    public struct CovidTrackingInfoDto
    {
        [JsonPropertyName("Active Cases_text")]
        [JsonConverter(typeof(JsonConvertOnlyNumbers))]
        public double ActiveCases {get; set;}
        
        [JsonPropertyName("Country_text")]
        public string Country {get; set;}
        
        [JsonPropertyName("Last Update")]
        [JsonConverter(typeof(JsonConvertStringToDateTime))]
        public DateTime LastUpdate {get; set;}
        
        [JsonPropertyName("New Cases_text")]
        [JsonConverter(typeof(JsonConvertOnlyNumbers))]
        public double NewCases {get; set;}
        
        [JsonPropertyName("New Deaths_text")]
        [JsonConverter(typeof(JsonConvertOnlyNumbers))]
        public double NewDeaths {get; set;}
        
        [JsonPropertyName("Total Cases_text")]
        [JsonConverter(typeof(JsonConvertStringToNumber))]
        public double TotalCases {get; set;}
        
        [JsonPropertyName("Total Deaths_text")]
        [JsonConverter(typeof(JsonConvertStringToNumber))]
        public double TotalDeaths {get; set;}
        
        [JsonPropertyName("Total Recovered_text")]
        [JsonConverter(typeof(JsonConvertStringToNumber))]
        public double TotalRecovered {get; set;}
    }
}
