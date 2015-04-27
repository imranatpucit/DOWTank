using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWTank.Core.Domain.TANK_usp_insupd
{
    public class TANK_usp_insupd_TankPrep_spParams
    {
        public TANK_usp_insupd_TankPrep_spParams()
        {
            ActiveFL = true;
            TankPrepID = 0;
        }
        public int TankPrepID { get; set; }
        public int? EquipmentID { get; set; }
        public int? ChassisEquipmentID { get; set; }
        public Int16? LoadStatusTypeCD { get; set; }
        public Int16? ProductID { get; set; }
        public int? FromLocationID { get; set; }
        public int? ToLocationID { get; set; }
        public int? ChargeCodeID { get; set; }
        public string ShipmentAN { get; set; }
        public DateTime? ScheduledLoadDT { get; set; }
        public DateTime? ScheduledDeliveryDT { get; set; }
        public bool DeliverASAPFL { get; set; }
        public int? FittingCD { get; set; }
        public string CommentsAn { get; set; }
        public string MoveTypeCD { get; set; }
        public int LocationID { get; set; }
        public bool ActiveFL { get; set; }
        public int DispatchedFL { get; set; }
        public bool ReloadFL { get; set; }
        public int? ContactID { get; set; }
        public string UpdateUserAN { get; set; }
    }
}
