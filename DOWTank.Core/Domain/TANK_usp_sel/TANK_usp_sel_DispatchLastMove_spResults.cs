using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOWTank.Core.Domain.TANK_usp_sel
{
    public class TANK_usp_sel_DispatchLastMove_spResults
    {
        public String ChargeBlockLocationDS { get; set; }
        public String ChargeCodeAN { get; set; }
        public String ChassisEquipmentAN { get; set; }
        public String DispatchStartDt { get; set; }
        public String Driver { get; set; }
        public Int32 DriverID { get; set; }
        public String ProductDS { get; set; }
        public String ToLocationDS { get; set; }
        public String FittingDS { get; set; }
        public String ShipmentAN { get; set; }
        public String ContactNM { get; set; }
        public Int32 ContactID { get; set; }
    }
}
