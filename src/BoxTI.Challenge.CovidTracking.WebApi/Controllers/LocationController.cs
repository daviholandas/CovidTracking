using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoxTI.Challenge.CovidTracking.WebApi.Data;
using BoxTI.Challenge.CovidTracking.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoxTI.Challenge.CovidTracking.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationContext _applicationContext;

        public LocationController(ApplicationContext applicationContext)
            => _applicationContext = applicationContext;
        
        [HttpGet] 
        public async Task<IEnumerable<LocationDto>> GetAllLocation()
            => await _applicationContext.Locations.Where(l => l.ActiveStatus == ActiveStatus.Actived)
                .Select(l => new LocationDto
                {
                    Name = l.Name,
                    Abbreviation = l.Abbreviation,
                    ActiveStatus = l.ActiveStatus.ToString()
                }).ToListAsync();
        
        [HttpPost]
        public async Task<IActionResult> RegisterNewLocation(LocationDto locationDto)
        {
            await _applicationContext.Locations.AddAsync(new(locationDto.Name, locationDto.Abbreviation));
            var result = await _applicationContext.SaveChangesAsync();
            
            return result > 0 ? Ok() : BadRequest("Erro ao salvar nova location.");
        }

        [HttpDelete("{locantionName}")]
        public async Task<IActionResult> Delete(string locantionName)
        {
            var location =
                await _applicationContext.Locations
                    .FirstOrDefaultAsync(l => l.Name.ToLower().Equals(locantionName.ToLower().Trim()));
            
            if (location is null)
                return NotFound("Location can't found.");
            
            location.ChangeActiveStatus(ActiveStatus.Desactived);
            _applicationContext.Locations.Update(location);
            await _applicationContext.SaveChangesAsync();
            
            return Ok();
        }
    }
}