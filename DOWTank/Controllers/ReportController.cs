using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DOWTank.Core.Domain.TANK_usp_rpt;
using DOWTank.Core.Service;

namespace DOWTank.Controllers
{
    public class ReportController : Controller
    {
        private readonly IUtilityService _utilityService;

        public ReportController(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }
        //
        // GET: /Report/
        public ActionResult AuditDriverList()
        {
            // database call

            var TANK_usp_rpt_AuditDrivers_spParams = new TANK_usp_rpt_AuditDrivers_spParams()
            {
                //TODO: re-factor it later from hard coded
                LocationID = 1,
                StartDT = DateTime.Now.AddYears(-1),
                EndDT = DateTime.Now
            };
            DataTable data = _utilityService.ExecStoredProcedureForDataTable("TANK_usp_rpt_AuditDrivers", TANK_usp_rpt_AuditDrivers_spParams);

            //# database call

            ReportClass rptH = new ReportClass();

            rptH.FileName = Server.MapPath("~/Reports/crDailyDriverActivity.rpt");

            rptH.Load();

            rptH.SetDataSource(data);

            Stream stream = rptH.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            return File(stream, "application/pdf");

            // return View();
        }


        private static byte[] StreamToBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    }

}