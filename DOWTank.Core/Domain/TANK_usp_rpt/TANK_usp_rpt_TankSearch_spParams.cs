using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWTank.Core.Domain.TANK_usp_rpt
{
    public class TANK_usp_rpt_TankSearch_spParams
    {
        public int? LocationID { get; set; }
        public string EquipmentAN { get; set; }
        public string ChassisEquipmentAN { get; set; }
        public string ProductDS { get; set; }
        public string LoadStatusTypeCD { get; set; }
        public string SubLocationDS { get; set; }
        public int? SubLocationID { get; set; }
        public string FromSubLocationDS { get; set; }
        public int? FromSubLocationID { get; set; }
        public string ChargeCodeAN { get; set; }
        public string ShipmentAN { get; set; }
        public string ServiceTypeDS { get; set; }
        public string ChargeBlockLocationAN { get; set; }
        public Int16? DispatchReasonTypeCD { get; set; }
        public bool SearchLastMoveOnlyFL { get; set; }
        public string DedicatedProductDS { get; set; }
    }
}
