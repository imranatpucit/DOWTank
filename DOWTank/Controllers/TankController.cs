using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DOWTank.Common;
using DOWTank.Core.Domain.TANK_usp_insupd;
using DOWTank.Core.Domain.TANK_usp_upd;
using DOWTank.Core.Service;
using DOWTank.Models;

namespace DOWTank.Controllers
{
    public class TankController : BaseController
    {
        private readonly IUtilityService _utilityService;
        private readonly ISharedFunctions _sharedFunctions;
        public TankController(IUtilityService utilityService, ISharedFunctions sharedFunctions)
        {
            _utilityService = utilityService;
            _sharedFunctions = sharedFunctions;
        }

        #region Tank Prep

        //
        // GET: /Tank/
        public ActionResult Prep()
        {
            LoadTankPrepDropdowns();

            var viewModel = new TankPrepPostModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Prep(TankPrepPostModel postModel)
        {
            LoadTankPrepDropdowns();
            if (!ModelState.IsValid)
            {
                //return appropriate validation messages
                return View(postModel);
            }
            //todo: re-factor it as required
            TANK_usp_insupd_TankPrep_spParams TANK_usp_insupd_TankPrep_spParams =
                new TANK_usp_insupd_TankPrep_spParams();
            TANK_usp_insupd_TankPrep_spParams.LocationID = 1;
            TANK_usp_insupd_TankPrep_spParams.EquipmentID = postModel.EquipmentID;
            TANK_usp_insupd_TankPrep_spParams.ChassisEquipmentID = postModel.ChassisEquipmentID;
            TANK_usp_insupd_TankPrep_spParams.LoadStatusTypeCD = postModel.LoadStatusTypeCD;
            TANK_usp_insupd_TankPrep_spParams.ReloadFL = postModel.ReloadFL;
            TANK_usp_insupd_TankPrep_spParams.ProductID = postModel.ProductID;
            TANK_usp_insupd_TankPrep_spParams.FromLocationID = postModel.FromLocationID;
            TANK_usp_insupd_TankPrep_spParams.ToLocationID = postModel.ToLocationID;
            TANK_usp_insupd_TankPrep_spParams.ChargeCodeID = postModel.ChargeCodeID;
            TANK_usp_insupd_TankPrep_spParams.ShipmentAN = postModel.ShipmentAN;
            TANK_usp_insupd_TankPrep_spParams.FittingCD = postModel.FittingCD;
            TANK_usp_insupd_TankPrep_spParams.CommentsAn = postModel.CommentsAn;
            TANK_usp_insupd_TankPrep_spParams.ScheduledLoadDT = postModel.ScheduledLoadDT;
            TANK_usp_insupd_TankPrep_spParams.ScheduledDeliveryDT = postModel.ScheduledDeliveryDT;
            TANK_usp_insupd_TankPrep_spParams.DeliverASAPFL = postModel.DeliverASAPFL;
            TANK_usp_insupd_TankPrep_spParams.ContactID = postModel.ContactID;
            TANK_usp_insupd_TankPrep_spParams.UpdateUserAN = "System";
            TANK_usp_insupd_TankPrep_spParams.TankPrepID = 0;

            _utilityService.ExecStoredProcedureWithoutResults("TANK_usp_insupd_TankPrep", TANK_usp_insupd_TankPrep_spParams);
            Success("Tank Prep Saved Successfully.");
            //return appropriate message
            return View(postModel);
        }

        //PopulateChargeCode
        [HttpGet]
        [OutputCache(Duration = int.MaxValue, VaryByParam = "searchTerm")]
        public JsonResult PopulateChargeCode(string searchTerm)
        {

            searchTerm = searchTerm.Trim();
            //todo: re-factor it later as required
            var response = _sharedFunctions.PopulateChargeCode(0, searchTerm);

            var chargeCodes = new List<Select2ViewModel>();
            if (response != null && response.Any())
            {
                foreach (var item in response)
                {
                    var chargeCode = new Select2ViewModel();
                    if (item.ChargeCodeID.HasValue)
                    {
                        chargeCode.id = item.ChargeCodeID.Value;
                        chargeCode.text = item.ChargeCodeAN;
                        chargeCodes.Add(chargeCode);
                    }
                }
            }
            return Json(chargeCodes, JsonRequestBehavior.AllowGet);
        }

        //PopulateProduct
        [HttpGet]
        [OutputCache(Duration = int.MaxValue, VaryByParam = "searchTerm")]
        public JsonResult PopulateProduct(string searchTerm)
        {
            searchTerm = searchTerm.Trim();
            //todo: re-factor it later as required
            var response = _sharedFunctions.PopulateProduct(false, 1, searchTerm);

            var productList = new List<Select2ViewModel>();
            if (response != null && response.Any())
            {
                foreach (var item in response)
                {
                    var product = new Select2ViewModel();
                    product.id = item.ProductID;
                    product.text = item.ProductDS;
                    productList.Add(product);
                }
            }
            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        //PopulateLoadPoint
        [HttpGet]
        [OutputCache(Duration = int.MaxValue, VaryByParam = "locationType")]
        public JsonResult PopulateLoadPoint(string searchTerm, int locationType = 1)
        {
            //todo: re-factor it later as required
            searchTerm = searchTerm.Trim();

            var locations = LoadLocations(locationType);

            return Json(locations, JsonRequestBehavior.AllowGet);
        }

        //PopulateEquipment
        [HttpGet]
        [OutputCache(Duration = int.MaxValue, VaryByParam = "searchTerm")]
        public JsonResult PopulateEquipment(string searchTerm)
        {
            searchTerm = searchTerm.Trim();
            //todo: re-factor it later as required
            var response = _sharedFunctions.PopulateEquipment(1, searchTerm);

            var productList = new List<Select2ViewModel>();
            if (response != null && response.Any())
            {
                foreach (var item in response)
                {
                    var product = new Select2ViewModel();
                    product.id = item.EquipmentID;
                    product.text = item.EquipmentAn + " " + item.EquipmentTypeDS;
                    productList.Add(product);
                }
            }
            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        //PopulateChassis
        [HttpGet]
        [OutputCache(Duration = int.MaxValue, VaryByParam = "searchTerm")]
        public JsonResult PopulateChassis(string searchTerm)
        {
            searchTerm = searchTerm.Trim();
            //todo: re-factor it later as required
            var response = _sharedFunctions.PopulateEquipment(2, searchTerm);

            var productList = new List<Select2ViewModel>();
            if (response != null && response.Any())
            {
                foreach (var item in response)
                {
                    var product = new Select2ViewModel();
                    product.id = item.EquipmentID;
                    product.text = item.EquipmentAn + " " + item.EquipmentTypeDS;
                    productList.Add(product);
                }
            }
            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        //PopulateContacts
        [HttpGet]
        [OutputCache(Duration = int.MaxValue, VaryByParam = "searchTerm")]
        public JsonResult PopulateContacts(string searchTerm)
        {
            searchTerm = searchTerm.Trim();
            //todo: re-factor it later as required
            var response = _sharedFunctions.PopulateContacts();

            var productList = new List<Select2ViewModel>();
            if (response != null && response.Any())
            {
                foreach (var item in response)
                {
                    var product = new Select2ViewModel();
                    product.id = item.ContactID;
                    product.text = item.Contact;
                    productList.Add(product);
                }
            }
            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        private List<Select2ViewModel> LoadLocations(int locationType)
        {
            //todo: re-factor it later as required
            var loadPoints = new List<Select2ViewModel>();

            //selected location
            if (locationType == 1)
            {
                var response = _sharedFunctions.PopulateLoadPointLocationAll(1);
                if (response != null && response.Any())
                {
                    foreach (var item in response)
                    {
                        var loadPoint = new Select2ViewModel();
                        loadPoint.id = item.LocationID;
                        loadPoint.text = item.LocationDS;
                        loadPoints.Add(loadPoint);

                    }
                }
            }
            //Over The Road
            else if (locationType == 2)
            {
                var response = _sharedFunctions.PopulateLoadPointLocationTreeFlatOverTheRoad(1);
                if (response != null && response.Any())
                {
                    foreach (var item in response)
                    {
                        var loadPoint = new Select2ViewModel();
                        loadPoint.id = item.LocationID;
                        loadPoint.text = item.LocationDS;
                        loadPoints.Add(loadPoint);

                    }
                }
            }
            //Block
            else if (locationType == 3)
            {
                var response = _sharedFunctions.PopulateLoadPointLocationTreeFlatBlock(1);
                if (response != null && response.Any())
                {
                    foreach (var item in response)
                    {
                        var loadPoint = new Select2ViewModel();
                        loadPoint.id = item.LocationID;
                        loadPoint.text = item.LocationDS;
                        loadPoints.Add(loadPoint);

                    }
                }
            }
            //Grounded
            else if (locationType == 4)
            {
                var response = _sharedFunctions.PopulateLoadPointLocationGrounded(1);
                if (response != null && response.Any())
                {
                    foreach (var item in response)
                    {
                        var loadPoint = new Select2ViewModel();
                        loadPoint.id = item.LocationID;
                        loadPoint.text = item.LocationDS;
                        loadPoints.Add(loadPoint);
                    }
                }
            }
            return loadPoints;
        }

        private void LoadTankPrepDropdowns()
        {
            #region LoadPoint

            var loadItemsPoint = new List<SelectListItem>();

            //todo: re-factor it later
            //aList.Add(GetLocationName() & " Facility")
            loadItemsPoint.Add(new SelectListItem { Text = "", Value = "", Selected = true });

            loadItemsPoint.Add(new SelectListItem { Text = "Freeport" + " Facility", Value = "1" });

            loadItemsPoint.Add(new SelectListItem { Text = "Over The Road", Value = "2" });

            loadItemsPoint.Add(new SelectListItem { Text = "Block", Value = "3", Selected = true });

            loadItemsPoint.Add(new SelectListItem { Text = "Grounded", Value = "4" });

            ViewBag.LoadPoint = loadItemsPoint;

            #endregion LoadPoint

            #region fitting ddl
            var fittingList = new List<SelectListItem>();
            var response = _sharedFunctions.PopulateFitting();
            if (response != null && response.Any())
            {
                fittingList.Add(new SelectListItem { Text = "", Value = "" });
                foreach (var item in response)
                {
                    fittingList.Add(new SelectListItem { Text = item.FittingDS, Value = item.FittingCD.HasValue ? item.FittingCD.Value.ToString() : string.Empty });
                }
                ViewBag.FittingCD = fittingList;
            }

            #endregion fitting ddl

            #region PopulateLoadStatusType
            var statusTypeList = new List<SelectListItem>();
            var responseStustType = _sharedFunctions.PopulateLoadStatusType();
            if (responseStustType != null && responseStustType.Any())
            {
                statusTypeList.Add(new SelectListItem { Text = "", Value = "" });
                foreach (var item in responseStustType)
                {
                    statusTypeList.Add(new SelectListItem { Text = item.LoadStatusTypeDS, Value = item.LoadStatusTypeCD.ToString() });
                }
                ViewBag.LoadStatusTypeCD = statusTypeList;
            }

            #endregion PopulateLoadStatusType
        }

        #endregion Tank Prep

        #region Tank Arrival/Update

        [HttpGet]
        public ActionResult TankArrivalUpdate()
        {
            LoadTankPrepDropdowns();
            var viewModel = new TankArrivalUpdatePostModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult TankArrivalUpdate(TankArrivalUpdatePostModel postModel)
        {
            LoadTankPrepDropdowns();
            if (!ModelState.IsValid)
            {
                //return appropriate validation messages
                return View(postModel);
            }
            //TODO: re-factor it as required
            var TANK_usp_upd_ArriveEquipment_spParams = new TANK_usp_upd_ArriveEquipment_spParams();

            TANK_usp_upd_ArriveEquipment_spParams.EquipmentID = postModel.EquipmentID;
            TANK_usp_upd_ArriveEquipment_spParams.EquipmentAN = postModel.EquipmentAN.Trim();
            if (postModel.EquipmentAN.Trim().Length == 10)
            {
                TANK_usp_upd_ArriveEquipment_spParams.EquipmentAN = postModel.EquipmentAN.Trim().Substring(0, 9);
            }
            if (postModel.EquipmentAN.Trim().Length == 11)
            {
                TANK_usp_upd_ArriveEquipment_spParams.CheckDigitAN = postModel.EquipmentAN.Trim().Substring(9, 10);
            }
            TANK_usp_upd_ArriveEquipment_spParams.LoadStatusTypeCD = postModel.LoadStatusTypeCD;
            TANK_usp_upd_ArriveEquipment_spParams.LocationID = postModel.LocationID;
            TANK_usp_upd_ArriveEquipment_spParams.UpdateUserAN = "System";

            _utilityService.ExecStoredProcedureWithoutResults("TANK_usp_upd_ArriveEquipment", TANK_usp_upd_ArriveEquipment_spParams);

            Success("Changes saved succesfully.");
            return View(postModel);
        }

        [HttpGet]
        public JsonResult RefreshEquipment(int? equipmentId, string equipmentAN)
        {
            var data = _sharedFunctions.RefreshEquipment(equipmentId, equipmentAN);
            if (data != null && data.Any())
            {
                var result = data.FirstOrDefault();
                return Json(new { EquipmentID = result.EquipmentID, EquipmentAN = result.EquipmentAN, EquipmentClassTypeCD = result.EquipmentClassTypeCD, LocationID = result.LocationID, LoadStatusTypeCD = result.LoadStatusTypeCD, LocationDS = result.LocationDS }, JsonRequestBehavior.AllowGet);
            }
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        #endregion Tank Arrival/Update

    }

}