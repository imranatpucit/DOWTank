using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DOWTank.Core.Domain.TANK_usp_sel;
using DOWTank.Core.Service;

namespace DOWTank.Common
{
    public interface ISharedFunctions
    {
        IEnumerable<TANK_usp_sel_ChargeCodeDDL_spResults> PopulateChargeCode(int iIncludeBlank, string sFilter);
        IEnumerable<TANK_usp_sel_LocationTreeFLAT_spResults> PopulateLoadPointLocationTreeFlatOverTheRoad(int majorLocationId);
        IEnumerable<TANK_usp_sel_LocationTreeFLAT_spResults> PopulateLoadPointLocationTreeFlatBlock(int majorLocationId);
        IEnumerable<TANK_usp_sel_LocationTreeGrounded_spResults> PopulateLoadPointLocationGrounded(int majorLocationId);
        IEnumerable<TANK_usp_sel_locationTreeALL_spResults> PopulateLoadPointLocationAll(int majorLocationId);
        IEnumerable<TANK_usp_sel_ProductDDL_spResults> PopulateProduct(bool iIncludeBlank, int locationId, string searchTerm);
        IEnumerable<TANK_usp_sel_FittingDDL_spResults> PopulateFitting();
        IEnumerable<TANK_usp_sel_LoadStatusTypeDDL_spResults> PopulateLoadStatusType();
        IEnumerable<TANK_usp_sel_EquipmentSearch2_spResults> PopulateEquipment(Int16 EquipmentClassTypeCD,
                                                                               string EquipmentAn);
        IEnumerable<TANK_usp_sel_ContactDDL_spResults> PopulateContacts();
        IEnumerable<TANK_usp_sel_Equipment_spResults> RefreshEquipment(int? equipmentId, string equipmentAN);
        IEnumerable<TANK_usp_sel_DriverDDL_spResults> PopulateDrivers(bool iIncludeBlank);
        IEnumerable<TANK_usp_sel_WasteClassTypeDDL_spResults> PopulateWasteClassTypes(bool iIncludeBlank);
        IEnumerable<TANK_usp_sel_DispatchReasonDDL_spResults> PopulateDispatchReasons(bool iIncludeBlank);
        IEnumerable<TANK_usp_sel_DispatchLastMove_spResults> LoadDispatchLastMove(String strTankNumber, int locationId);
    }

    public class SharedFunctions : ISharedFunctions
    {
        private readonly IUtilityService _utilityService;

        public SharedFunctions(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }

