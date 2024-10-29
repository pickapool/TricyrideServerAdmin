using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.NETCore;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using TricyrideServerAdmin.Models;

namespace TricyrideServerAdmin.Services.ReportServices
{
    public class ReportService : ControllerBase, IReportService
    {
        public IActionResult GetReport(List<ReportModel> reports)
        {
            using var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream("TricyrideServerAdmin.ReportFormatServices.ReportFormats.DriversSatisfactoryReport.rdlc");

            LocalReport report = new();
            report.LoadReportDefinition(rs);
            report.DataSources.Add(new ReportDataSource("reportdataset", reports));
            return File(report.Render("PDF"), "application/pdf", "report." + "pdf");
        }
    }
}