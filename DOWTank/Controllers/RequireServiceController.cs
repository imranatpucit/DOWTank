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
    public class RequireServiceController : Controller
    {

        private readonly IUtilityService _utilityService;

        public RequireServiceController(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }
        //
        // GET: /RequireService/
        public ActionResult Index()
        {
            // database call

            var TANK_usp_rpt_RequiresMaint_spParams = new TANK_usp_rpt_RequiresMaint_spParams()
            {
                //TODO: re-factor it later from hard coded
                LocationID = 1
            };
            DataTable data = _utilityService.ExecStoredProcedureForDataTable("TANK_usp_rpt_RequiresMaint", TANK_usp_rpt_RequiresMaint_spParams);

            //# database call

            @ViewBag.TotalRecords = data.Rows.Count;
            return View(data);
        }
	}
}