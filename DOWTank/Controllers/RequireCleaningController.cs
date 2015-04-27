using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOWTank.Core.Domain.TANK_usp_rpt;
using DOWTank.Core.Service;

namespace DOWTank.Controllers
{
    public class RequireCleaningController : Controller
    {
        private readonly IUtilityService _utilityService;

        public RequireCleaningController(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }

        //
        // GET: /RequireCleaning/
        public ActionResult Index(int? page = 1)
        {
            // database call

            var TANK_usp_rpt_RequiresCleaning_spParams = new TANK_usp_rpt_RequiresCleaning_spParams()
            {
                //TODO: re-factor it later from hard coded
                InstallID = 1,
                LocationID = 1
            };
            DataTable data = _utilityService.ExecStoredProcedureForDataTable("TANK_usp_rpt_RequiresCleaning", TANK_usp_rpt_RequiresCleaning_spParams);

            //# database call
            @ViewBag.TotalRecords = data.Rows.Count;

            return View(data);
        }
    }
}