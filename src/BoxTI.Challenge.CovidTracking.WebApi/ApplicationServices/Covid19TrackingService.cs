using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.WebApi.ApplicationServices.Interfaces;
using BoxTI.Challenge.CovidTracking.WebApi.Models;

namespace BoxTI.Challenge.CovidTracking.WebApi.ApplicationServices
{
    public class Covid19TrackingService : ICovid19TrackingService
    {
        private readonly HttpClient _covidTrackingClient;

        public Covid19TrackingService(HttpClient covidTrackingClient)
            => _covidTrackingClient = covidTrackingClient;
        public async Task<Result<CovidTrackingInfoDto>> GetLatestCovidReportByLocation(string locationName)
        {
            try
            {
                var response = await _covidTrackingClient
                    .GetFromJsonAsync<CovidTrackingInfoDto>($"/v1/{locationName.ToLower()}");
                _covidTrackingClient.Dispose();
                return  Result.Success<CovidTrackingInfoDto>(response);
            }
            catch (Exception e)
            {
                return Result.NotSuccess<CovidTrackingInfoDto>(e);
            }
        }
    }
}