using Microsoft.AspNetCore.Mvc;
using TricyrideServerAdmin.Models;

namespace TricyrideServerAdmin.Services.ReportServices
{
    public interface IReportService
    {
        IActionResult GetReport(List<ReportModel> reports);
    }
}