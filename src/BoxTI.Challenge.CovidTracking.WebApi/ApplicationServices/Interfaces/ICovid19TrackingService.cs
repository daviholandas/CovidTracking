using System.Collections.Generic;
using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.WebApi.Models;

namespace BoxTI.Challenge.CovidTracking.WebApi.ApplicationServices.Interfaces
{
    public interface ICovid19TrackingService
    {
        Task<Result<CovidTrackingInfoDto>> GetLatestCovidReportByLocation(string locationName);
    }
}