        public IEnumerable<TANK_usp_sel_ChargeCodeDDL_spResults> PopulateChargeCode(int iIncludeBlank, string sFilter)
        {
            // database call

            var TANK_usp_sel_ChargeCodeDDL_spParams = new TANK_usp_sel_ChargeCodeDDL_spParams()
            {
                //TODO: re-factor it later from hard coded
                IncludeBlank = false,
                LocationID = 1
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_ChargeCodeDDL_spResults>("TANK_usp_sel_ChargeCodeDDL", TANK_usp_sel_ChargeCodeDDL_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_LocationTreeFLAT_spResults> PopulateLoadPointLocationTreeFlatOverTheRoad(int majorLocationId)
        {
            //Case "Over The Road" '-- Over the road
            //   SA.SelectCommand.CommandText = "dbo.TANK_usp_sel_LocationTreeFLAT"
            //   SA.SelectCommand.Parameters.Add("@LocationTypeCD", 4)
            // database call

            var TANK_usp_sel_locationTreeFLAT_spParams = new TANK_usp_sel_locationTreeFLAT_spParams()
            {
                //TODO: re-factor it later from hard coded
                LocationTypeCD = 4
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_LocationTreeFLAT_spResults>("TANK_usp_sel_LocationTreeFLAT", TANK_usp_sel_locationTreeFLAT_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_LocationTreeFLAT_spResults> PopulateLoadPointLocationTreeFlatBlock(int majorLocationId)
        {

            var TANK_usp_sel_locationTreeFLAT_spParams = new TANK_usp_sel_locationTreeFLAT_spParams()
            {
                //TODO: re-factor it later from hard coded
                MajorLocationID = 1,
                LocationTypeCD = 3
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_LocationTreeFLAT_spResults>("TANK_usp_sel_LocationTreeFLAT", TANK_usp_sel_locationTreeFLAT_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_LocationTreeGrounded_spResults> PopulateLoadPointLocationGrounded(int majorLocationId)
        {

            var TANK_usp_sel_LocationTreeGrounded_spParams = new TANK_usp_sel_LocationTreeGrounded_spParams()
            {
                //TODO: re-factor it later from hard coded
                MajorLocationID = 1
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_LocationTreeGrounded_spResults>("TANK_usp_sel_LocationTreeGrounded", TANK_usp_sel_LocationTreeGrounded_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_locationTreeALL_spResults> PopulateLoadPointLocationAll(int majorLocationId)
        {

            var TANK_usp_sel_locationTreeALL_spParams = new TANK_usp_sel_locationTreeALL_spParams()
            {
                //TODO: re-factor it later from hard coded
                MajorLocationID = 1
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_locationTreeALL_spResults>("TANK_usp_sel_locationTreeALL", TANK_usp_sel_locationTreeALL_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_ProductDDL_spResults> PopulateProduct(bool iIncludeBlank, int locationId, string searchTerm)
        {
            // database call

            var TANK_usp_sel_ProductDDL_spParams = new TANK_usp_sel_ProductDDL_spParams()
            {
                //TODO: re-factor it later from hard coded
                IncludeBlank = false,
                LocationID = 1,
                Filter = searchTerm
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_ProductDDL_spResults>("TANK_usp_sel_ProductDDL", TANK_usp_sel_ProductDDL_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_FittingDDL_spResults> PopulateFitting()
        {
            // database call

            var TANK_usp_sel_FittingDDL_spParams = new TANK_usp_sel_FittingDDL_spParams()
            {
                //TODO: re-factor it later from hard coded
                IncludeBlank = false,
                LocationID = 1,
             };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_FittingDDL_spResults>("TANK_usp_sel_FittingDDL", TANK_usp_sel_FittingDDL_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_LoadStatusTypeDDL_spResults> PopulateLoadStatusType()
        {
            // database call

            var TANK_usp_sel_LoadStatusTypeDDL_spParams = new TANK_usp_sel_LoadStatusTypeDDL_spParams()
            {
                //TODO: re-factor it later from hard coded
                IncludeBlank = false
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_LoadStatusTypeDDL_spResults>("TANK_usp_sel_LoadStatusTypeDDL", TANK_usp_sel_LoadStatusTypeDDL_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_EquipmentSearch2_spResults> PopulateEquipment(Int16 EquipmentClassTypeCD, string EquipmentAn)
        {
            // database call

            var TANK_usp_sel_EquipmentSearch2_spParams = new TANK_usp_sel_EquipmentSearch2_spParams()
            {
                //TODO: re-factor it later from hard coded
                EquipmentClassTypeCD = EquipmentClassTypeCD,
                EquipmentAn = EquipmentAn
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_EquipmentSearch2_spResults>("TANK_usp_sel_EquipmentSearch2", TANK_usp_sel_EquipmentSearch2_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_ContactDDL_spResults> PopulateContacts()
        {
            // database call

            var TANK_usp_sel_ContactDDL_spParams = new TANK_usp_sel_ContactDDL_spParams()
            {
                //TODO: re-factor it later from hard coded
                IncludeBlank = false,
                LocationID = 1
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_ContactDDL_spResults>("TANK_usp_sel_ContactDDL", TANK_usp_sel_ContactDDL_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_Equipment_spResults> RefreshEquipment(int? equipmentId, string equipmentAN)
        {
            // database call

            var TANK_usp_sel_Equipment_spParams = new TANK_usp_sel_Equipment_spParams()
            {
                //TODO: re-factor it later from hard coded
                EquipmentID = equipmentId,
                EquipmentAN = equipmentAN
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_Equipment_spResults>("TANK_usp_sel_Equipment", TANK_usp_sel_Equipment_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_DriverDDL_spResults> PopulateDrivers(bool iIncludeBlank)
        {
            // database call

            var TANK_usp_sel_DriverDDL_spParams = new TANK_usp_sel_DriverDDL_spParams()
            {
                //TODO: re-factor it later from hard coded
                IncludeBlank = iIncludeBlank
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_DriverDDL_spResults>("TANK_usp_sel_DriverDDL", TANK_usp_sel_DriverDDL_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_WasteClassTypeDDL_spResults> PopulateWasteClassTypes(bool iIncludeBlank)
        {
            // database call

            var TANK_usp_sel_WasteClassTypeDDL_spParams = new TANK_usp_sel_WasteClassTypeDDL_spParams()
            {
                //TODO: re-factor it later from hard coded
                IncludeBlank = iIncludeBlank
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_WasteClassTypeDDL_spResults>("TANK_usp_sel_WasteClassTypeDDL", TANK_usp_sel_WasteClassTypeDDL_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_DispatchReasonDDL_spResults> PopulateDispatchReasons(bool iIncludeBlank)
        {
            // database call

            var TANK_usp_sel_DispatchReasonDDL_spParams = new TANK_usp_sel_DispatchReasonDDL_spParams()
            {
                //TODO: re-factor it later from hard coded
                IncludeBlank = iIncludeBlank
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_DispatchReasonDDL_spResults>("TANK_usp_sel_DispatchReasonTypeDDL", TANK_usp_sel_DispatchReasonDDL_spParams);

            //# database call

            return data;
        }

        public IEnumerable<TANK_usp_sel_DispatchLastMove_spResults> LoadDispatchLastMove(String strTankNumber, int locationId)
        {
            // database call

            var TANK_usp_sel_DispatchLastMove_spParams = new TANK_usp_sel_DispatchLastMove_spParams()
            {
                //TODO: re-factor it later from hard coded
                EquipmentAN = strTankNumber.Trim().Substring(0, 10),
                FacilityLocationID = 1
            };
            var data = _utilityService.ExecStoredProcedureWithResults<TANK_usp_sel_DispatchLastMove_spResults>("TANK_usp_sel_EquipmentLastDispatch", TANK_usp_sel_DispatchLastMove_spParams);

            //# database call

            return data;
        }
    }


}