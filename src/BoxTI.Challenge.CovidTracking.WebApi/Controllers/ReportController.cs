using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.WebApi.ApplicationServices.Interfaces;
using BoxTI.Challenge.CovidTracking.WebApi.Data;
using BoxTI.Challenge.CovidTracking.WebApi.Extensions;
using BoxTI.Challenge.CovidTracking.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoxTI.Challenge.CovidTracking.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ICovid19TrackingService _covid19TrackingService;
        private readonly ApplicationContext _applicationContext;

        public ReportController(ICovid19TrackingService covid19TrackingService, ApplicationContext applicationContext)
            => (_covid19TrackingService, _applicationContext) = (covid19TrackingService, applicationContext);
        
        [HttpPost("{locationName}")]
        public async Task<IActionResult> GetReportToSave(string locationName)
        {
            var result = await  _covid19TrackingService.GetLatestCovidReportByLocation(locationName);
            if (!result.IsSuccess)
                return BadRequest(result.Error.Message);
            
            var location =  await _applicationContext.Locations
                    .FirstOrDefaultAsync(l => l.Name.ToLower().Equals(locationName.ToLower().Trim()));
            if (location is null)
                return NotFound("The location not found in database.");
            
            Report report = new
                (
                    DateTime.Now, 
                    result.Value.ActiveCases, 
                    result.Value.NewCases, 
                    result.Value.NewDeaths,
                    result.Value.TotalCases,
                    result.Value.TotalDeaths,
                    result.Value.TotalRecovered,
                    result.Value.LastUpdate,
                    location.Id
                );
            await _applicationContext.Reports.AddAsync(report);
            await _applicationContext.SaveChangesAsync();
            
            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IEnumerable<ReportDto>> GetAllReports()
            => await _applicationContext.Reports.Where(r => r.Location.ActiveStatus == ActiveStatus.Actived)
                .MapReportToDto().ToListAsync();


        [HttpGet("{locationName}")]
        public async Task<IEnumerable<ReportDto>> GetReportByLocation(string locationName)
            => await _applicationContext.Reports
                .Where(r => r.Location.Name.Equals(locationName.ToLower().Trim()) &&
                            r.Location.ActiveStatus == ActiveStatus.Actived)
                .MapReportToDto().ToListAsync();
       
        [HttpGet("byorder")]
        public async Task<IActionResult> GetReportByOrder()
        {
            var reports = await _applicationContext.Reports.Include(r => r.Location).OrderByDescending(r => r.ActiveCases)
                .ToListAsync();
            var result = reports
                .Select((r, i) => new
                {
                    r.Location.Name, 
                    r.ActiveCases, 
                    Percent = "" + r.CalculatePercentActiveCases(reports[i == 0 ? 0 : i -1].ActiveCases) + "%"
                });
            
            return Ok(result);
        }
    }
}