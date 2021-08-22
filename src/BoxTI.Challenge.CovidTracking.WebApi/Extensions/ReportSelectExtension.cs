using System.Linq;
using BoxTI.Challenge.CovidTracking.WebApi.Models;

namespace BoxTI.Challenge.CovidTracking.WebApi.Extensions
{
    public static class ReportSelectExtension
    {
        public static IQueryable<ReportDto> MapReportToDto(this IQueryable<Report> reports)
            => reports.Select(r => new ReportDto
            {
                Location = r.Location.Name,
                RegisterDate = r.RegisterDate,
                ActiveCases = r.ActiveCases,
                NewCases = r.NewCases,
                NewDeaths = r.NewDeaths,
                TotalCases = r.TotalCases,
                TotalDeaths = r.TotalDeaths,
                TotalRecovered = r.TotalRecovered,
                LastUpdate = r.LastUpdate
            });
    }
}