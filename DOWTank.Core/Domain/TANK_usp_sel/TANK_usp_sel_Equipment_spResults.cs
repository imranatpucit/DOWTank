using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWTank.Core.Domain.TANK_usp_sel
{
    public class TANK_usp_sel_Equipment_spResults
    {
        public int EquipmentID { get; set; }
        public string EquipmentAN { get; set; }
        public string CheckDigitAN { get; set; }
        public Int16? EquipmentClassTypeCD { get; set; }
        public Int16? EquipmentTypeCD { get; set; }
        public string EquipmentTypeDS { get; set; }
        public int? LocationID { get; set; }
        public string LocationDS { get; set; }
        public DateTime? LocationPlacementDT { get; set; }
        public bool LocationDedicatedFL { get; set; }
        public int? DedicatedLocationID { get; set; }
        public string DedicatedLocationDS { get; set; }
        public int? OwnerID { get; set; }
        public int? OperatorID { get; set; }
        public Int16? LoadStatusTypeCD { get; set; }
        public Int16? MaintConditionTypeCD { get; set; }
        public string DOTInspectedDT { get; set; }
        public double? TankCapacity { get; set; }
        public string TankLastTestDT { get; set; }
        public string TankNextTestDT { get; set; }
        public bool LastTestHydroFL { get; set; }
        public Int16? DedicatedProductID { get; set; }
        public int? BarrelConditionTypeCD { get; set; }
        public int? TankGradeTypeCD { get; set; }
        public bool PoolFL { get; set; }
        public int? ProductID { get; set; }
        public string ProductDS { get; set; }
        public int? MoveTypeCD { get; set; }
        public bool ActiveFL { get; set; }
    }
}
