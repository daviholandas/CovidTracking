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
        
        public async Task<Result<IEnumerable<CovidTrackingInfoDto>>> GetLatestCovidReport()
        {
            var result = await _covidTrackingClient.GetFromJsonAsync<IEnumerable<CovidTrackingInfoDto>>(""); 
            return Result.Success(result);
        }

        public async Task<Result<CovidTrackingInfoDto>> GetLatestCovidReportByLocation(string locationName)
        {
            throw new System.NotImplementedException();
        }
    }
}