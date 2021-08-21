using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.WebApi.ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoxTI.Challenge.CovidTracking.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ICovid19TrackingService _covid19TrackingService;

        public ReportController(ICovid19TrackingService covid19TrackingService)
            => _covid19TrackingService = covid19TrackingService;
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await  _covid19TrackingService.GetLatestCovidReport();
            return Ok(result.Value);
        }

    }
}